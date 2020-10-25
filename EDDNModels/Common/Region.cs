using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDDNModels.Common
{
    public class Region
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
