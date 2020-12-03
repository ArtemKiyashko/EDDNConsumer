using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventHubSender.Models
{
    public class SpanshBody
    {
        [JsonProperty("reserveLevel")]
        public string ReserveLevel { get; set; }

        [JsonProperty("parents")]
        public IList<Dictionary<string, uint>> Parents { get; set; }

        [JsonProperty("atmosphereType")]
        public string AtmosphereTypeShort { get; set; }

        [JsonProperty("surfacePressure")]
        public long? SurfacePressureAtm { get; set; }

        [JsonProperty("axialTilt")]
        public double? AxialTilt { get; set; }

        [JsonProperty("argOfPeriapsis")]
        public double? Periapsis { get; set; }

        [JsonProperty("orbitalInclination")]
        public double? OrbitalInclination { get; set; }

        [JsonProperty("rotationalPeriod")]
        public double? RotationPeriodDays { get; set; }

        [JsonProperty("semiMajorAxis")]
        public double? SemiMajorAxisAu { get; set; }

        [JsonProperty("orbitalPeriod")]
        public double? OrbitalPeriodDays { get; set; }

        [JsonProperty("surfaceTemperature")]
        public double? SurfaceTemperature { get; set; }

        [JsonProperty("solarRadius")]
        public double? SolarRadius { get; set; }

        [JsonProperty("radius")]
        public double? BodyRadiusKm { get; set; }

        [JsonProperty("solarMasses")]
        public double? StellarMass { get; set; }

        [JsonProperty("absoluteMagnitude")]
        public double? AbsoluteMagnitude { get; set; }

        [JsonProperty("luminosity")]
        public string Luminosity { get; set; }

        [JsonProperty("spectralClass")]
        public string SpectralClass { get; set; }

        [JsonProperty("bodyId")]
        public uint BodyID { get; set; }

        [JsonProperty("age")]
        public long? AgeMy { get; set; }

        [JsonProperty("mainStar")]
        public bool? MainStar { get; set; }

        [JsonProperty("distanceToArrival")]
        public double? DistanceFromArrivalLs { get; set; }

        [JsonProperty("subType")]
        public string SubType { get; set; }

        [JsonProperty("type")]
        public string BodyType { get; set; }

        [JsonProperty("name")]
        public string BodyName { get; set; }

        [JsonProperty("id64")]
        public long? Id64 { get; set; }

        [JsonProperty("updateTime")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("rotationalPeriodTidallyLocked")]
        public bool? TidalLock { get; set; }

        [JsonProperty("orbitalEccentricity")]
        public double? Eccentricity { get; set; }

        [JsonProperty("terraformingState")]
        public string TerraformState { get; set; }

        [JsonProperty("volcanismType")]
        public string Volcanism { get; set; }

        [JsonProperty("earthMasses")]
        public double? MassEm { get; set; }

        [JsonProperty("isLandable")]
        public bool? Landable { get; set; }

        [JsonProperty("gravity")]
        public double? SurfaceGravityG { get; set; }

        [JsonProperty("atmosphereComposition")]
        public IDictionary<string, double> AtmosphereComposition { get; set; }

        [JsonProperty("solidComposition")]
        public IDictionary<string, double> SolidComposition { get; set; }

        [JsonProperty("materials")]
        public IDictionary<string, double> Materials { get; set; }

        [JsonProperty("signals")]
        public SignalsContainer Signals { get; set; }

        [JsonProperty("stations")]
        public IList<SpanshStation> Stations { get; set; }

        [JsonProperty("rings")]
        public IList<SpanshRing> Rings { get; set; }

        [JsonProperty("belts")]
        public IList<SpanshRing> Belts { get; set; }
    }
}
