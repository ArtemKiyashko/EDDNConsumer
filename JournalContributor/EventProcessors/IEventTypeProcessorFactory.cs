using EDDNModels.Journal;
using System;
using System.Collections.Generic;
using System.Text;

namespace JournalContributor.EventProcessors
{
    public interface IEventTypeProcessorFactory
    {
        IEventTypeProcessor GetProcessor(JournalMessage journalMessage);
    }
}
