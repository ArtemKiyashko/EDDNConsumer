using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDNModels.Common
{
    public partial class Header
    {
        /// <summary>
        /// Timestamp upon receipt at the gateway. If present, this property will be overwritten by
        /// the gateway; submitters are not intended to populate this property.
        /// </summary>
        [JsonProperty("gatewayTimestamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? GatewayTimestamp { get; set; }

        [JsonProperty("softwareName")]
        public string SoftwareName { get; set; }

        [JsonProperty("softwareVersion")]
        public string SoftwareVersion { get; set; }

        [JsonProperty("uploaderID")]
        public string UploaderId { get; set; }
    }
}
