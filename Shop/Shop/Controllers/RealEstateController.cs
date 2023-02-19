using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Shop.Models.Car;
using Shop.Models.RealEstate;
using ShopTARgv21.ApplicationServices.Services;
using ShopTARgv21.Core.Domain;
using ShopTARgv21.Core.Dto;
using ShopTARgv21.Core.ServiceInterface;
using ShopTARgv21.Data;
using System.Runtime.CompilerServices;

namespace Shop.Controllers
{
    public class RealEstateController : Controller
    {
        private readonly ShopDbContext _context;
        private readonly IRealEstateServices _realEstateServices;

        public RealEstateController
            (
               ShopDbContext context,
               IRealEstateServices realEstate
            )
        {
            _context = context;
            _realEstateServices = realEstate;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.RealEstate
                .OrderByDescending(x => x.Id)
                .Select(x => new RealEstateViewModel
                {
                    Id = x.Id,
                    Address = x.Address,
                    City = x.City,
                    Contact = x.Contact,
                    Size = x.Size,
                    Price = x.Price,
                    RoomNumber = x.RoomNumber,
                    BuildingType = x.BuildingType,
                });
            
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            RealEstateCreateUpdateViewModel realEstate = new RealEstateCreateUpdateViewModel();

            return View("CreateUpdate", realEstate);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto
            {
                Id=vm.Id,
                Address=vm.Address,
                City=vm.City,
                Contact=vm.Contact,
                Size=vm.Size,
                Price=vm.Price,
                BuildingType=vm.BuildingType,
                County=vm.County,
                RoomNumber=vm.RoomNumber,
                CreatedAt=vm.CreatedAt,
                ModifiedAt=vm.ModifiedAt,
                Files=vm.Files,
                FilesToApi = vm.FileToApis
                    .Select(x=>new FileToApiDto
                    {
                        Id = x.PhotoId,
                        FilePath=x.FilePath,
                        RealEstateId=x.RealEstateId,
                    
                    }).ToArray()
            };

            var result = await _realEstateServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public async Task<IActionResult> Update(Guid id)
        {
            var realEstate = await _realEstateServices.GetAsync(id);

            if (realEstate == null)
            {
                return NotFound();
            }

            var vm = new RealEstateCreateUpdateViewModel()
            {
                Id = realEstate.Id,
                Address = realEstate.Address,
                City = realEstate.City,
                County = realEstate.County,
                BuildingType = realEstate.BuildingType,
                Size = realEstate.Size,
                RoomNumber = realEstate.RoomNumber,
                Price = realEstate.Price,
                Contact = realEstate.Contact,
                ModifiedAt = realEstate.ModifiedAt,
                CreatedAt = realEstate.CreatedAt,
            };

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                City = vm.City,
                County = vm.County,
                BuildingType = vm.BuildingType,
                Size = vm.Size,
                RoomNumber = vm.RoomNumber,
                Price = vm.Price,
                Contact = vm.Contact,
                ModifiedAt = vm.ModifiedAt,
                CreatedAt = vm.CreatedAt
                };
            var result = await _realEstateServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var realEstate = await _realEstateServices.GetAsync(id);

            if (realEstate == null)
            {
                return NotFound();
            }

            var vm = new RealEstateViewModel()
            {
                Id = realEstate.Id,
                Address = realEstate.Address,
                City = realEstate.City,
                County = realEstate.County,
                BuildingType = realEstate.BuildingType,
                Size = realEstate.Size,
                RoomNumber = realEstate.RoomNumber,
                Price = realEstate.Price,
                Contact = realEstate.Contact,
                ModifiedAt = realEstate.ModifiedAt,
                CreatedAt = realEstate.CreatedAt,                
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var product = await _realEstateServices.Delete(id);

            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
