using Microsoft.EntityFrameworkCore;
using ShopTARgv21.Core.Domain;
using ShopTARgv21.Core.Dto;
using ShopTARgv21.Core.ServiceInterface;
using ShopTARgv21.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv21.ApplicationServices.Services
{
    public class RealEstateServices : IRealEstateServices
    { 
        private readonly ShopDbContext _context;
        private readonly IFileServices _fileServices;
        public RealEstateServices
            (
                ShopDbContext context,
                IFileServices fileServices
            )
        {
            _context = context;
            _fileServices = fileServices;
        }
        public async Task<RealEstate> Create(RealEstateDto dto)
        {
            RealEstate realEstate = new RealEstate();

            realEstate.Id = Guid.NewGuid();
            realEstate.Address = dto.Address;
            realEstate.City=dto.City;
            realEstate.Price=dto.Price;
            realEstate.Contact=dto.Contact;
            realEstate.BuildingType=dto.BuildingType;
            realEstate.County=dto.County;
            realEstate.Size= dto.Size;
            realEstate.CreatedAt = DateTime.Now;
            realEstate.ModifiedAt= DateTime.Now;
            _fileServices.UploadFileToApi(dto, realEstate);

        await _context.RealEstate.AddAsync(realEstate);
        await _context.SaveChangesAsync();
        return realEstate;
        }

        public async Task<RealEstate> GetAsync(Guid id)
        {
            var result = await _context.RealEstate
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<RealEstate> Update(RealEstateDto dto)
        {

            var realEstate = new RealEstate()
            {
                Id =dto.Id,
                Address = dto.Address,
                City = dto.City,
                County = dto.County,
                BuildingType = dto.BuildingType,
                Size = dto.Size,
                RoomNumber = dto.RoomNumber,
                Price = dto.Price,
                Contact = dto.Contact,
                ModifiedAt = dto.ModifiedAt,
                CreatedAt = dto.CreatedAt
            };

            _fileServices.UploadFileToApi(dto, realEstate);
            _context.RealEstate.Update(realEstate);
            await _context.SaveChangesAsync();

            return realEstate;
        }

        public async Task<RealEstate> Delete(Guid id)
        {
            var realEstateId = await _context.RealEstate
                .FirstOrDefaultAsync(x => x.Id == id);


            var images = await _context.FileToApi
                .Where(x => x.RealEstateId == id)
                .Select(y => new FileToApiDto
                {
                    Id = y.Id,
                    RealEstateId = y.RealEstateId,
                    FilePath = y.FilePath
                }).ToArrayAsync();

            await _fileServices.RemoveImagesFromApi(images);
            _context.RealEstate.Remove(realEstateId);
            await _context.SaveChangesAsync();

            return realEstateId;
        }
    }
}
