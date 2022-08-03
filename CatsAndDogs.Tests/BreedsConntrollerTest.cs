using CatsAndDogs.Api.Controllers.v1;
using CatsAndDogs.Business.Interfaces;
using CatsAndDogs.Business.Models;
using CatsAndDogs.Tests.MockData;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CatsAndDogs.Tests
{
    /// <summary>
    /// Class for testing the CatsAndDogsBreedsServices
    /// </summary>
    public class CatsAndDogsBreedsServicesTest
    {
        #region == Get Action ==
        [Fact]
        public async Task GetAllBreeds_ShouldReturn200Status()
        {
            // Arrange
            int page = 1;
            int limit = 20;

            var service = new Mock<ICatsAndDogsBreedsServices>();
            service.Setup(s => s.GetAllBreeds(new CancellationToken(), page, limit))
                .ReturnsAsync(GetBreedsMockData.GetFact1PageLimit20MockData());
            var controller = new BreedsController(service.Object);

            // Act
            var result = (OkObjectResult)await controller.Get(new CancellationToken(), page, limit);

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetAllBreeds_ShouldReturn400StatusNegativePage()
        {
            // Arrange
            int page = -1;
            int limit = 20;

            var service = new Mock<ICatsAndDogsBreedsServices>();
            service.Setup(s => s.GetAllBreeds(new CancellationToken(), page, limit))
                .ReturnsAsync(GetBreedsMockData.GetFact1PageLimit20MockData());
            var controller = new BreedsController(service.Object);

            // Act
            var result = (BadRequestObjectResult)await controller.Get(new CancellationToken(), page, limit);

            // Assert
            result.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task GetAllBreeds_ShouldReturn400StatusNegativeLimit()
        {
            // Arrange
            int page = 1;
            int limit = -5;

            var service = new Mock<ICatsAndDogsBreedsServices>();
            service.Setup(s => s.GetAllBreeds(new CancellationToken(), page, limit))
                .ReturnsAsync(GetBreedsMockData.GetFact1PageLimit20MockData());
            var controller = new BreedsController(service.Object);

            // Act
            var result = (BadRequestObjectResult)await controller.Get(new CancellationToken(), page, limit);

            // Assert
            result.StatusCode.Should().Be(400);
        }
        #endregion

        #region == GetImageListByBreed Action ==
        [Fact]
        public async Task GetImageListByBreed_ShouldReturn200Status()
        {
            // Arrange
            int page = 1;
            int limit = 20;
            var petList = new List<Pet>()
            {
                new Pet
                {
                    Id = "siam",
                },
            };

            var service = new Mock<ICatsAndDogsBreedsServices>();
            service.Setup(s => s.SearchBreed("Siamese", new CancellationToken(), page, limit))
                .ReturnsAsync(GetBreedsMockData.GetFact1PageLimit20MockData());
            service.Setup(s => s.GetImages(petList, new CancellationToken(), page, limit))
                .ReturnsAsync();
            var controller = new BreedsController(service.Object);

            // Act
            var result = (OkObjectResult)await controller.GetImageListByBreed("Siamese", new CancellationToken(), page, limit);

            // Assert
            result.StatusCode.Should().Be(200);
        }
        #endregion
    }
}