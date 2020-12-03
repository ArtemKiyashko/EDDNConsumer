using EDDNModels.Journal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventHubSender.Models
{
    public class SpanshSystem
    {
        [JsonProperty("powerState")]
        public string PowerplayState { get; set; }

        [JsonProperty("powers")]
        public IList<string> Powers { get; set; }

        [JsonProperty("factions")]
        public IEnumerable<SpanshFaction> Factions { get; set; }

        [JsonProperty("controllingFaction")]
        public SpanshFaction ControllingFaction { get; set; }

        [JsonProperty("name")]
        public string SystemName { get; set; }

        [JsonProperty("id64")]
        public long? Id64 { get; set; }

        [JsonProperty("Population")]
        public long? Population { get; set; }

        [JsonProperty("security")]
        public string SystemSecurity { get; set; }

        [JsonProperty("secondaryEconomy")]
        public string SystemSecondEconomy { get; set; }

        [JsonProperty("primaryEconomy")]
        public string SystemEconomy { get; set; }

        [JsonProperty("government")]
        public string SystemGovernment { get; set; }

        [JsonProperty("allegiance")]
        public string SystemAllegiance { get; set; }

        [JsonProperty("coords")]
        public Coordinates Coordinates { get; set; }

        [JsonProperty("bodies")]
        public IList<SpanshBody> Bodies { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("stations")]
        public IList<SpanshStation> Stations { get; set; }
    }
}
