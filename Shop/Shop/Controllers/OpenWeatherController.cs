using Microsoft.AspNetCore.Mvc;
using Shop.Models.OpenWeather;
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

        [HttpGet]
        public IActionResult SearchCity()
        {
            OpenWeatherSearchCityViewModel vm = new();

            return View(vm);
        }

        [HttpPost]
        public IActionResult SearchCity(OpenWeatherSearchCityViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("CityWeather", "OpenWeather", new { city = vm.CityName });
            }

            return View(vm);
        }

        public IActionResult City(string city)
        {
            {
                OpenWeatherResultDto dto = new OpenWeatherResultDto();

                _openWeatherServices.OpenWeatherDetail(dto);

                OpenWeatherCityViewModel vm = new();

                vm.Coordlon = dto.Coordlon;
                vm.Coordlat = dto.Coordlat;

                vm.Weatherid = dto.Weatherid;
                vm.WeatherMain = dto.WeatherMain;
                vm.Weatherdescription = dto.Weatherdescription;
                vm.Weathericon = dto.Weathericon;

                vm._base = dto._base;

                vm.Maintemp = dto.Maintemp;
                vm.Mainfeels_like = dto.Mainfeels_like;
                vm.Maintemp_min = dto.Maintemp_min;
                vm.Maintemp_max = dto.Maintemp_max;
                vm.Mainpressure = dto.Mainpressure;
                vm.Mainhumidity = dto.Mainhumidity;
                vm.Mainsea_level = dto.Mainsea_level;
                vm.Maingrnd_level = dto.Maingrnd_level;

                vm.visibility = dto.visibility;

                vm.Windspeed = dto.Windspeed;
                vm.Winddeg = dto.Winddeg;
                vm.Windgust = dto.Windgust;

                vm.Rain_1h = dto.Rain_1h;

                vm.Cloudsall = dto.Cloudsall;

                vm.dt = dto.dt;

                vm.Systype = dto.Systype;
                vm.Sysid = dto.Sysid;
                vm.Syscountry = dto.Syscountry;
                vm.Syssunrise = dto.Syssunrise;
                vm.Syssunset = dto.Syssunset;

                vm.timezone = dto.timezone;
                vm.id = dto.id;
                vm.name = dto.name;
                vm.cod = dto.cod;

                return View(dto);

            }
        }
    }
}
