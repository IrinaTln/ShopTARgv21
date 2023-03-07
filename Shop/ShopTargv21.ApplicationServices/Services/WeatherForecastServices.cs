using Nancy.Json;
using ShopTARgv21.Core.Dto.Weather;
using ShopTARgv21.Core.ServiceInterface;
using System.Net;


namespace ShopTARgv21.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {
        public async Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto)
        {
            //Tallinna kood: 127964

            string apiKey = "yGfdNmttrAWATtB0hemDd7AP7259tjCv";
            var url = $"http://dataservice.accuweather.com/currentconditions/v1/1?apikey={apiKey}&language=et&details=false";
            var url2 = $"http://dataservice.accuweather.com/currentconditions/v1/1?apikey=yGfdNmttrAWATtB0hemDd7AP7259tjCv&language=et&details=false";

            using (WebClient client = new WebClient())
            {
                List<DailyForecast> weatherInfo = new();

                string json = client.DownloadString(url);
                //ainult ühe classi saab deserialiseerida korraga
                weatherInfo = new JavaScriptSerializer().Deserialize<List<DailyForecast>>(json);
                //Root weatherInfo = (new JavaScriptSerializer()).Deserialize<Root>(json);

                dto.LocalObservationDateTime = weatherInfo[0].LocalObservationDateTime;
                dto.EpochTime = weatherInfo[0].EpochTime;
                dto.WeatherText = weatherInfo[0].WeatherText;
                dto.WeatherIcon = weatherInfo[0].WeatherIcon;
                dto.HasPrecipitation = weatherInfo[0].HasPrecipitation;
                dto.IsDayTime = weatherInfo[0].IsDayTime;
                dto.MobileLink = weatherInfo[0].MobileLink;
                dto.Link = weatherInfo[0].Link;

                dto.TempMetricValue = weatherInfo[0].Temperature.Metric.Value;
                dto.TempMetricUnit = weatherInfo[0].Temperature.Metric.Unit;
                dto.TempMetricUnitType = weatherInfo[0].Temperature.Metric.UnitType;

                dto.TempImperialValue = weatherInfo[0].Temperature.Imperial.Value;
                dto.TempImperialUnit = weatherInfo[0].Temperature.Imperial.Unit;
                dto.TempImperialUnitType = weatherInfo[0].Temperature.Imperial.UnitType;

                var jsonString = new JavaScriptSerializer().Serialize(dto);
            }

            return dto;
        }
    }
}
