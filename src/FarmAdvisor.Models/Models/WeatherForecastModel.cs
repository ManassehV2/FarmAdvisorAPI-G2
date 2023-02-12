namespace FarmAdvisor.Models.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class WeatherForecastModel
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }

        [JsonProperty("properties")]
        public Properties Properties { get; set; }
    }

    public partial class Geometry
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }
    }

    public partial class Properties
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("timeseries")]
        public List<Timesery> Timeseries { get; set; }
    }

    public partial class Meta
    {
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("units")]
        public Units Units { get; set; }
    }

    public partial class Units
    {
        [JsonProperty("air_pressure_at_sea_level")]
        public string AirPressureAtSeaLevel { get; set; }

        [JsonProperty("air_temperature")]
        public string AirTemperature { get; set; }

        [JsonProperty("air_temperature_max")]
        public string AirTemperatureMax { get; set; }

        [JsonProperty("air_temperature_min")]
        public string AirTemperatureMin { get; set; }

        [JsonProperty("cloud_area_fraction")]
        public string CloudAreaFraction { get; set; }

        [JsonProperty("cloud_area_fraction_high")]
        public string CloudAreaFractionHigh { get; set; }

        [JsonProperty("cloud_area_fraction_low")]
        public string CloudAreaFractionLow { get; set; }

        [JsonProperty("cloud_area_fraction_medium")]
        public string CloudAreaFractionMedium { get; set; }

        [JsonProperty("dew_point_temperature")]
        public string DewPointTemperature { get; set; }

        [JsonProperty("fog_area_fraction")]
        public string FogAreaFraction { get; set; }

        [JsonProperty("precipitation_amount")]
        public string PrecipitationAmount { get; set; }

        [JsonProperty("relative_humidity")]
        public string RelativeHumidity { get; set; }

        [JsonProperty("ultraviolet_index_clear_sky")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long UltravioletIndexClearSky { get; set; }

        [JsonProperty("wind_from_direction")]
        public string WindFromDirection { get; set; }

        [JsonProperty("wind_speed")]
        public string WindSpeed { get; set; }
    }

    public partial class Timesery
    {
        [JsonProperty("time")]
        public DateTimeOffset Time { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("instant")]
        public Instant Instant { get; set; }

        [JsonProperty("next_12_hours", NullValueHandling = NullValueHandling.Ignore)]
        public Next12_Hours Next12_Hours { get; set; }

        [JsonProperty("next_1_hours", NullValueHandling = NullValueHandling.Ignore)]
        public Next1_Hours Next1_Hours { get; set; }

        [JsonProperty("next_6_hours", NullValueHandling = NullValueHandling.Ignore)]
        public Next6_Hours Next6_Hours { get; set; }
    }

    public partial class Instant
    {
        [JsonProperty("details")]
        public Dictionary<string, double> Details { get; set; }
    }

    public partial class Next12_Hours
    {
        [JsonProperty("summary")]
        public Summary Summary { get; set; }
    }

    public partial class Summary
    {
        [JsonProperty("symbol_code")]
        public SymbolCode SymbolCode { get; set; }
    }

    public partial class Next1_Hours
    {
        [JsonProperty("summary")]
        public Summary Summary { get; set; }

        [JsonProperty("details")]
        public Next1_HoursDetails Details { get; set; }
    }

    public partial class Next1_HoursDetails
    {
        [JsonProperty("precipitation_amount")]
        public double PrecipitationAmount { get; set; }
    }

    public partial class Next6_Hours
    {
        [JsonProperty("summary")]
        public Summary Summary { get; set; }

        [JsonProperty("details")]
        public Next6_HoursDetails Details { get; set; }
    }

    public partial class Next6_HoursDetails
    {
        [JsonProperty("air_temperature_max")]
        public double AirTemperatureMax { get; set; }

        [JsonProperty("air_temperature_min")]
        public double AirTemperatureMin { get; set; }

        [JsonProperty("precipitation_amount")]
        public double PrecipitationAmount { get; set; }
    }

    public enum SymbolCode
    {
        Cloudy,
        Heavyrain,
        HeavyrainshowersDay,
        HeavyrainshowersNight,
        Lightrain,
        LightrainshowersDay,
        PartlycloudyDay,
        PartlycloudyNight,
        Rain,
        RainshowersDay
    };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                SymbolCodeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(
            JsonReader reader,
            Type t,
            object existingValue,
            JsonSerializer serializer
        )
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(
            JsonWriter writer,
            object untypedValue,
            JsonSerializer serializer
        )
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class SymbolCodeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) =>
            t == typeof(SymbolCode) || t == typeof(SymbolCode?);

        public override object ReadJson(
            JsonReader reader,
            Type t,
            object existingValue,
            JsonSerializer serializer
        )
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "cloudy":
                    return SymbolCode.Cloudy;
                case "heavyrain":
                    return SymbolCode.Heavyrain;
                case "heavyrainshowers_day":
                    return SymbolCode.HeavyrainshowersDay;
                case "heavyrainshowers_night":
                    return SymbolCode.HeavyrainshowersNight;
                case "lightrain":
                    return SymbolCode.Lightrain;
                case "lightrainshowers_day":
                    return SymbolCode.LightrainshowersDay;
                case "partlycloudy_day":
                    return SymbolCode.PartlycloudyDay;
                case "partlycloudy_night":
                    return SymbolCode.PartlycloudyNight;
                case "rain":
                    return SymbolCode.Rain;
                case "rainshowers_day":
                    return SymbolCode.RainshowersDay;
            }
            throw new Exception("Cannot unmarshal type SymbolCode");
        }

        public override void WriteJson(
            JsonWriter writer,
            object untypedValue,
            JsonSerializer serializer
        )
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (SymbolCode)untypedValue;
            switch (value)
            {
                case SymbolCode.Cloudy:
                    serializer.Serialize(writer, "cloudy");
                    return;
                case SymbolCode.Heavyrain:
                    serializer.Serialize(writer, "heavyrain");
                    return;
                case SymbolCode.HeavyrainshowersDay:
                    serializer.Serialize(writer, "heavyrainshowers_day");
                    return;
                case SymbolCode.HeavyrainshowersNight:
                    serializer.Serialize(writer, "heavyrainshowers_night");
                    return;
                case SymbolCode.Lightrain:
                    serializer.Serialize(writer, "lightrain");
                    return;
                case SymbolCode.LightrainshowersDay:
                    serializer.Serialize(writer, "lightrainshowers_day");
                    return;
                case SymbolCode.PartlycloudyDay:
                    serializer.Serialize(writer, "partlycloudy_day");
                    return;
                case SymbolCode.PartlycloudyNight:
                    serializer.Serialize(writer, "partlycloudy_night");
                    return;
                case SymbolCode.Rain:
                    serializer.Serialize(writer, "rain");
                    return;
                case SymbolCode.RainshowersDay:
                    serializer.Serialize(writer, "rainshowers_day");
                    return;
            }
            throw new Exception("Cannot marshal type SymbolCode");
        }

        public static readonly SymbolCodeConverter Singleton = new SymbolCodeConverter();
    }
}
