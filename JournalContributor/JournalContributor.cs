using System;
using EDDNModels.Common;
using EDDNModels.Journal;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using SharedLibrary.Extensions;

namespace JournalContributor
{
    public static class JournalContributor
    {
        [FunctionName("ContributeJournal")]
        public static void Run(
            [QueueTrigger("journal", Connection = "AzureWebJobsStorage")]
            Entity<JournalMessage> myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
