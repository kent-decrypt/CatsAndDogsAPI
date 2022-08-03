using CatsAndDogs.Api.Controllers.v1;
using CatsAndDogs.Business.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tests.CatsAndDogs.MockData;

namespace Tests.CatsAndDogs
{
    /// <summary>
    /// Class for testing the ImagesController
    /// </summary>
    public class ImagesControllerTest
    {
        private readonly Mock<ICatsAndDogsImageService> service;
        private readonly CancellationToken cancellationToken;

        /// <summary>
        /// Constructor for the BreedsControllerTest, creates new instance of Mock(ICatsAndDogsImageService) and cancellation token
        /// </summary>
        public ImagesControllerTest()
        {
            service = new Mock<ICatsAndDogsImageService>();
            cancellationToken = new CancellationToken();
        }

        [Fact]
        public async Task GetImage_ShouldReturn200Status()
        {
            // Arrange
            string imageId = "11egN-Kkf";

            service.Setup(s => s.GetImage(imageId, new CancellationToken()))
                .ReturnsAsync(GetImageMockData.GetValidImage());
            var controller = new ImagesController(service.Object);

            // Act
            var result = (OkObjectResult)await controller.GetImage(imageId, new CancellationToken());

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetImage_ShouldReturn400Status_ImageIdRequired()
        {
            // Arrange
            string imageId = "";

            service.Setup(s => s.GetImage(imageId, new CancellationToken()))
                .ReturnsAsync(GetImageMockData.GetValidImage());
            var controller = new ImagesController(service.Object);

            // Act
            var result = (BadRequestObjectResult)await controller.GetImage(imageId, new CancellationToken());

            // Assert
            result.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task GetImage_ShouldReturn500Status_ExceptionEncountered()
        {
            // Arrange
            string imageId = "-978";

            service.Setup(s => s.GetImage(imageId, new CancellationToken()))
                .Throws(new Exception("Test Exception"));
            var controller = new ImagesController(service.Object);

            // Act
            var result = (ObjectResult)await controller.GetImage(imageId, new CancellationToken());

            // Assert
            result.StatusCode.Should().Be(500);
        }
    }
}
