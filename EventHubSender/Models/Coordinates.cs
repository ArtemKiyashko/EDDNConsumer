using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventHubSender.Models
{
    public class Coordinates
    {
        [JsonProperty("x")]
        public double X { get; set; }
        [JsonProperty("y")]
        public double Y { get; set; }
        [JsonProperty("z")]
        public double Z { get; set; }
    }
}
