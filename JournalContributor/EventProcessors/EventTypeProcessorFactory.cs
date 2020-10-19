using EDDNModels.Journal;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace JournalContributor.EventProcessors
{
    public class EventTypeProcessorFactory : IEventTypeProcessorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public EventTypeProcessorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IEventTypeProcessor GetProcessor(JournalMessage journalMessage) => journalMessage.Event switch
        {
            JournalEvent.FsdJump => _serviceProvider.GetService<FsdJumpProcessor>(),
            JournalEvent.Scan => _serviceProvider.GetService<ScanProcessor>(),
            JournalEvent.Docked => _serviceProvider.GetService<DockedProcessor>(),
            JournalEvent.Location => _serviceProvider.GetService<LocationProcessor>(),
            JournalEvent.SaaSignalsFound => _serviceProvider.GetService<SaaSignalsFoundProcessor>(),
            JournalEvent.CarrierJump => _serviceProvider.GetService<DockedProcessor>(),
            _ => throw new ArgumentException($"Unknown Event {journalMessage.Event}", nameof(journalMessage.Event))
        };
    }
}
