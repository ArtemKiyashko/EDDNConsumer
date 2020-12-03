using EDDNModels.Journal;
using EventHubSender.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventHubSender.Adapters
{
    public class SpanshToEddnModelAdapter : IModelAdapter<SpanshSystem, IEnumerable<JournalMessage>>
    {
        public IEnumerable<JournalMessage> Adapt(SpanshSystem input)
        {
            throw new NotImplementedException();
        }
    }
}
