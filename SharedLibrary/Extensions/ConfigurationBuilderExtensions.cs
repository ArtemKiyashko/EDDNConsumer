using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SharedLibrary.Extensions
{
    public static class ConfigurationBuilderExtensions
    {
        private readonly static string ENVIRONMENT = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        public static IConfigurationBuilder AddJsonConfigs(this IConfigurationBuilder configurationBuilder, IFunctionsHostBuilder hostBuilder)
        {
            return configurationBuilder
                .AddJsonFile(Path.Combine(hostBuilder.GetContext().ApplicationRootPath, "appsettings.json"), optional: true, reloadOnChange: true)
                .AddJsonFile(Path.Combine(hostBuilder.GetContext().ApplicationRootPath, $"appsettings.{ENVIRONMENT}.json"), optional: true, reloadOnChange: true);
        }

        public static IConfigurationBuilder AddJsonConfigs(this IConfigurationBuilder configurationBuilder)
        {
            return configurationBuilder
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{ENVIRONMENT}.json", optional: true, reloadOnChange: true);
        }
    }
}
