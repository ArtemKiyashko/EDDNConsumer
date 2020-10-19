using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDDNModels.Journal
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ScanType
    {
        Basic,
        Detailed,
        NavBeacon,
        NavBeaconDetail,
        AutoScan
    }
}
