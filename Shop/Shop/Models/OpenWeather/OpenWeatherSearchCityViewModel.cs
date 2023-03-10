using System.ComponentModel.DataAnnotations;

namespace Shop.Models.OpenWeather
{
    public class OpenWeatherSearchCityViewModel
    {
        [Required(ErrorMessage = "You mast enter a city name")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only text allowed!")]
        [Display(Name = "City Name")]
        public string CityName { get; set; }
    }
}
