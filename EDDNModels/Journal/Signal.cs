using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDDNModels.Journal
{
    public class Signal
    {
        [JsonProperty("Count")]
        public uint Count { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }
    }
}
