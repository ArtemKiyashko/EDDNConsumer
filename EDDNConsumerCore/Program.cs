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
                    services.Configure<EddnClientSettings>(host.Configuration.GetSection("EddnClientSettings"));
                    services.ConfigureQueueServices(host.Configuration);
                })
                .ConfigureWebJobs(wbuilder => wbuilder.AddAzureStorageCoreServices())
                .ConfigureLogging(lbuilder => {
                    lbuilder
                        .AddConsole()
                        .AddApplicationInsightsWebJobs()
                        .SetMinimumLevel(LogLevel.Warning);
                })
                .ConfigureAppConfiguration((host, config) => {
                    config.AddJsonConfigs();
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
