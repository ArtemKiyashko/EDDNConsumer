using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using SharedLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Infrastructure
{
    public interface ICosmosDb
    {
        CosmosClient Client { get; }
        IOptions<CosmosDbSettings> Options { get; }
    }
}
