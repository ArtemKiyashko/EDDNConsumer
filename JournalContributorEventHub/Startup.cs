using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedLibrary.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

[assembly: FunctionsStartup(typeof(JournalSystemsEventProcessor.Startup))]

namespace JournalSystemsEventProcessor
{
    public class Startup : FunctionsStartup
    {
        private IConfigurationRoot _functionConfig;
        private readonly string COSMOS_CONNECTION_STRING = Environment.GetEnvironmentVariable("CosmosDBConnectionString");
        private readonly string ENVIRONMENT = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        public override void Configure(IFunctionsHostBuilder builder)
        {
            _functionConfig = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(builder.GetContext().ApplicationRootPath, "appsettings.json"), optional: true, reloadOnChange: true)
                .AddJsonFile(Path.Combine(builder.GetContext().ApplicationRootPath, $"appsettings.{ENVIRONMENT}.json"), optional: true, reloadOnChange: true)
                .Build();

            builder.Services.AddSingleton<CosmosClient>(_ =>
                new CosmosClient(COSMOS_CONNECTION_STRING, new CosmosClientOptions() {
                    AllowBulkExecution = true,
                    RequestTimeout = TimeSpan.FromSeconds(90)
                }));
            builder.Services.ConfigureQueueServices(_functionConfig);
            builder.Services.ConfigureCosmosServices(_functionConfig);
        }
    }
}
