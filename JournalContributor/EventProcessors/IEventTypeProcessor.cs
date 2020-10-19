using EDDNModels.Journal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JournalContributor.EventProcessors
{
    public interface IEventTypeProcessor
    {
        public Task ProcessEventAsync(JournalMessage message);
    }
}
