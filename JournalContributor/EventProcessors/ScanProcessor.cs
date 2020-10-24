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
            var existingItemResponse = await message.CheckIfItemExists(_bodiesContainer, message.StarSystem);
            if (existingItemResponse == null)
                await CreateItem(message);
            else
                await UpdateItem(message, existingItemResponse);
        }

        private async Task CreateItem(JournalMessage message)
        {
            try
            {
                await _bodiesContainer.CreateItemAsync(message, new PartitionKey(message.StarSystem));
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                await ProcessEventAsync(message);
            }
        }

        private async Task UpdateItem(JournalMessage message, ItemResponse<JournalMessage> existingItemResponse)
        {
            if (message.ScanType <= existingItemResponse.Resource.ScanType)
                return;
            try
            {
                await _bodiesContainer.UpsertItemAsync(message, new PartitionKey(message.StarSystem), new ItemRequestOptions { IfMatchEtag = existingItemResponse.ETag });
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.PreconditionFailed)
            {
                await ProcessEventAsync(message);
            }
        }
    }
}
