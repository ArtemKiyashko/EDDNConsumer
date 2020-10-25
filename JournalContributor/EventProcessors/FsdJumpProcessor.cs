using EDDNModels.Journal;
using JournalContributor.Settings;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
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

        public FsdJumpProcessor(CosmosClient cosmosClient, IOptions<CosmosDbSettings> options)
        {
            _cosmosClient = cosmosClient;
            _options = options.Value;
            _systemsContainer = _cosmosClient.GetContainer(_options.DbName, _options.SystemsCollection.Name);
        }

        public async Task ProcessEventAsync(JournalMessage message)
        {
            await _systemsContainer.UpsertItemAsync(message);
        }
    }
}
