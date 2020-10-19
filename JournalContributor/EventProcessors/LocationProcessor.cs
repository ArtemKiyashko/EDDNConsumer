using EDDNModels.Journal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JournalContributor.EventProcessors
{
    /// <summary>
    /// <see href="https://elite-journal.readthedocs.io/en/latest/Travel/#location">Location event</see> looks sensless for us as its covered by Scan event
    /// </summary>
    public class LocationProcessor : IEventTypeProcessor
    {
        public Task ProcessEventAsync(JournalMessage message)
        {
            return Task.CompletedTask;
        }
    }
}
