using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using CommandLine;
using EventHubSender.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SharedLibrary.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventHubSender
{
    class Program
    {
        private const string connectionString = "<EVENT HUBS NAMESPACE - CONNECTION STRING>";
        private const string eventHubName = "<EVENT HUB NAME>";
        private static Options _commandlineOptions { get; set; }

        static async Task Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed(SetOptions)
                   .WithNotParsed(HandleParseError);

            var builder = new HostBuilder();
            builder
                .ConfigureServices((host, services) =>
                {
                    services.AddHostedService<EventSenderService>(provider => {
                        var producer = provider.GetService<EventHubProducerClient>();
                        var logger = provider.GetService<ILogger<EventSenderService>>();
                        var dataReader = provider.GetService<IDataReader<IEnumerable<SpanshSystem>>>();
                        return new EventSenderService(producer, _commandlineOptions.MaxBytesInBatch, dataReader, logger);
                    });
                    services.AddSingleton<EventHubProducerClient>(provider => {
                        var settings = provider.GetService<IOptions<EventHubSettings>>().Value;
                        return new EventHubProducerClient(settings.ConnectionString, settings.EventHubName);
                    });
                    services.Configure<EventHubSettings>(host.Configuration.GetSection("EventHubSettings"));
                    services.AddTransient<IDataReader<IEnumerable<SpanshSystem>>, SpanshDataReader>(provider => 
                        new SpanshDataReader(_commandlineOptions.PathToFile, provider.GetService<ILogger<SpanshDataReader>>()));
                })
                .ConfigureAppConfiguration((host, config) => {
                    config.AddJsonConfigs();
                    config.AddUserSecrets<Program>(true, true);
                    config.AddEnvironmentVariables();
                })
                .ConfigureLogging(lbuilder => {
                    lbuilder
                        .AddConsole()
                        .SetMinimumLevel(LogLevel.Information);
                });
            var host = builder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }

        private static void SetOptions(Options opts)
        {
            _commandlineOptions = opts;
        }
        private static void HandleParseError(IEnumerable<Error> errs)
        {
            Environment.Exit(-1);
        }
    }
}
