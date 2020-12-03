using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventHubSender.Models
{
    public class SpanshRing
    {
        [JsonProperty("innerRadius")]
        public long InnerRad { get; set; }

        [JsonProperty("mass")]
        public long MassMt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("outerRadius")]
        public long OuterRad { get; set; }

        [JsonProperty("type")]
        public string RingType { get; set; }

        [JsonProperty("signals")]
        public SignalsContainer Signals { get; set; }
    }
}
