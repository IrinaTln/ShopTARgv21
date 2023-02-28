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
        private readonly ShopDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PictureServices(ShopDbContext context, IWebHostEnvironment env)
        {
            _context = context;
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

                        _context.PictureToDatabase.Add(files);
                    }
                }
            }

        }

        public async Task<PictureToDatabase> RemovePicture(PictureToDatabase dto)
        {
            var imageId = await _context.PictureToDatabase
                .Where(x => x.Id == dto.Id)
                .FirstOrDefaultAsync();

            _context.PictureToDatabase.Remove(imageId);
            await _context.SaveChangesAsync();

            return imageId;
        }

        public async Task<List<PictureToDatabase>> RemovePicturesFromDatabase(PictureToDatabase[] dto)
        {
            foreach (var dtos in dto)
            {
                var photoId = await _context.PictureToDatabase
                    .Where(x => x.Id == dtos.Id)
                    .FirstOrDefaultAsync();

                _context.PictureToDatabase.Remove(photoId);
                await _context.SaveChangesAsync();

            }

            return null;
        }

    }
}
