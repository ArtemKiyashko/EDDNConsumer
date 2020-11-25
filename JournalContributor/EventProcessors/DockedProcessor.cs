﻿using EDDNModels.Journal;
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
    /// Use for Stations collection. <see href="https://elite-journal.readthedocs.io/en/latest/Travel/#docked">Event description</see><br/>
    /// <see href="https://elite-journal.readthedocs.io/en/latest/Fleet%20Carriers/#carrierjump">CarrierJump event</see> provide similar information (actually it`s just moving stations) 
    /// </summary>
    public class DockedProcessor : IEventTypeProcessor
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _stationsContainer;
        private readonly CosmosDbSettings _options;
        public DockedProcessor(ICosmosDb cosmosDb)
        {
            _cosmosClient = cosmosDb.Client;
            _options = cosmosDb.Options.Value;
            _stationsContainer = _cosmosClient.GetContainer(_options.DbName, _options.StationsCollection.Name);
        }

        public async Task ProcessEventAsync(JournalMessage message)
        {
            await _stationsContainer.UpsertItemAsync(message, new PartitionKey(message.StarSystem));
        }
    }
}
