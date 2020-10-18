using System;
using EDDNModels.Common;
using EDDNModels.Journal;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace JournalContributor
{
    public static class JournalContributor
    {
        [FunctionName("ContributeJournal")]
        public static void Run(
            [QueueTrigger("journal", Connection = "AzureWebJobsStorage")]
            Entity<JournalMessage> myQueueItem,
            ILogger log,
            [CosmosDB(
                databaseName: "EDDN",
                collectionName: "Systems",
                ConnectionStringSetting = "CosmosDBConnectionString",
                CreateIfNotExists = true,
                CollectionThroughput = 50,
                PartitionKey = "/BodyType")]
            out JournalMessage systemDocument)
        {
            systemDocument = null;
            switch (myQueueItem.Message.Event)
            {
                case JournalEvent.FsdJump:
                    systemDocument = myQueueItem.Message;
                    break;
                default:
                    log.LogError($"Unknown Journal Event: {JsonConvert.SerializeObject(myQueueItem)}");
                    break;
            }
        }
    }
}
