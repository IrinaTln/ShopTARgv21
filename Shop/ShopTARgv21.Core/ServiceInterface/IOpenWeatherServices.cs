using ShopTARgv21.Core.Dto.OpenWeather;

namespace ShopTARgv21.Core.ServiceInterface
{
    public interface IOpenWeatherServices
    {
        Task<OpenWeatherResultDto> OpenWeatherDetail(OpenWeatherResultDto dto);
    }
}
