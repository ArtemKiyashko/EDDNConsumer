using EDDNModels.Journal;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using SharedLibrary.Infrastructure;
using SharedLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JournalContributor.EventProcessors
{
    /// <summary>
    /// Use for Signals collection. <see href="https://elite-journal.readthedocs.io/en/latest/Exploration/#saasignalsfound">Event description</see>
    /// </summary>
    public class SaaSignalsFoundProcessor : IEventTypeProcessor
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _signalsContainer;
        private readonly CosmosDbSettings _options;

        public SaaSignalsFoundProcessor(ICosmosDb cosmosDb)
        {
            _cosmosClient = cosmosDb.Client;
            _options = cosmosDb.Options.Value;
            _signalsContainer = _cosmosClient.GetContainer(_options.DbName, _options.SignalsCollection.Name);
        }

        public async Task ProcessEventAsync(JournalMessage message)
        {
            await _signalsContainer.UpsertItemAsync(message, new PartitionKey(message.StarSystem));
        }
    }
}
