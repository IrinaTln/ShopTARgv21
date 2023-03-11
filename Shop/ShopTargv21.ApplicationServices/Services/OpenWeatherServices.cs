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
            var url = $"https://api.openweathermap.org/data/2.5/weather?lat=59.26&lon=24.45&appid=bc3efa1190d615a4022bc8556848152b&units=metric";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                Root weatherInfo = (new JavaScriptSerializer()).Deserialize<Root>(json);

                dto.temp = weatherInfo.main.temp;
                dto.feels_like = weatherInfo.main.feels_like;
                dto.pressure = weatherInfo.main.pressure;
                dto.humidity = weatherInfo.main.humidity;

                dto.main = weatherInfo.weather[0].main;
                dto.speed = weatherInfo.wind.speed;

                var jsonString = new JavaScriptSerializer().Serialize(dto);
            }
            return dto;
        }
    }
}
