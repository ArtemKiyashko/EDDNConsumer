using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventHubSender.Models
{
    public class SignalsContainer
    {
        [JsonProperty("updateTime")]
        public DateTimeOffset UpdateTime { get; set; }

        [JsonProperty("signals")]
        public IDictionary<string, int> Signals { get; set; }
    }
}
