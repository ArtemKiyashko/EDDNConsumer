using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDDNModels.Journal
{
    public class Conflict
    {
        [JsonProperty("Faction1")]
        public ConflictFaction Faction1 { get; set; }

        [JsonProperty("Faction2")]
        public ConflictFaction Faction2 { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("WarType")]
        public string WarType { get; set; }
    }
}
