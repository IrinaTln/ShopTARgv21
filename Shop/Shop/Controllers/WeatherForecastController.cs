using Microsoft.AspNetCore.Mvc;
using Shop.Models.WeatherForecast;
using ShopTARgv21.Core.Dto.Weather;
using ShopTARgv21.Core.ServiceInterface;

namespace Shop.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly IWeatherForecastServices _weatherServices;
        public WeatherForecastController
            (IWeatherForecastServices weatherServices)
        {
            _weatherServices = weatherServices;
        }   

        [HttpGet]
        public IActionResult SearchCity()
        {
            SearchCityViewModel vm = new();

            return View(vm);
        }

        [HttpPost]
        public IActionResult SearchCity(SearchCityViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherForecast", new { city = vm.CityName });
            }

            return View(vm);
        }

        public IActionResult City(string city)
        {
            {
                WeatherResultDto dto = new WeatherResultDto();

                _weatherServices.WeatherDetail(dto);

                CityViewModel vm = new();

                vm.LocalObservationDateTime = dto.LocalObservationDateTime;
                vm.EpochTime = dto.EpochTime;
                vm.WeatherText = dto.WeatherText;
                vm.WeatherIcon = dto.WeatherIcon;
                vm.HasPrecipitation = dto.HasPrecipitation;
                vm.PrecipitationType = dto.PrecipitationType;
                vm.IsDayTime = dto.IsDayTime;
                vm.MobileLink = dto.MobileLink;
                vm.Link = dto.Link;

                vm.TempMetricValue = dto.TempMetricValue;
                vm.TempMetricUnit = dto.TempMetricUnit;
                vm.TempMetricUnitType = dto.TempMetricUnitType;

                vm.TempImperialValue = dto.TempImperialValue;
                vm.TempImperialUnit = dto.TempImperialUnit;
                vm.TempImperialUnitType = dto.TempImperialUnitType;

                return View(vm);

            }
        }
    }
}
