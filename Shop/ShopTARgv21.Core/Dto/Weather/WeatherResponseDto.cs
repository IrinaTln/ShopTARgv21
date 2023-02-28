using System.Text.Json.Serialization;

namespace ShopTARgv21.Core.Dto.Weather
{
    public class WeatherResponseDto
    {

    }

    public class Root
    {
        public List<DailyForecast> DailyForecasts { get; set; }
    }

    public class DailyForecast
    {
        [JsonPropertyName("LocalObservationDateTime")]
        public DateTime LocalObservationDateTime { get; set; }

        [JsonPropertyName("EpochTime")]
        public int EpochTime { get; set; }

        [JsonPropertyName("WeatherText")]
        public string WeatherText { get; set; }

        [JsonPropertyName("WeatherIcon")]
        public int WeatherIcon { get; set; }

        [JsonPropertyName("HasPrecipitation")]
        public bool HasPrecipitation { get; set; }

        [JsonPropertyName("PrecipitationType")]
        public object PrecipitationType { get; set; }

        [JsonPropertyName("IsDayTime")]
        public bool IsDayTime { get; set; }

        public Temperature Temperature { get; set; }

        [JsonPropertyName("MobileLink")]
        public string MobileLink { get; set; }

        [JsonPropertyName("Link")]
        public string Link { get; set; }
    }

    public class Temperature
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

    public class Metric
    {
        [JsonPropertyName("DailyForecast.Temperature.Metric.Value")]
        public float Value { get; set; }

        [JsonPropertyName("DailyForecast.Temperature.Metric.Unit")]
        public string Unit { get; set; }

        [JsonPropertyName("DailyForecast.Temperature.Metric.UnitType")]
        public float UnitType { get; set; }
    }

    public class Imperial
    {
        [JsonPropertyName("DailyForecast.Temperature.Imperial.Value")]
        public float Value { get; set; }

        [JsonPropertyName("DailyForecast.Temperature.Imperial.Unit")]
        public string Unit { get; set; }

        [JsonPropertyName("DailyForecast.Temperature.Imperial.UnitType")]
        public float UnitType { get; set; }
    }
}
