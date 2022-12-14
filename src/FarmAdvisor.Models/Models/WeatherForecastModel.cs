using Newtonsoft.Json;

namespace FarmAdvisor.Models.Models
{
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
        public double[] Coordinates { get; set; }
    }

    public partial class Properties
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("timeseries")]
        public Timesery[] Timeseries { get; set; }
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

        [JsonProperty("cloud_area_fraction")]
        public string CloudAreaFraction { get; set; }

        [JsonProperty("precipitation_amount")]
        public string PrecipitationAmount { get; set; }

        [JsonProperty("relative_humidity")]
        public string RelativeHumidity { get; set; }

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

        [JsonProperty("next_12_hours")]
        public Next12_Hours Next12_Hours { get; set; }

        [JsonProperty("next_1_hours")]
        public NextHours Next1_Hours { get; set; }

        [JsonProperty("next_6_hours")]
        public NextHours Next6_Hours { get; set; }
    }

    public partial class Instant
    {
        [JsonProperty("details")]
        public InstantDetails Details { get; set; }
    }

    public partial class InstantDetails
    {
        [JsonProperty("air_pressure_at_sea_level")]
        public double AirPressureAtSeaLevel { get; set; }

        [JsonProperty("air_temperature")]
        public double AirTemperature { get; set; }

        [JsonProperty("cloud_area_fraction")]
        public double CloudAreaFraction { get; set; }

        [JsonProperty("relative_humidity")]
        public double RelativeHumidity { get; set; }

        [JsonProperty("wind_from_direction")]
        public double WindFromDirection { get; set; }

        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }
    }

    public partial class Next12_Hours
    {
        [JsonProperty("summary")]
        public Summary Summary { get; set; }
    }

    public partial class Summary
    {
        [JsonProperty("symbol_code")]
        public string SymbolCode { get; set; }
    }

    public partial class NextHours
    {
        [JsonProperty("summary")]
        public Summary Summary { get; set; }

        [JsonProperty("details")]
        public Next1_HoursDetails Details { get; set; }
    }

    public partial class Next1_HoursDetails
    {
        [JsonProperty("precipitation_amount")]
        public long PrecipitationAmount { get; set; }
    }
}
