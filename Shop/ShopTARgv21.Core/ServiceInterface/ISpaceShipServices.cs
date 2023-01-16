using ShopTARgv21.Core.Domain;
using ShopTARgv21.Core.Dto;
using System.Threading.Tasks;


namespace ShopTARgv21.Core.ServiceInterface
{
    public interface ISpaceShipServices : IApplicationServices
    {
        Task<Spaceship> Create(SpaceshipDto dto);

        Task<Spaceship> GetAsync(Guid id);

        Task<Spaceship> Update(SpaceshipDto dto);

        Task<Spaceship> Delete(Guid id);

    }
   
}
