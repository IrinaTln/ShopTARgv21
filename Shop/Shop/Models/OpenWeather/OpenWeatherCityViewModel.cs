using ShopTARgv21.Core.Dto.OpenWeather;

namespace Shop.Models.OpenWeather
{
    public class OpenWeatherCityViewModel
    {
        public List<Weather> weather { get; set; }
        public Main maine { get; set; }
        public Wind wind { get; set; }
        public double temp { get; set; }
        public double feels_like { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public string main { get; set; }
        public double speed { get; set; }
    }
}
