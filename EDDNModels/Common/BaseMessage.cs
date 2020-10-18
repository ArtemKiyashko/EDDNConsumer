﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDDNModels.Common
{
    public abstract class BaseMessage
    {

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }
        [JsonProperty("id")]
        public virtual string Id { get; set; }
    }
}
