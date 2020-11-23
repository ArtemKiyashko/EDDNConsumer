using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Azure.Storage.Queues;
using EDDNConsumerCore.Settings;
using Newtonsoft.Json;
using System.Collections.Generic;
using SharedLibrary.Infrastructure;
using SharedLibrary.Extensions;
using SharedLibrary.Settings;

namespace EDDNConsumerCore
{
    class Program
    {
        private static readonly string _environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        static async Task Main(string[] args)
        {
            var builder = new HostBuilder();
            builder
                .ConfigureServices((host, services) => {
                    services.AddHostedService<ConsumerService>();
                    services.AddTransient<IMessageDistributor, MessageDistributor>();
                    services.Configure<StorageAccount>(host.Configuration.GetSection("StorageAccount"));
                    services.ConfigureQueueMappingDictionary<QueueMapping>(host.Configuration.GetSection("QueueMapping"));
                    services.Configure<EddnClientSettings>(host.Configuration.GetSection("EddnClientSettings"));
                    services.AddSingleton<IMessageQueueFactory, MessageQueueFactory>();
                })
                .ConfigureWebJobs(wbuilder => wbuilder.AddAzureStorageCoreServices())
                .ConfigureLogging(lbuilder => {
                    lbuilder
                        .AddConsole()
                        .AddApplicationInsightsWebJobs()
                        .SetMinimumLevel(LogLevel.Warning);
                })
                .ConfigureAppConfiguration((host, config) => {
                    config.AddJsonFile($"appsettings.json", true, true);
                    config.AddJsonFile($"appsettings.{_environment}.json", true, true);
                    config.AddUserSecrets<Program>(true, true);
                    config.AddEnvironmentVariables();
                });
            var host = builder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}
