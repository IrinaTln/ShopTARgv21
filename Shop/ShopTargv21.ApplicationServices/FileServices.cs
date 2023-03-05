using Microsoft.EntityFrameworkCore;
using ShopTARgv21.Core.Domain;
using ShopTARgv21.Core.Dto;
using ShopTARgv21.Data;
using ShopTARgv21.Core.ServiceInterface;
using Microsoft.AspNetCore.Hosting;


namespace ShopTARgv21.ApplicationServices
{
    public class FileServices : IFileServices
    {
        private readonly ShopDbContext _dbcontext;
        private readonly IWebHostEnvironment _env;

        public FileServices(ShopDbContext dbcontext, IWebHostEnvironment env)
        {
            _dbcontext = dbcontext;
            _env = env;
        }

        public void UploadPictureToDatabase(CarDto dto, Car domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var photo in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = photo.FileName,
                            CarId = domain.Id,
                        };

                        photo.CopyTo(target);
                        files.ImageData = target.ToArray();

                        _dbcontext.FileToDatabase.Add(files);
                    }
                }
            }

        }

        public async Task<FileToDatabase> RemovePicture(FileToDatabaseDto dto)
        {
            var imageId = await _dbcontext.FileToDatabase
                .Where(x => x.Id == dto.Id)
                .FirstOrDefaultAsync();

            _dbcontext.FileToDatabase.Remove(imageId);
            await _dbcontext.SaveChangesAsync();

            return imageId;
        }

        public async Task<List<FileToDatabase>> RemovePicturesFromDatabase(FileToDatabaseDto[] dto)
        {
            foreach (var dtos in dto)
            {
                var photoId = await _dbcontext.FileToDatabase
                    .Where(x => x.Id == dtos.Id)
                    .FirstOrDefaultAsync();

                _dbcontext.FileToDatabase.Remove(photoId);
                await _dbcontext.SaveChangesAsync();

            }

            return null;
        }

    }
}
