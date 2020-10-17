using EDDNModels.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDNModels.Journal
{

    /// <summary>
    /// Contains all properties from the listed events in the client's journal minus Localised
    /// strings and the properties marked below as 'disallowed'
    /// </summary>
    public partial class JournalMessage : BaseMessage
    {
        [JsonProperty("event")]
        public JournalEvent Event { get; set; }

        [JsonProperty("AbsoluteMagnitude")]
        public double? AbsoluteMagnitude { get; set; }

        [JsonProperty("Age_MY")]
        public long? AgeMy { get; set; }

        [JsonProperty("AxialTilt")]
        public double? AxialTilt { get; set; }

        [JsonProperty("BodyName")]
        public string BodyName { get { return Body; } set { Body = value; } }

        [JsonProperty("DistanceFromArrivalLS")]
        public double? DistanceFromArrivalLs { get; set; }

        [JsonProperty("Eccentricity")]
        public double? Eccentricity { get; set; }

        [JsonProperty("Luminosity")]
        public string Luminosity { get; set; }

        [JsonProperty("OrbitalInclination")]
        public double? OrbitalInclination { get; set; }

        [JsonProperty("OrbitalPeriod")]
        public double? OrbitalPeriod { get; set; }

        [JsonProperty("Parents")]
        public IList<Dictionary<string, uint>> Parents { get; set; }

        [JsonProperty("Periapsis")]
        public double? Periapsis { get; set; }

        [JsonProperty("Radius")]
        public double? Radius { get; set; }

        [JsonProperty("Rings")]
        public IList<Ring> Rings { get; set; }

        [JsonProperty("RotationPeriod")]
        public double? RotationPeriod { get; set; }

        [JsonProperty("ScanType")]
        public string ScanType { get; set; }

        [JsonProperty("SemiMajorAxis")]
        public double? SemiMajorAxis { get; set; }

        [JsonProperty("StarType")]
        public string StarType { get; set; }

        [JsonProperty("StellarMass")]
        public double? StellarMass { get; set; }

        [JsonProperty("Subclass")]
        public long? Subclass { get; set; }

        [JsonProperty("SurfaceTemperature")]
        public double? SurfaceTemperature { get; set; }

        [JsonProperty("WasDiscovered")]
        public bool? WasDiscovered { get; set; }

        [JsonProperty("WasMapped")]
        public bool? WasMapped { get; set; }

        [JsonProperty("Body")]
        public string Body { get; set; }

        [JsonProperty("BodyType")]
        public string BodyType { get; set; }

        [JsonProperty("Population")]
        public long? Population { get; set; }

        [JsonProperty("SystemAllegiance")]
        public string SystemAllegiance { get; set; }

        [JsonProperty("SystemEconomy")]
        public string SystemEconomy { get; set; }

        [JsonProperty("SystemGovernment")]
        public string SystemGovernment { get; set; }

        [JsonProperty("SystemSecondEconomy")]
        public string SystemSecondEconomy { get; set; }

        [JsonProperty("SystemFaction")]
        public SystemFaction SystemFaction { get; set; }

        [JsonProperty("SystemSecurity")]
        public string SystemSecurity { get; set; }

        [JsonProperty("Atmosphere")]
        public string Atmosphere { get; set; }

        [JsonProperty("AtmosphereType")]
        public string AtmosphereType { get; set; }

        [JsonProperty("Composition")]
        public Dictionary<string, double> Composition { get; set; }

        [JsonProperty("Landable")]
        public bool? Landable { get; set; }

        [JsonProperty("MassEM")]
        public double? MassEm { get; set; }

        [JsonProperty("Materials")]
        public IList<Material> Materials { get; set; }

        [JsonProperty("PlanetClass")]
        public string PlanetClass { get; set; }

        [JsonProperty("SurfaceGravity")]
        public double? SurfaceGravity { get; set; }

        [JsonProperty("SurfacePressure")]
        public long? SurfacePressure { get; set; }

        [JsonProperty("TerraformState")]
        public string TerraformState { get; set; }

        [JsonProperty("TidalLock")]
        public bool? TidalLock { get; set; }

        [JsonProperty("Volcanism")]
        public string Volcanism { get; set; }

        [JsonProperty("BodyID")]
        public uint BodyID { get; set; }

        [JsonProperty("ActiveFine")]
        public object ActiveFine { get; set; }

        [JsonProperty("BoostUsed")]
        public object BoostUsed { get; set; }

        [JsonProperty("CockpitBreach")]
        public object CockpitBreach { get; set; }

        /// <summary>
        /// Present in Location, FSDJump and CarrierJump messages
        /// </summary>
        [JsonProperty("Factions")]
        public IList<Faction> Factions { get; set; }

        [JsonProperty("FuelLevel")]
        public object FuelLevel { get; set; }

        [JsonProperty("FuelUsed")]
        public object FuelUsed { get; set; }

        [JsonProperty("JumpDist")]
        public object JumpDist { get; set; }

        [JsonProperty("Latitude")]
        public object Latitude { get; set; }

        [JsonProperty("Longitude")]
        public object Longitude { get; set; }

        /// <summary>
        /// Must be added by the sender if not present in the journal event
        /// </summary>
        [JsonProperty("StarPos")]
        public double[] StarPos { get; set; }

        /// <summary>
        /// Must be added by the sender if not present in the journal event
        /// </summary>
        [JsonProperty("StarSystem")]
        [MinLength(1)]
        public string StarSystem { get; set; }

        /// <summary>
        /// Should be added by the sender if not present in the journal event
        /// </summary>
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; set; }

        [JsonProperty("Wanted")]
        public object Wanted { get; set; }

        [JsonProperty("AtmosphereComposition")]
        public IList<AtmosphereComposition> AtmosphereComposition { get; set; }

        [JsonProperty("ReserveLevel")]
        public string ReserveLevel { get; set; }

        [JsonProperty("Conflicts")]
        public IList<Conflict> Conflicts { get; set; }

        [JsonProperty("DistFromStarLS")]
        public double? DistFromStarLs { get; set; }

        [JsonProperty("MarketID")]
        public long? MarketId { get; set; }

        [JsonProperty("StationEconomies")]
        public IList<StationEconomy> StationEconomies { get; set; }

        [JsonProperty("StationEconomy")]
        public string StationEconomy { get; set; }

        [JsonProperty("StationFaction")]
        public StationFaction StationFaction { get; set; }

        [JsonProperty("StationGovernment")]
        public string StationGovernment { get; set; }

        [JsonProperty("StationName")]
        public string StationName { get; set; }

        [JsonProperty("StationServices")]
        public IList<string> StationServices { get; set; }

        [JsonProperty("StationType")]
        public string StationType { get; set; }

        [JsonProperty("StationAllegiance")]
        public string StationAllegiance { get; set; }

        [JsonProperty("PowerplayState")]
        public string PowerplayState { get; set; }

        [JsonProperty("Powers")]
        public IList<string> Powers { get; set; }

        [JsonProperty("Signals")]
        public IList<Signal> Signals { get; set; }

        [JsonProperty("Docked")]
        public bool? Docked { get; set; }
    }
}
