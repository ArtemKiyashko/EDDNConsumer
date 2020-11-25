using EDDNModels.Extensions;
using EDDNModels.Journal;
using Microsoft.Azure.Cosmos;
using SharedLibrary.Infrastructure;
using SharedLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JournalContributor.EventProcessors
{
    /// <summary>
    /// Use for Systems collection. <see href="https://elite-journal.readthedocs.io/en/latest/Travel/#fsdjump">Event description</see>
    /// </summary>
    public class FsdJumpProcessor : IEventTypeProcessor
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _systemsContainer;
        private readonly CosmosDbSettings _options;

        public FsdJumpProcessor(ICosmosDb cosmosDb)
        {
            _cosmosClient = cosmosDb.Client;
            _options = cosmosDb.Options.Value;
            _systemsContainer = _cosmosClient.GetContainer(_options.DbName, _options.SystemsCollection.Name);
        }

        public async Task ProcessEventAsync(JournalMessage message)
        {
            message.Region = RegionMap.FindRegion(message.StarPos[0], message.StarPos[1], message.StarPos[2]);
            await _systemsContainer.UpsertItemAsync(message, message.Region == null ? PartitionKey.None : new PartitionKey(message.Region.Name));
        }
    }
}
