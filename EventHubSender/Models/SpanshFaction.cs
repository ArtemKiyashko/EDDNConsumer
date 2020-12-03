using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventHubSender.Models
{
    public class SpanshFaction
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("allegiance")]
        public string Allegiance { get; set; }
        [JsonProperty("government")]
        public string Government { get; set; }
        [JsonProperty("influence")]
        public float Influence { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
    }
}
