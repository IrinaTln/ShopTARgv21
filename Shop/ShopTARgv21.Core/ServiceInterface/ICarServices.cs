using ShopTARgv21.Core.Domain;
using ShopTARgv21.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv21.Core.ServiceInterface
{
    public interface ICarServices
    {
        Task<Car> Add(CarDto dto);

        Task<Car> GetAsync(Guid id);

        Task<Car> Update(CarDto dto);

        Task<Car> Delete(Guid id);
    }
}
