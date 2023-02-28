using Microsoft.AspNetCore.Mvc;
using Shop.Models.Car;
using ShopTARgv21.Data;
using ShopTARgv21.Core.Dto;
using ShopTARgv21.Core.ServiceInterface;




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
            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            CarEditViewModel car = new CarEditViewModel();

            return View("CreateUpdate", car);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                OwnerName = vm.OwnerName,
                NumberOfRegistration = vm.NumberOfRegistration,
                VINCode = vm.VINCode,
                Brand = vm.Brand,
                Model = vm.Model,
                Color = vm.Color,
                Fuel = vm.Fuel,
                Capacity = vm.Capacity,
                NumberOfCarDoors = vm.NumberOfCarDoors,
                NumberOfPassangersWithDriver = vm.NumberOfPassangersWithDriver,
                CarWeight = vm.CarWeight,
                BuildOfDate = vm.BuildOfDate,
                DateOfRegistration = vm.DateOfRegistration,

            };
            var result = await _carServices.Create(dto);

            if (result is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]

        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarEditViewModel()
            {
                Id = car.Id,
                OwnerName = car.OwnerName,
                NumberOfRegistration = car.NumberOfRegistration,
                VINCode = car.VINCode,
                Brand = car.Brand,
                Model = car.Model,
                Color = car.Color,
                Fuel = car.Fuel,
                Capacity = car.Capacity,
                NumberOfCarDoors = car.NumberOfCarDoors,
                NumberOfPassangersWithDriver = car.NumberOfPassangersWithDriver,
                CarWeight = car.CarWeight,
                BuildOfDate = car.BuildOfDate,
                DateOfRegistration = car.DateOfRegistration,
            };

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarEditViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                OwnerName = vm.OwnerName,
                NumberOfRegistration = vm.NumberOfRegistration,
                VINCode = vm.VINCode,
                Brand = vm.Brand,
                Model = vm.Model,
                Color = vm.Color,
                Fuel = vm.Fuel,
                Capacity = vm.Capacity,
                NumberOfCarDoors = vm.NumberOfCarDoors,
                NumberOfPassangersWithDriver = vm.NumberOfPassangersWithDriver,
                CarWeight = vm.CarWeight,
                BuildOfDate = vm.BuildOfDate,
                DateOfRegistration = vm.DateOfRegistration
            };
            var result = await _carServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarViewModel()
            {
                Id = car.Id,
                OwnerName = car.OwnerName,
                NumberOfRegistration = car.NumberOfRegistration,
                VINCode = car.VINCode,
                Brand = car.Brand,
                Model = car.Model,
                Color = car.Color,
                Fuel = car.Fuel,
                Capacity = car.Capacity,
                NumberOfCarDoors = car.NumberOfCarDoors,
                NumberOfPassangersWithDriver = car.NumberOfPassangersWithDriver,
                CarWeight = car.CarWeight,
                BuildOfDate = car.BuildOfDate,
                DateOfRegistration = car.DateOfRegistration,
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var product = await _carServices.Delete(id);

            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
