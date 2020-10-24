using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JournalContributor.Extensions;
using EDDNModels.Journal;
using Microsoft.Extensions.Options;
using JournalContributor.Settings;

namespace JournalContributor.EventProcessors
{
    /// <summary>
    /// Use for Bodies collection. <see href="https://elite-journal.readthedocs.io/en/latest/Exploration/#scan">Event description</see>
    /// </summary>
    public class ScanProcessor : IEventTypeProcessor
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _bodiesContainer;
        private readonly CosmosDbSettings _options;

        public ScanProcessor(CosmosClient cosmosClient, IOptions<CosmosDbSettings> options)
        {
            _cosmosClient = cosmosClient;
            _options = options.Value;
            _bodiesContainer = _cosmosClient.GetContainer(_options.DbName, _options.BodiesCollection.Name);
        }

        public async Task ProcessEventAsync(JournalMessage message)
        {
            var existingItem = await message.CheckIfItemExists(_bodiesContainer, message.StarSystem);
            if (existingItem == null)
            {
                await _bodiesContainer.UpsertItemAsync(message, new PartitionKey(message.StarSystem));
            }
            else
            {
                //Basic scan type contains less information then others.
                //We`re skipping item upsert if remote item has scan type higher then Basic
                //We`re also skippings if remote item scan type is Detailed (as it`s a maximum info scan)
                //Will update item if both (remote and current) have scan type Basic
                //And will upsert item in case of current item have higher scan type then remote
                if ((message.ScanType == ScanType.Basic && existingItem.ScanType != ScanType.Basic) ||
                    existingItem.ScanType == ScanType.Detailed)
                    return;
                else
                {
                    await _bodiesContainer.UpsertItemAsync(message, new PartitionKey(message.StarSystem));
                }
            }
        }
    }
}
