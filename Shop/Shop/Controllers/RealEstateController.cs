using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Shop.Models.Car;
using Shop.Models.RealEstate;
using Shop.Models.Spaceship;
using ShopTARgv21.ApplicationServices.Services;
using ShopTARgv21.Core.Domain;
using ShopTARgv21.Core.Dto;
using ShopTARgv21.Core.ServiceInterface;
using ShopTARgv21.Data;
using ShopTARgv21.Data.Migrations;
using System.Runtime.CompilerServices;

namespace Shop.Controllers
{
    public class RealEstateController : Controller
    {
        private readonly ShopDbContext _context;
        private readonly IRealEstateServices _realEstateServices;
        private readonly IFileServices _fileServices;

        public RealEstateController
            (
               ShopDbContext context,
               IRealEstateServices realEstate,
               IFileServices fileServices
            )
        {
            _context = context;
            _realEstateServices = realEstate;
            _fileServices = fileServices;

        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.RealEstate
                .OrderByDescending(x => x.Id)
                .Select(x => new RealEstateListViewModel
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

            var files = await _context.FileToApi
                .Where(x => x.RealEstateId == id)
                .Select(y => new FileToApiViewModel
                {
                    FilePath = y.FilePath,
                    PhotoId = y.Id
                })
                .ToArrayAsync();

            var vm = new RealEstateCreateUpdateViewModel();
            
            vm.Id = realEstate.Id;
            vm.Address = realEstate.Address;
            vm.City = realEstate.City;
            vm.County = realEstate.County;
            vm.BuildingType = realEstate.BuildingType;
            vm.Size = realEstate.Size;
            vm.RoomNumber = realEstate.RoomNumber;
            vm.Price = realEstate.Price;
            vm.Contact = realEstate.Contact;
            vm.ModifiedAt = realEstate.ModifiedAt;
            vm.CreatedAt = realEstate.CreatedAt;
            vm.FileToApis.AddRange(files);

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
                CreatedAt = vm.CreatedAt,
                Files = vm.Files,
                FilesToApi=vm.FileToApis
                    .Select(x => new FileToApiDto
                    {
                        Id = x.PhotoId,
                        FilePath = x.FilePath,
                        RealEstateId = x.RealEstateId,
                    }).ToArray()
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

            var files = await _context.FileToApi
                .Where(x => x.RealEstateId == id)
                .Select(y => new FileToApiViewModel
            {
                FilePath = y.FilePath,
                PhotoId = y.Id
            })
                .ToArrayAsync();

            var vm = new RealEstateDeleteViewModel();

            vm.Id = realEstate.Id;
            vm.Address = realEstate.Address;
            vm.City = realEstate.City;
            vm.County = realEstate.County;
            vm.BuildingType = realEstate.BuildingType;
            vm.Size = realEstate.Size;
            vm.RoomNumber = realEstate.RoomNumber;
            vm.Price = realEstate.Price;
            vm.Contact = realEstate.Contact;
            vm.ModifiedAt = realEstate.ModifiedAt;
            vm.CreatedAt = realEstate.CreatedAt;
            vm.FileToApis.AddRange(files);

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

        [HttpPost]
        public async Task<IActionResult> RemoveImage(ImageViewModel file)
        {
            var dto = new FileToApiDto()
            {
                Id = file.ImageId
            };

            var image = await _fileServices.RemoveImageFromApi(dto);

            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
