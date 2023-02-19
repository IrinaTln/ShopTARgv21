using ShopTARgv21.Core.Domain;
using ShopTARgv21.Core.Dto;

namespace ShopTARgv21.Core.ServiceInterface
{
    public interface IFileServices : IApplicationServices
    {
        void UploadFileToDatabase(SpaceshipDto dto, Spaceship domaine);

        Task<FileToDatabase> RemoveImage(FileToDatabaseDto dto);

        Task<List<FileToDatabase>> RemoveImagesFromDatabase(FileToDatabaseDto[] dto);
        void UploadFileToApi(RealEstateDto dto, RealEstate domain);
    }
}
