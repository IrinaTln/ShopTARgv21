using Microsoft.AspNetCore.Mvc;
using Shop.Models.OpenWeather;
using Shop.Models.RealEstate;
using ShopTARgv21.Core.Dto.OpenWeather;
using ShopTARgv21.Core.ServiceInterface;

namespace Shop.Controllers
{
    public class OpenWeatherController : Controller
    {
        private readonly IOpenWeatherServices _openWeatherServices;
        public OpenWeatherController
            (IOpenWeatherServices openWeatherServices)
        {
            _openWeatherServices = openWeatherServices;
        }

        public IActionResult City()
        {
            {
                OpenWeatherResultDto dto = new OpenWeatherResultDto();

                _openWeatherServices.OpenWeatherDetail(dto);

                OpenWeatherCityViewModel vm = new();

                vm.temp = dto.temp;
                vm.feels_like = dto.feels_like;
                vm.pressure = dto.pressure;
                vm.humidity = dto.humidity;

                vm.main = dto.main;
                vm.speed = dto.speed;

                return View(vm);
            }
        }

        [HttpGet]
        public IActionResult Back()
        {
            return View("Views/Home/Index.cshtml");
        }
    }
}
