using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDNModels.Common
{
    public partial class Entity<T>
    {
        [JsonProperty("$schemaRef")]
        public string SchemaRef { get; set; }

        [JsonProperty("header")]
        public Header Header { get; set; }

        /// <summary>
        /// Contains all properties from the listed events in the client's journal minus Localised
        /// strings and the properties marked below as 'disallowed'
        /// </summary>
        [JsonProperty("message")]
        public T Message { get; set; }
    }
}
