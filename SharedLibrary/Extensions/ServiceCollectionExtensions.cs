using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SharedLibrary.Infrastructure;
using SharedLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLibrary.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private static IServiceCollection ConfigureQueueMappingDictionary<TOptions>(this IServiceCollection services, IConfigurationSection section)
            where TOptions : class, IDictionary<string, string>
        {
            var values = section
                .GetChildren()
                .ToList();

            services.Configure<TOptions>(x =>
                values.ForEach(v => x.Add($"https://{v.Key}", v.Value))
            );

            return services;
        }

        public static IServiceCollection ConfigureQueueServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IMessageDistributor, MessageDistributor>();
            services.Configure<StorageAccount>(config.GetSection("StorageAccount"));
            services.ConfigureQueueMappingDictionary<QueueMapping>(config.GetSection("QueueMapping"));
            services.AddSingleton<IMessageQueueFactory, MessageQueueFactory>();
            return services;
        }

        public static IServiceCollection ConfigureCosmosServices(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<CosmosDbSettings>(config.GetSection("CosmosDbSettings"));
            services.Configure<CosmosClientOptions>(config.GetSection("CosmosDbSettings"));
            services.AddSingleton<CosmosClient>(provider => new CosmosClient(
                Environment.GetEnvironmentVariable("CosmosDBConnectionString"),
                provider.GetService<IOptions<CosmosClientOptions>>().Value));
            services.AddSingleton<ICosmosDb, CosmosDb>();
            return services;
        }
    }
}
