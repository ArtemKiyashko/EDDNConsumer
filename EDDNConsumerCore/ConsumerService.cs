using EDDNConsumerCore.Settings;
using Ionic.Zlib;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetMQ;
using NetMQ.Sockets;
using SharedLibrary.Infrastructure;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EDDNConsumerCore
{
    public class ConsumerService : IHostedService
    {
        private readonly ILogger<ConsumerService> _logger;
        private readonly IMessageDistributor _messageDistributor;
        private readonly EddnClientSettings _eddnClientSettings;

        public ConsumerService(
            ILogger<ConsumerService> logger,
            IMessageDistributor messageDistributor,
            IOptions<EddnClientSettings> eddnClientSettings)
        {
            _logger = logger;
            _messageDistributor = messageDistributor;
            _eddnClientSettings = eddnClientSettings.Value;
        }

        private async Task ClientAsync()
        {
            var utf8 = new UTF8Encoding();
            using (var client = new SubscriberSocket())
            {
                client.Connect(_eddnClientSettings.ConnectionString);
                client.SubscribeToAnyTopic();
                while (true)
                {
                    try
                    {
                        (var bytes, _) = await client.ReceiveFrameBytesAsync();
                        var uncompressed = ZlibStream.UncompressBuffer(bytes);
                        var result = utf8.GetString(uncompressed);
                        await _messageDistributor.DistributeAsync(result);
                        _logger.LogInformation(result);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error reading message queue");
                    }
                }
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {

            using (var runtime = new NetMQRuntime())
            {
                runtime.Run(ClientAsync());
            }
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
