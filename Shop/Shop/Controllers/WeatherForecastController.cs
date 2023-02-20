using Microsoft.AspNetCore.Mvc;
using Shop.Models.WeatherForecast;

namespace Shop.Controllers
{
    public class WeatherForecastController : Controller
    {

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
                return RedirectToAction("City", "WeatherForcast", new { city = vm.CityName });
            }

            return View(vm);
        }
    }
}
