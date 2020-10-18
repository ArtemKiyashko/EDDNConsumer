using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDNModels.Journal
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum JournalEvent {
        CarrierJump,
        Docked,
        FsdJump,
        Location,
        SaaSignalsFound,
        Scan
    };
}
