using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLibrary.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureQueueMappingDictionary<TOptions>(this IServiceCollection services, IConfigurationSection section)
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
    }
}
