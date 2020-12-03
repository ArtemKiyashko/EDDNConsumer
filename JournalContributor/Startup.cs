using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Cosmos;
using JournalContributor.EventProcessors;
using Microsoft.Extensions.Configuration;
using System.IO;
using SharedLibrary.Extensions;

[assembly: FunctionsStartup(typeof(JournalContributor.Startup))]

namespace JournalContributor
{
    public class Startup : FunctionsStartup
    {
        private IConfigurationRoot _functionConfig;

        public override void Configure(IFunctionsHostBuilder builder)
        {
            _functionConfig = new ConfigurationBuilder().AddJsonConfigs(builder).Build();
            builder.Services.AddSingleton<IEventTypeProcessorFactory, EventTypeProcessorFactory>();
            builder.Services.AddTransient<FsdJumpProcessor>();
            builder.Services.AddTransient<ScanProcessor>();
            builder.Services.AddTransient<DockedProcessor>();
            builder.Services.AddTransient<LocationProcessor>();
            builder.Services.AddTransient<SaaSignalsFoundProcessor>();
            builder.Services.ConfigureCosmosServices(_functionConfig);
        }
    }
}
