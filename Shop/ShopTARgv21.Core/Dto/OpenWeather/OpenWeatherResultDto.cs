using ShopTARgv21.Core.Dto.OpenWeather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopTARgv21.Core.Dto.OpenWeather
{
    public class OpenWeatherResultDto
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
