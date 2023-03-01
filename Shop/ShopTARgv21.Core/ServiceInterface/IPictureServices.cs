using ShopTARgv21.Core.Domain;
using ShopTARgv21.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv21.Core.ServiceInterface
{
    public interface IPictureServices : IApplicationServices
    {
        void UploadPictureToDatabase(CarDto dto, Car domaine);

        Task<PictureToDatabase> RemovePicture(PictureToDatabaseDto dto);

        Task<List<PictureToDatabase>> RemovePicturesFromDatabase(PictureToDatabaseDto[] dto);
    }
}
