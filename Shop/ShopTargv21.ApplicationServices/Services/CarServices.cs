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
        public CarServices
            (
                ShopDbContext dbcontext
            )
        {
            _dbcontext = dbcontext;
        }
        public async Task<Car> Create(CarDto dto)
        {
            Car car = new Car();

            car.Id = dto.Id;
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

            _dbcontext.Car.Update(car);
            await _dbcontext.SaveChangesAsync();

            return car;
        }

        public async Task<Car> Delete(Guid id)
        {
            var car = await _dbcontext.Car
                .FirstOrDefaultAsync(x => x.Id == id);

            _dbcontext.Car.Remove(car);
            await _dbcontext.SaveChangesAsync();

            return car;
        }
    }
}