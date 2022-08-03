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
    /// Class for testing the BreedsController
    /// </summary>
    public class BreedsControllerTest
    {
        private readonly Mock<ICatsAndDogsBreedsService> service;
        private readonly CancellationToken cancellationToken;

        /// <summary>
        /// Constructor for the BreedsControllerTest, creates new instance of Mock(ICatsAndDogsBreedsService) and cancellation token
        /// </summary>
        public BreedsControllerTest()
        {
            service = new Mock<ICatsAndDogsBreedsService>();
            cancellationToken = new CancellationToken();
        }

        #region == Get Action ==
        [Fact]
        public async Task GetAllBreeds_ShouldReturn200Status()
        {
            // Arrange
            int page = 1;
            int limit = 20;

            service.Setup(s => s.GetAllBreeds(cancellationToken, page, limit))
                .ReturnsAsync(GetBreedsMockData.GeBreeds_1Page_20Limit_MockData());
            var controller = new BreedsController(service.Object);

            // Act
            var result = (OkObjectResult)await controller.GetBreeds(cancellationToken, page, limit);

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetAllBreeds_ShouldReturn400Status_NegativePage()
        {
            // Arrange
            int page = -1;
            int limit = 20;

            service.Setup(s => s.GetAllBreeds(cancellationToken, page, limit))
                .ReturnsAsync(GetBreedsMockData.GeBreeds_1Page_20Limit_MockData());
            var controller = new BreedsController(service.Object);

            // Act
            var result = (BadRequestObjectResult)await controller.GetBreeds(cancellationToken, page, limit);

            // Assert
            result.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task GetAllBreeds_ShouldReturn400Status_NegativeLimit()
        {
            // Arrange
            int page = 1;
            int limit = -5;

            service.Setup(s => s.GetAllBreeds(cancellationToken, page, limit))
                .ReturnsAsync(GetBreedsMockData.GeBreeds_1Page_20Limit_MockData());
            var controller = new BreedsController(service.Object);

            // Act
            var result = (BadRequestObjectResult)await controller.GetBreeds(cancellationToken, page, limit);

            // Assert
            result.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task GetAllBreeds_ShouldReturn500Status_ExceptionEncountered()
        {
            // Arrange
            int page = 99999999;
            int limit = 99;

            service.Setup(s => s.GetAllBreeds(cancellationToken, page, limit))
                .Throws(new Exception("Test Exception"));
            var controller = new BreedsController(service.Object);

            // Act
            var result = (ObjectResult)await controller.GetBreeds(cancellationToken, page, limit);

            // Assert
            result.StatusCode.Should().Be(500);
        }
        #endregion

        #region == GetImageListByBreed Action ==
        [Fact]
        public async Task GetImageListByBreed_ShouldReturn200Status()
        {
            // Arrange
            int page = 1;
            int limit = 20;
            var petList = new List<Pet>
            {
                new Pet { Id = "siam" }
            };


            service.Setup(s => s.GetImages(petList, cancellationToken, page, limit))
                .ReturnsAsync(GetBreedsMockData.GetBreeds_1Page_20Limit_PetImageListMockData());

            service.Setup(s => s.SearchBreed("Siamese", cancellationToken, page, limit))
                .ReturnsAsync(GetBreedsMockData.GetSearchBreed_1Page_20Limit_MockData());

            var controller = new BreedsController(service.Object);

            // Act
            var result = (ObjectResult)await controller.GetImageListByBreed("Siamese", cancellationToken, page, limit);

            // Assert
            result.StatusCode.Should().Be(200);
        }
        #endregion
    }
}