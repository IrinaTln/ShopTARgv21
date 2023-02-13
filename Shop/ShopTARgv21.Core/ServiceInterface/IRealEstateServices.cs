using ShopTARgv21.Core.Domain;
using ShopTARgv21.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv21.Core.ServiceInterface
{
    public interface IRealEstateServices : IApplicationServices
    {
        Task<RealEstate> Create(RealEstateDto dto);
        Task<RealEstate> GetAsync(Guid id);
        Task<RealEstate> Update(RealEstateDto dto);
        Task<RealEstate> Delete(Guid id);
    }
}
