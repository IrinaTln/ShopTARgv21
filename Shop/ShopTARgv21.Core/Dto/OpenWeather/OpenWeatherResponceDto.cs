using System.Text.Json.Serialization;

namespace ShopTARgv21.Core.Dto.OpenWeather
{
    public class OpenWeatherResponceDto
    {

    }

    public class Rootobject
    {
        public OpenWeather OpenWeather { get; set; }
    }

    public class OpenWeather
    {
        public Coord coord { get; set; }
        public Weather[] weather { get; set; }

        [JsonPropertyName("_base")]
        public string _base { get; set; }
        public Main main { get; set; }

        [JsonPropertyName("visibility")]
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Rain rain { get; set; }
        public Clouds clouds { get; set; }

        [JsonPropertyName("dt")]
        public int dt { get; set; }
        public Sys sys { get; set; }

        [JsonPropertyName("timezone")]
        public int timezone { get; set; }

        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("cod")]
        public int cod { get; set; }
    }

    public class Coord
    {
        [JsonPropertyName("lon")]
        public float lon { get; set; }

        [JsonPropertyName("lat")]
        public float lat { get; set; }
    }

    public class Main
    {
        [JsonPropertyName("temp")]
        public float temp { get; set; }

        [JsonPropertyName("feels_like")]
        public float feels_like { get; set; }

        [JsonPropertyName("temp_min")]
        public float temp_min { get; set; }

        [JsonPropertyName("temp_max")]
        public float temp_max { get; set; }

        [JsonPropertyName("pressure")]
        public int pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int humidity { get; set; }

        [JsonPropertyName("sea_level")]
        public int sea_level { get; set; }

        [JsonPropertyName("grnd_level")]
        public int grnd_level { get; set; }
    }

    public class Wind
    {
        [JsonPropertyName("speed")]
        public float speed { get; set; }

        [JsonPropertyName("deg")]
        public int deg { get; set; }

        [JsonPropertyName("gust")]
        public float gust { get; set; }
    }

    public class Rain
    {
        [JsonPropertyName("_1h")]
        public float _1h { get; set; }
    }

    public class Clouds
    {
        [JsonPropertyName("all")]
        public int all { get; set; }
    }

    public class Sys
    {
        [JsonPropertyName("type")]
        public int type { get; set; }

        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("country")]
        public string country { get; set; }

        [JsonPropertyName("sunrise")]
        public int sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public int sunset { get; set; }
    }

    public class Weather
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("main")]
        public string main { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("icon")]
        public string icon { get; set; }
    }

}