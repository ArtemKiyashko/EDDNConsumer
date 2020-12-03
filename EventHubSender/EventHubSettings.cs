using System;
using System.Collections.Generic;
using System.Text;

namespace EventHubSender
{
    public class EventHubSettings
    {
        public string ConnectionString { get; set; }
        public string EventHubName { get; set; }
    }
}
