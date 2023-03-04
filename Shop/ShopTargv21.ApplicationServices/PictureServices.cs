using Microsoft.EntityFrameworkCore;
using ShopTARgv21.Core.Domain;
using ShopTARgv21.Core.Dto;
using ShopTARgv21.Data;
using Microsoft.AspNetCore.Hosting;
using ShopTARgv21.Core.ServiceInterface;

namespace ShopTARgv21.ApplicationServices
{
    public class PictureServices : IPictureServices
    {
        private readonly ShopDbContext _dbcontext;
        private readonly IWebHostEnvironment _env;

        public PictureServices(ShopDbContext dbcontext, IWebHostEnvironment env)
        {
            _dbcontext = dbcontext;
            _env = env;
        }

        public void UploadPictureToDatabase(CarDto dto, Car domaine)
        {
            if (dto.Pictures != null && dto.Pictures.Count > 0)
            {
                foreach (var photo in dto.Pictures)
                {
                    using (var target = new MemoryStream())
                    {
                        PictureToDatabase files = new PictureToDatabase
                        {
                            Id = Guid.NewGuid(),
                            PictureTitle = photo.FileName,
                            CarId = domaine.Id,
                        };

                        photo.CopyTo(target);
                        files.PictureData = target.ToArray();

                        _dbcontext.PictureToDatabase.Add(files);
                    }
                }
            }

        }

        public async Task<PictureToDatabase> RemovePicture(PictureToDatabaseDto dto)
        {
            var imageId = await _dbcontext.PictureToDatabase
                .Where(x => x.Id == dto.Id)
                .FirstOrDefaultAsync();

            _dbcontext.PictureToDatabase.Remove(imageId);
            await _dbcontext.SaveChangesAsync();

            return imageId;
        }

        public async Task<List<PictureToDatabase>> RemovePicturesFromDatabase(PictureToDatabaseDto[] dto)
        {
            foreach (var dtos in dto)
            {
                var photoId = await _dbcontext.PictureToDatabase
                    .Where(x => x.Id == dtos.Id)
                    .FirstOrDefaultAsync();

                _dbcontext.PictureToDatabase.Remove(photoId);
                await _dbcontext.SaveChangesAsync();

            }

            return null;
        }

    }
}
