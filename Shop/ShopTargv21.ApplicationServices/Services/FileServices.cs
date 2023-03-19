using Microsoft.EntityFrameworkCore;
using ShopTARgv21.Core.Domain;
using ShopTARgv21.Core.Dto;
using ShopTARgv21.Core.ServiceInterface;
using ShopTARgv21.Data;
using Microsoft.Extensions.Hosting;

namespace ShopTARgv21.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly ShopDbContext _context;
        private readonly IHostEnvironment _env;

        public FileServices(ShopDbContext context, IHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public void UploadFileToDatabase(SpaceshipDto dto, Spaceship domaine)
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
                            SpaceshipId = domaine.Id,
                        };

                        photo.CopyTo(target);
                        files.ImageData = target.ToArray();

                        _context.FileToDatabase.Add(files);
                    }
                }
            }

        }

        public async Task<FileToDatabase> RemoveImage(FileToDatabaseDto dto)
        {
            var imageId = await _context.FileToDatabase
                .Where(x => x.Id == dto.Id)
                .FirstOrDefaultAsync();

            _context.FileToDatabase.Remove(imageId);
            await _context.SaveChangesAsync();

            return imageId;
        }

        public async Task<List<FileToDatabase>> RemoveImagesFromDatabase(FileToDatabaseDto[] dto)
        {
            foreach (var dtos in dto)
            {
                var photoId = await _context.FileToDatabase
                    .Where(x => x.Id == dtos.Id)
                    .FirstOrDefaultAsync();

                _context.FileToDatabase.Remove(photoId);
                await _context.SaveChangesAsync();

            }

            return null;
        }

        public void UploadFileToApi(RealEstateDto dto, RealEstate domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (!Directory.Exists(_env.ContentRootPath + "\\multipleFileUpload\\"))
                {
                    Directory.CreateDirectory(_env.ContentRootPath + "\\multipleFileUpload\\");
                }
                foreach (var file in dto.Files)
                {
                    string uploadsFolder = Path.Combine(_env.ContentRootPath, "multipleFileUpload");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                        FileToApi path = new FileToApi()
                        {
                            Id = Guid.NewGuid(),
                            FilePath =uniqueFileName,
                            RealEstateId = domain.Id,
                        };

                        _context.FileToApi.AddAsync(path);
                    }
                }
            }
        }

        public async Task<FileToApi> RemoveImageFromApi(FileToApiDto dto)
        {
            var imageId = await _context.FileToApi
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            var filePath = _env.ContentRootPath + "\\multipleFileUpload\\" + imageId.FilePath;

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            _context.FileToApi.Remove(imageId);
            await _context.SaveChangesAsync();

            return imageId;
        }

        public async Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos)
        {
            foreach (var dto in dtos)
            {
                var imageId = await _context.FileToApi
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

                var filePath = _env.ContentRootPath + "\\multipleFileUpload\\" + imageId.FilePath;

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                _context.FileToApi.Remove(imageId);
                await _context.SaveChangesAsync();
            }

            return null;
        }
    }
}
