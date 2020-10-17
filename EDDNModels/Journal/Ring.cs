using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDDNModels.Journal
{
    public partial class Ring
    {
        [JsonProperty("InnerRad")]
        public long InnerRad { get; set; }

        [JsonProperty("MassMT")]
        public long MassMt { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("OuterRad")]
        public long OuterRad { get; set; }

        [JsonProperty("RingClass")]
        public string RingClass { get; set; }
    }
}
