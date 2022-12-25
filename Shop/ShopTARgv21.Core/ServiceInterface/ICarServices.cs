using ShopTARgv21.Core.Domain;
using ShopTARgv21.Core.Dto;

namespace ShopTARgv21.Core.ServiceInterface 
{
    public interface ICarServices : IApplicationServices
    {
        Task<Car> Create(CarDto dto);

        Task<Car> GetAsync(Guid id);

        Task<Car> Update(CarDto dto);

        Task<Car> Delete(Guid id);
    }
}