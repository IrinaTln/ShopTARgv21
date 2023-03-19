using Microsoft.EntityFrameworkCore;
using ShopTARgv21.Core.Domain;
using ShopTARgv21.Core.Dto;
using ShopTARgv21.Core.ServiceInterface;
using ShopTARgv21.Data;

namespace ShopTARgv21.ApplicationServices.Services
{
    public class SpaceShipServices : ISpaceShipServices
    {
        private readonly ShopDbContext _context;
        private readonly IFileServices _files;

        public SpaceShipServices
            (
                ShopDbContext context,
                IFileServices files
            )
        {
            _context = context;
            _files = files;
        }
        public async Task<Spaceship> Create(SpaceshipDto dto)
        {
            Spaceship spaceship = new Spaceship();
            FileToDatabase file = new FileToDatabase();

            spaceship.Id = Guid.NewGuid();
            spaceship.Name = dto.Name;
            spaceship.ModelType = dto.ModelType;
            spaceship.PlaceOfBuild = dto.PlaceOfBuild;
            spaceship.EnginePower = dto.EnginePower;
            spaceship.SpaceshipBuilder = dto.SpaceshipBuilder;
            spaceship.LiftUpToSpaceByTonn = dto.LiftUpToSpaceByTonn;
            spaceship.Crew = dto.Crew;
            spaceship.Passengers = dto.Passengers;
            spaceship.LaunchDate = dto.LaunchDate;
            spaceship.BuildOfDate = dto.BuildOfDate;
            spaceship.CreatedAt = dto.CreatedAt;
            spaceship.ModifiedAt = dto.ModifiedAt;

            if (dto.Files != null)
            {
               _files.UploadFileToDatabase(dto, spaceship);
                //file.ImageData = _files.UploadFileToDatabase(dto, spaceship);
            }

            await _context.Spaceship.AddAsync(spaceship);
            await _context.SaveChangesAsync();

            return spaceship;

        }

        public async Task<Spaceship> GetAsync(Guid id)
        {
            var result = await _context.Spaceship
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Spaceship> Update(SpaceshipDto dto)
        {
            FileToDatabase file = new FileToDatabase();

            var spaceship = new Spaceship()
            {
                Id = dto.Id,
                Name = dto.Name,
                ModelType = dto.ModelType,
                SpaceshipBuilder = dto.SpaceshipBuilder,
                PlaceOfBuild = dto.PlaceOfBuild,
                EnginePower = dto.EnginePower,
                LiftUpToSpaceByTonn = dto.LiftUpToSpaceByTonn,
                Crew = dto.Crew,
                Passengers = dto.Passengers,
                LaunchDate = dto.LaunchDate,
                BuildOfDate = dto.BuildOfDate,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = dto.ModifiedAt
            };


            if (dto.Files != null)
            {
                _files.UploadFileToDatabase(dto, spaceship);
            }

            _context.Spaceship.Update(spaceship);
            await _context.SaveChangesAsync();
            return spaceship;
        }

        public async Task<Spaceship> Delete(Guid id)
        {
            var spaceshipId= await _context.Spaceship
              .Include(x => x.FileToDatabases)
              .FirstOrDefaultAsync(x => x.Id == id);

            var photos = await _context.FileToDatabase
                .Where(x => x.SpaceshipId == id)
                .Select(y => new FileToDatabaseDto
                    {
                        Id = y.Id,
                        ImageTitle = y.ImageTitle,
                        SpaceshipId = y.SpaceshipId
                    })
                .ToArrayAsync();

            await _files.RemoveImagesFromDatabase(photos);
            _context.Spaceship.Remove(spaceshipId);
            await _context.SaveChangesAsync();

            return spaceshipId;
        }

    }
}
