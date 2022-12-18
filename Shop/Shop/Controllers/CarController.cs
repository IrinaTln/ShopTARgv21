using Microsoft.AspNetCore.Mvc;
using Shop.Models.Car;
using ShopTARgv21.Data;
using ShopTARgv21.Core.Dto;
using ShopTARgv21.Core.ServiceInterface;
using Microsoft.EntityFrameworkCore.Query.Internal;



namespace Shop.Controllers
{
    public class CarController : Controller
    {
        private readonly ShopDbContext _dbcontext;
        private readonly ICarServices _carServices;
        public CarController(ShopDbContext dbcontext, ICarServices carServices)
        {
            _dbcontext = dbcontext;
            _carServices = carServices;
        }

        [HttpGet]

        public IActionResult Index()
        {
            var result = _dbcontext.Car
                .OrderByDescending(y => y.DateOfRegistration)
                .Select(x => new CarListViewModel
                {
                    Id = x.Id,
                    OwnerName = x.OwnerName,
                    NumberOfRegistration = x.NumberOfRegistration,
                    Brand = x.Brand,
                    Model = x.Model,
                    Color = x.Color
                });
            return View();
        }
    }
}
 