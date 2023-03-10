using ShopTARgv21.Core.Dto.OpenWeather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv21.Core.Dto.OpenWeather
{
    public class OpenWeatherResultDto
    {
        public float Coordlon {  get; set; }
        public float Coordlat { get; set; }

        public int Weatherid { get; set; }
        public string WeatherMain { get; set; }
        public string Weatherdescription { get; set; }
        public string Weathericon { get; set;}

        public string _base { get; set; }

        public float Maintemp { get; set; }
        public float Mainfeels_like { get; set; }
        public float Maintemp_min { get; set; }
        public float Maintemp_max { get; set; }
        public int Mainpressure { get; set; }
        public int Mainhumidity { get; set; }
        public int Mainsea_level { get; set; }
        public int Maingrnd_level { get; set; }

        public int visibility { get; set; }

        public float Windspeed { get; set; }
        public int Winddeg { get; set; }
        public float Windgust { get; set; }

        public float Rain_1h { get; set; }

        public int Cloudsall { get; set; }

        public int dt { get; set; }

        public int Systype { get; set; }
        public int Sysid { get; set; }
        public string Syscountry { get; set; }
        public int Syssunrise { get; set; }
        public int Syssunset { get; set; }

        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
}
