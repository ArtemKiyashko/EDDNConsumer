using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using EventHubSender.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventHubSender
{
    public class EventSenderService : IHostedService
    {
        private readonly EventHubProducerClient _eventHubProducerClient;
        private readonly long _maxBytesInBatch;
        private readonly ILogger<EventSenderService> _logger;
        private readonly IDataReader<IEnumerable<SpanshSystem>> _dataReader;

        public EventSenderService(
            EventHubProducerClient eventHubProducerClient,
            long maxBytesInBatch,
            IDataReader<IEnumerable<SpanshSystem>> dataReader,
            ILogger<EventSenderService> logger)
        {
            _eventHubProducerClient = eventHubProducerClient;
            _maxBytesInBatch = maxBytesInBatch;
            _logger = logger;
            _dataReader = dataReader;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var modelsRead = 0;
            var dataBatch = await _eventHubProducerClient.CreateBatchAsync(new CreateBatchOptions() { MaximumSizeInBytes = _maxBytesInBatch });
            var models = _dataReader.ReadData();
            foreach (var model in models)
            {
                _logger.LogInformation($"Models read: {modelsRead++}");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
