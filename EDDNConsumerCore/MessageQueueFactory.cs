using Azure.Storage.Queues;
using EDDNConsumerCore.Settings;
using EDDNModels.Common;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EDDNConsumerCore
{
    public class MessageQueueFactory : IMessageQueueFactory
    {
        private readonly StorageAccount _storageOptions;
        private readonly QueueMapping _queueMapping;
        private readonly IDictionary<string, QueueClient> _queues = new Dictionary<string, QueueClient>();

        public MessageQueueFactory(
            IOptions<StorageAccount> storageOptions,
            IOptions<QueueMapping> queueMapping)
        {
            _storageOptions = storageOptions.Value;
            _queueMapping = queueMapping.Value;
        }

        public async Task<QueueClient> GetQueueAsync(Entity<BaseMessage> entity)
        {
            if (_queueMapping.TryGetValue(entity.SchemaRef, out var queueName))
            {
                if (!_queues.ContainsKey(queueName))
                {
                    var client = new QueueClient(_storageOptions.StorageConnectionString, queueName);
                    await client.CreateIfNotExistsAsync();
                    _queues.Add(queueName, client);
                }
                return _queues[queueName];
            }
            throw new ArgumentException($"Queue {entity.SchemaRef} has not configured", nameof(entity.SchemaRef));
        }
    }
}
