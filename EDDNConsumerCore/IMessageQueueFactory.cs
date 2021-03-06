﻿using Azure.Storage.Queues;
using EDDNModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EDDNConsumerCore
{
    public interface IMessageQueueFactory
    {
        public Task<QueueClient> GetQueueAsync(Entity<BaseMessage> entity);
    }
}
