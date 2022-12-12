using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopTARgv21.Core.Domain;
using ShopTARgv21.Core.Dto;
using ShopTARgv21.Core.ServiceInterface;
using ShopTARgv21.Data;


namespace ShopTARgv21.ApplicationServices
{
    public class SpaceShipServices : ISpaceShipServices

    {
        private readonly ShopDbContext _context;
        public SpaceShipServices 
            (
                ShopDbContext context
            )
        {
            _context = context;
        }
        public async Task<Spaceship> Add(SpaceshipDto dto)
        {
            Spaceship spaceship = new Spaceship();

            spaceship.Id = dto.Id;
            spaceship.Name = dto.Name;
            spaceship.ModelType=dto.ModelType;
            spaceship.PlaceOfBuild = dto.PlaceOfBuild;
            spaceship.EnginePower = dto.EnginePower;
            spaceship.SpaceshipBuilder = dto.SpaceshipBuilder;
            spaceship.LiftUpToSpaceByTonn=dto.LiftUpToSpaceByTonn;
            spaceship.Crew = dto.Crew;
            spaceship.Passengers = dto.Passengers;
            spaceship.LaunchDate = dto.LaunchDate;
            spaceship.BuildOfDate = dto.BuildOfDate;
            spaceship.CreatedAt = dto.CreatedAt;
            spaceship.ModifiedAt = dto.ModifiedAt;

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

            _context.Spaceship.Update(spaceship);
            await _context.SaveChangesAsync();
            return spaceship;
        }

        public async Task<Spaceship> Delete(Guid id)
        {
            var spaceship = await _context.Spaceship
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Spaceship.Remove(spaceship);
            await _context.SaveChangesAsync();

            return spaceship;
        }
    }
}
