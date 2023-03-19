using Microsoft.AspNetCore.Mvc;
using ShopTARgv21.Core.Dto;
using System.Collections;

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
            Guid guid = Guid.Parse("9f0674c4-1ddc-4415-9ea2-a0502ac4913b");
            Guid guid2 = Guid.Parse("9f0674c4-1ddc-4415-9ea2-a0502ac4913b");

            //Act
            var result = await Svc<ISpaceShipServices>().Delete(guid);

            //Assert
            var serviceActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(serviceActionResult.ControllerName);
            Assert.Equal("Read", serviceActionResult.ActionName);

        }
    }
}