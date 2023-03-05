using ShopTARgv21.Core.Domain;
using ShopTARgv21.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv21.Core.ServiceInterface
{
    public interface IFileServices : IApplicationServices
    {
        void UploadPictureToDatabase(CarDto dto, Car domaine);

        Task<FileToDatabase> RemovePicture(FileToDatabaseDto dto);
        Task<List<FileToDatabase>> RemovePicturesFromDatabase(FileToDatabaseDto[] dto);
    }
}
