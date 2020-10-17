using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDNModels.Journal
{
    public enum JournalEvent {
        CarrierJump,
        Docked,
        FsdJump,
        Location,
        SaaSignalsFound,
        Scan
    };
}
