using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDDNModels.Common
{
    public class BaseMessage
    {

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }
    }
}
