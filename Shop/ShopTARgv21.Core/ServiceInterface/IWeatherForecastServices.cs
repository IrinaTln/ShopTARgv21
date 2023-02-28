using ShopTARgv21.Core.Dto.Weather;

namespace ShopTARgv21.Core.ServiceInterface
{
    public interface IWeatherForecastServices
    {
        Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto);
    }
}
