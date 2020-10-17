using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDDNModels.Journal
{
    public class StationEconomy
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Proportion")]
        public decimal Proportion { get; set; }
    }
}
