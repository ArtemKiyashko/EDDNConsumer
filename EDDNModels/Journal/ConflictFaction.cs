using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDDNModels.Journal
{
    public class ConflictFaction
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Stake")]
        public string Stake { get; set; }

        [JsonProperty("WonDays")]
        public int WonDays { get; set; }
    }
}
