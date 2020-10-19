using System;
using System.Threading.Tasks;
using EDDNModels.Common;
using EDDNModels.Journal;
using JournalContributor.EventProcessors;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace JournalContributor
{
    public class JournalContributor
    {
        private readonly IEventTypeProcessorFactory _eventTypeProcessorFactory;

        public JournalContributor(IEventTypeProcessorFactory eventTypeProcessorFactory)
        {
            _eventTypeProcessorFactory = eventTypeProcessorFactory;
        }

        [FunctionName("ContributeJournal")]
        public async Task Run(
            [QueueTrigger("journal", Connection = "AzureWebJobsStorage")]
            Entity<JournalMessage> myQueueItem,
            ILogger log)
        {
            try
            {
                var eventProcessor = _eventTypeProcessorFactory.GetProcessor(myQueueItem.Message);
                await eventProcessor.ProcessEventAsync(myQueueItem.Message);
            }
            catch(Exception ex)
            {
                log.LogError(ex, $"Error processing queue item: {JsonConvert.SerializeObject(myQueueItem)}");
                throw;
            }
        }
    }
}
