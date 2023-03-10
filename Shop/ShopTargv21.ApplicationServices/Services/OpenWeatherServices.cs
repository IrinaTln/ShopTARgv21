using Nancy.Json;
using ShopTARgv21.Core.Dto.OpenWeather;
using ShopTARgv21.Core.ServiceInterface;
using System.Net;


namespace ShopTARgv21.ApplicationServices.Services
{
    public class OpenWeatherServices : IOpenWeatherServices
    {
        public async Task<OpenWeatherResultDto> OpenWeatherDetail(OpenWeatherResultDto dto)
        {

            string apiKey = "bc3efa1190d615a4022bc8556848152b";
            //string cityName = new OpenWeatherSearchCityViewModel();
            //var url1 = $"https://api.openweathermap.org/data/2.5/weather?lat={{lat}}&lon={{lon}}&appid={{apiKey}}";
            var url = $"https://api.openweathermap.org/data/2.5/weather?lat=59.26&lon=24.45&appid=bc3efa1190d615a4022bc8556848152b&units=metric";
            //var url2 = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=metric";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                //ainult ühe classi saab deserialiseerida korraga
                Rootobject weatherInfo = (new JavaScriptSerializer()).Deserialize<Rootobject>(json);

                dto.Coordlon = weatherInfo.OpenWeather.coord.lon;
                dto.Coordlat = weatherInfo.OpenWeather.coord.lat;

                dto.Weatherid = weatherInfo.OpenWeather.weather[0].id;
                dto.WeatherMain = weatherInfo.OpenWeather.weather[0].main;
                dto.Weatherdescription = weatherInfo.OpenWeather.weather[0].description;
                dto.Weathericon = weatherInfo.OpenWeather.weather[0].icon;

                dto._base = weatherInfo.OpenWeather._base;

                dto.Maintemp = weatherInfo.OpenWeather.main.temp;
                dto.Mainfeels_like = weatherInfo.OpenWeather.main.feels_like;
                dto.Maintemp_min = weatherInfo.OpenWeather.main.temp_min;
                dto.Maintemp_max = weatherInfo.OpenWeather.main.temp_max;
                dto.Mainpressure = weatherInfo.OpenWeather.main.pressure;
                dto.Mainhumidity = weatherInfo.OpenWeather.main.humidity;
                dto.Mainsea_level = weatherInfo.OpenWeather.main.sea_level;
                dto.Maingrnd_level = weatherInfo.OpenWeather.main.grnd_level;

                dto.visibility = weatherInfo.OpenWeather.visibility;

                dto.Windspeed = weatherInfo.OpenWeather.wind.speed;
                dto.Winddeg = weatherInfo.OpenWeather.wind.deg;
                dto.Windgust = weatherInfo.OpenWeather.wind.gust;

                dto.Rain_1h = weatherInfo.OpenWeather.rain._1h;

                dto.Cloudsall = weatherInfo.OpenWeather.clouds.all;

                dto.dt = weatherInfo.OpenWeather.dt;

                dto.Systype = weatherInfo.OpenWeather.sys.type;
                dto.Sysid = weatherInfo.OpenWeather.sys.id;
                dto.Syscountry = weatherInfo.OpenWeather.sys.country;
                dto.Syssunrise = weatherInfo.OpenWeather.sys.sunrise;
                dto.Syssunset = weatherInfo.OpenWeather.sys.sunset;

                dto.timezone = weatherInfo.OpenWeather.timezone;
                dto.id = weatherInfo.OpenWeather.id;
                dto.name = weatherInfo.OpenWeather.name;
                dto.cod = weatherInfo.OpenWeather.cod;

                var jsonString = new JavaScriptSerializer().Serialize(dto);
            }
            return dto;
        }
    }
}
