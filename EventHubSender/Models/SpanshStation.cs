using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventHubSender.Models
{
    public class SpanshStation
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("controllingFaction")]
        public string ControllingFaction { get; set; }

        [JsonProperty("controllingFactionState")]
        public string ControllingFactionState { get; set; }

        [JsonProperty("distanceToArrival")]
        public double? DistanceFromArrivalLs { get; set; }

        [JsonProperty("secondaryEconomy")]
        public string StationSecondEconomy { get; set; }

        [JsonProperty("primaryEconomy")]
        public string StationEconomy { get; set; }

        [JsonProperty("government")]
        public string StationGovernment { get; set; }

        [JsonProperty("allegiance")]
        public string StationAllegiance { get; set; }

        [JsonProperty("services")]
        public IEnumerable<string> Services { get; set; }

        [JsonProperty("type")]
        public string StationType { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("updateTime")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonIgnore]
        public SpanshMarket Market { get; set; }

        [JsonIgnore]
        public SpanshOutfitting Outfitting { get; set; }

        [JsonIgnore]
        public SpanshShipyard Shipyard { get; set; }
    }
}
