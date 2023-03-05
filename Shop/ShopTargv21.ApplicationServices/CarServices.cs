using ShopTARgv21.Core.ServiceInterface;
using Microsoft.EntityFrameworkCore;
using ShopTARgv21.Core.Domain;
using ShopTARgv21.Core.Dto;
using ShopTARgv21.Data;

namespace ShopTARgv21.ApplicationServices.Services
{
    public class CarServices : ICarServices
    {
        private readonly ShopDbContext _dbcontext;
        private readonly IFileServices _files;
        public CarServices
            (
                ShopDbContext dbcontext,
                IFileServices files
            )
        {
            _dbcontext = dbcontext;
            _files = files;
        }
        public async Task<Car> Create(CarDto dto)
        {
            Car car = new Car();
            FileToDatabase file = new FileToDatabase();

            car.Id = Guid.NewGuid();
            car.OwnerName = dto.OwnerName;
            car.NumberOfRegistration = dto.NumberOfRegistration;
            car.VINCode = dto.VINCode;
            car.Brand = dto.Brand;
            car.Model = dto.Model;
            car.Color = dto.Color;
            car.Fuel = dto.Fuel;
            car.Capacity = dto.Capacity;
            car.NumberOfCarDoors = dto.NumberOfCarDoors;
            car.NumberOfPassangersWithDriver = dto.NumberOfPassangersWithDriver;
            car.CarWeight = dto.CarWeight;
            car.BuildOfDate = dto.BuildOfDate;
            car.DateOfRegistration = dto.DateOfRegistration;

            if (dto.Files != null)
            {
                _files.UploadPictureToDatabase(dto, car);
            }

            await _dbcontext.Car.AddAsync(car);
            await _dbcontext.SaveChangesAsync();

            return car;

        }

        public async Task<Car> GetAsync(Guid id)
        {
            var result = await _dbcontext.Car
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Car> Update(CarDto dto)
        {
            FileToDatabase picture = new FileToDatabase();

            var car = new Car()
            {
                Id = dto.Id,
                OwnerName = dto.OwnerName,
                NumberOfRegistration = dto.NumberOfRegistration,
                VINCode = dto.VINCode,
                Brand = dto.Brand,
                Model = dto.Model,
                Color = dto.Color,
                Fuel = dto.Fuel,
                Capacity = dto.Capacity,
                NumberOfCarDoors = dto.NumberOfCarDoors,
                NumberOfPassangersWithDriver = dto.NumberOfPassangersWithDriver,
                CarWeight = dto.CarWeight,
                BuildOfDate = dto.BuildOfDate,
                DateOfRegistration = dto.DateOfRegistration
            };

            if (dto.Files != null)
            {
                _files.UploadPictureToDatabase(dto, car);
            }

            _dbcontext.Car.Update(car);
            await _dbcontext.SaveChangesAsync();
            return car;
        }

        public async Task<Car> Delete(Guid id)
        {
            var carId = await _dbcontext.Car
                .Include(x => x.FileToDatabase)
                .FirstOrDefaultAsync(x => x.Id == id);

            var photos = await _dbcontext.FileToDatabase
               .Where(x => x.CarId == id)
               .Select(y => new FileToDatabaseDto
               {
                   Id = y.Id,
                   ImageTitle = y.ImageTitle,
                   CarId = y.CarId
               })
                   .ToArrayAsync();

            await _files.RemovePicturesFromDatabase(photos);

            _dbcontext.Car.Remove(carId);
            await _dbcontext.SaveChangesAsync();

            return carId;
        }

        public byte[] UploadFile(CarDto dto, Car domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var photo in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = photo.FileName,
                            CarId = domain.Id,
                        };

                        photo.CopyTo(target);
                        files.ImageData = target.ToArray();

                        _dbcontext.FileToDatabase.Add(files);
                    }
                }
            }

            return null;
        }
    }
}