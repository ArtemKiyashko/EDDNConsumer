using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using SharedLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Infrastructure
{
    public class CosmosDb : ICosmosDb
    {
        public CosmosDb(CosmosClient cosmosClient, IOptions<CosmosDbSettings> options)
        {
            Client = cosmosClient;
            Options = options;
        }

        public CosmosClient Client { get; }

        public IOptions<CosmosDbSettings> Options { get; }
    }
}
