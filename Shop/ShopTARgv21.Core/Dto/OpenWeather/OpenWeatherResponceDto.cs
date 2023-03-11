using System.Text.Json.Serialization;

namespace ShopTARgv21.Core.Dto.OpenWeather
{

    public class OpenWeatherResponceDto
    {

    }
    public class Root
    {
        [JsonPropertyName("weather")]
        public List<Weather> weather { get; set; }

        [JsonPropertyName("main")]
        public Main main { get; set; }

        [JsonPropertyName("wind")]
        public Wind wind { get; set; }
    }

    public class Main
    {
        [JsonPropertyName("Root.Main.temp")]
        public double temp { get; set; }

        [JsonPropertyName("Root.Main.feels_like")]
        public double feels_like { get; set; }

        [JsonPropertyName("Root.Main.pressure")]
        public int pressure { get; set; }

        [JsonPropertyName("Root.Main.humidity")]
        public int humidity { get; set; }
    }

    public class Weather
    {
        [JsonPropertyName("Root.Weather.main")]
        public string main { get; set; }
    }

    public class Wind
    {
        [JsonPropertyName("Root.Wind.speed")]
        public double speed { get; set; }

    }
}