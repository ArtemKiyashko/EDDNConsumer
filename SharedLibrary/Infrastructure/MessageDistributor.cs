using EDDNModels.Common;
using EDDNModels.Journal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary.Extensions;

namespace SharedLibrary.Infrastructure
{
    public class MessageDistributor : IMessageDistributor
    {
        private readonly JsonSerializer _serializer;
        private readonly ILogger<MessageDistributor> _logger;
        private readonly IMessageQueueFactory _messageQueueFactory;

        public MessageDistributor(
            ILogger<MessageDistributor> logger,
            IMessageQueueFactory messageQueueFactory)
        {
            _serializer = new JsonSerializer();
            _serializer.MissingMemberHandling = MissingMemberHandling.Ignore;
            _serializer.NullValueHandling = NullValueHandling.Ignore;
            _logger = logger;
            _messageQueueFactory = messageQueueFactory;
        }

        public async Task DistributeAsync(string message)
        {
            try
            {
                using var stringReader = new StringReader(message);
                using var jsonReader = new JsonTextReader(stringReader);
                var result = _serializer.Deserialize<Entity<BaseMessage>>(jsonReader);
                var queue = await _messageQueueFactory.GetQueueAsync(result);
                await queue.SendMessageAsync(message.Base64Encode());
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error distributing message");
            }
        }
    }
}
