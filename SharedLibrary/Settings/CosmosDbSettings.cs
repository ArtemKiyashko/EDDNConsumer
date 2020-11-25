using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SharedLibrary.Settings
{
    public class CosmosDbSettings
    {
        public string DbName { get; set; }
        public CollectionSettings BodiesCollection { get; set; }
        public CollectionSettings SystemsCollection { get; set; }
        public CollectionSettings StationsCollection { get; set; }
        public CollectionSettings SignalsCollection { get; set; }
        public bool AllowBulkExecution { get; set; }
        [JsonIgnore]
        public TimeSpan RequestTimeout {
            get
            {
                return TimeSpan.FromSeconds(_requestTimeout);
            }
            set
            {
                _requestTimeout = value.Seconds;
            }
        }

        [JsonProperty("RequestTimeout")]
        [DefaultValue(60)]
        private int _requestTimeout { get; set; }
    }
}
