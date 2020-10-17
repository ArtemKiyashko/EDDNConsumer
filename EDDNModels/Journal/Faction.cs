using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDNModels.Journal
{
    public partial class Faction
    {
        [JsonProperty("HappiestSystem")]
        public object HappiestSystem { get; set; }

        [JsonProperty("HomeSystem")]
        public object HomeSystem { get; set; }

        [JsonProperty("MyReputation")]
        public object MyReputation { get; set; }

        [JsonProperty("SquadronFaction")]
        public object SquadronFaction { get; set; }

        [JsonProperty("Allegiance")]
        public string Allegiance { get; set; }

        [JsonProperty("FactionState")]
        public string FactionState { get; set; }

        [JsonProperty("Government")]
        public string Government { get; set; }

        [JsonProperty("Happiness")]
        public string Happiness { get; set; }

        [JsonProperty("Influence")]
        public double Influence { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ActiveStates")]
        public IList<FactionActiveState> ActiveStates { get; set; }

        [JsonProperty("RecoveringStates")]
        public IList<FactionRecoveringState> RecoveringStates { get; set; }

        [JsonProperty("PendingStates")]
        public IList<FactionPendingState> PendingStates { get; set; }
    }
}
