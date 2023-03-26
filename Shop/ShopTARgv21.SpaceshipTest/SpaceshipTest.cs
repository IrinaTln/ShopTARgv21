using Microsoft.AspNetCore.Mvc;
using ShopTARgv21.Core.Domain;
using ShopTARgv21.Core.Dto;
using System.Collections;
using System.Xml.Linq;

namespace ShopTARgv21.SpaceshipTest
{
    public class SpaceshipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceShip_WhenReturnResult()
        {
            string guid = Guid.NewGuid().ToString();
            string guid2 = "9f0674c4-1ddc-4415-9ea2-a0502ac4913b";

            SpaceshipDto spaceship = new SpaceshipDto();

            spaceship.Id = Guid.Parse(guid);
            spaceship.Name = "asd";
            spaceship.ModelType = "asd";
            spaceship.SpaceshipBuilder = "asd";
            spaceship.PlaceOfBuild = "asd";
            spaceship.EnginePower = 1;
            spaceship.LiftUpToSpaceByTonn = 1;
            spaceship.Crew = 1;
            spaceship.Passengers = "3";
            spaceship.LaunchDate = DateTime.Now;
            spaceship.BuildOfDate = DateTime.Now;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            var result = await Svc<ISpaceShipServices>().Create(spaceship);

            Assert.NotNull(result);
        }

        [Fact]

        public async Task ShouldNot_GetByIdSpaceship_WhenRetunsNotEqual()
        {
            Guid guid = Guid.Parse("9f0674c4-1ddc-4415-9ea2-a0502ac4913b");
            Guid guid1 = Guid.Parse(Guid.NewGuid().ToString());

            await Svc<ISpaceShipServices>().GetAsync(guid);

            Assert.NotEqual(guid, guid1);
        }

        [Fact]

        public async Task Should_GetByIdSpaceship_WhenRetunsEqual()
        {
            Guid guid = Guid.Parse("9f0674c4-1ddc-4415-9ea2-a0502ac4913b");
            Guid guid1 = Guid.Parse("9f0674c4-1ddc-4415-9ea2-a0502ac4913b");

            await Svc<ISpaceShipServices>().GetAsync(guid);

            Assert.Equal(guid, guid1);
        }

        [Fact]

        public async Task Should_DeleteByIdSpaceShip_WhenDeleteSpaceship()
        {
            //Arrange
            SpaceshipDto spaceship = CreateValidSpaceShip();
            var createdSpaceship = await Svc<ISpaceShipServices>().Create(spaceship);

            //Act
            var result = await Svc<ISpaceShipServices>().Delete((Guid)createdSpaceship.Id);

            //Assert
            Assert.Equal(createdSpaceship, result);
            
        }

        [Fact]
        public async Task Should_UpdateByIdSpaceship_WhenUpdateSpaceship()
        {
            Spaceship spaceship = new();

            spaceship.Id = new Guid("9f0674c4-1ddc-4415-9ea2-a0502ac4913b");
            spaceship.Name = "Name";
            spaceship.ModelType = "asd";
            spaceship.SpaceshipBuilder = "asd";
            spaceship.PlaceOfBuild = "asd";
            spaceship.EnginePower = 123;
            spaceship.LiftUpToSpaceByTonn = 123;
            spaceship.Crew = 5;
            spaceship.Passengers = "2";
            spaceship.LaunchDate = DateTime.Now;
            spaceship.BuildOfDate = DateTime.Now;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            var spaceshipId = new Guid("9f0674c4-1ddc-4415-9ea2-a0502ac4913b");
            var spaceshipToUpdate = new SpaceshipDto()
            {
                Name = "Asd",
                EnginePower = 456,
                ModelType = "dsa",
                Passengers = "1",
                PlaceOfBuild = "fds",
                SpaceshipBuilder = "x"
            };

            await Svc<ISpaceShipServices>().Update(spaceshipToUpdate);

            Assert.NotEqual(spaceship.Name, spaceshipToUpdate.Name);
            Assert.DoesNotMatch(spaceship.ModelType, spaceshipToUpdate.ModelType);
            Assert.NotSame(spaceship, spaceshipToUpdate);
            Assert.Equal(spaceship.Id, spaceshipId);
 
        }

        [Fact]
        public async Task ShouldUpdate_ValidSpaceship_WhenBeUpdated() 
        {
            SpaceshipDto spaceship = CreateValidSpaceShip();
            await Svc<ISpaceShipServices>().Create(spaceship);

            SpaceshipDto updatedSpaceship = UpdateValidSpaship(spaceship);

            var result = await Svc<ISpaceShipServices>().Update(updatedSpaceship);

            Assert.NotEqual(updatedSpaceship.Name, result.Name);
            Assert.NotEqual(updatedSpaceship.ModelType, result.ModelType);
            Assert.NotEqual(updatedSpaceship.SpaceshipBuilder, result.SpaceshipBuilder);
            Assert.NotEqual(updatedSpaceship.PlaceOfBuild, result.PlaceOfBuild);
            Assert.NotEqual(updatedSpaceship.EnginePower, result.EnginePower);
            Assert.NotEqual(updatedSpaceship.LiftUpToSpaceByTonn, result.LiftUpToSpaceByTonn);
            Assert.NotEqual(updatedSpaceship.Crew, result.Crew);
            Assert.NotEqual(updatedSpaceship.Passengers, result.Passengers);
            Assert.NotEqual(updatedSpaceship.LaunchDate, result.LaunchDate);
            Assert.NotEqual(updatedSpaceship.BuildOfDate, result.BuildOfDate);
            Assert.NotEqual(updatedSpaceship.CreatedAt, result.CreatedAt);
            Assert.NotEqual(updatedSpaceship.ModifiedAt, result.ModifiedAt);
        }
        

        private SpaceshipDto CreateValidSpaceShip()
        {
            SpaceshipDto spaceship = new()
            {
                Id = Guid.NewGuid(),
                Name = "asd",
                ModelType = "asd",
                SpaceshipBuilder = "asd",
                PlaceOfBuild = "asd",
                EnginePower = 123,
                LiftUpToSpaceByTonn = 123,
                Crew= 2,
                Passengers = "2",
                LaunchDate = DateTime.Now,
                BuildOfDate = DateTime.Now,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            return spaceship;
        }

        private SpaceshipDto UpdateValidSpaship(SpaceshipDto spaceship)
        {
            spaceship.Id = Guid.NewGuid();
            spaceship.Name = "asd";
            spaceship.ModelType = "asd";
            spaceship.SpaceshipBuilder = "asd";
            spaceship.PlaceOfBuild = "asd";
            spaceship.EnginePower = 123;
            spaceship.LiftUpToSpaceByTonn = 123;
            spaceship.Crew = 2;
            spaceship.Passengers = "2";
            spaceship.LaunchDate = DateTime.Now;
            spaceship.BuildOfDate = DateTime.Now;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;
            
            return spaceship;
        }
    }
}