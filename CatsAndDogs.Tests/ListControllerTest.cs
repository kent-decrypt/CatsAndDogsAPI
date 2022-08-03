using CatsAndDogs.Api.Controllers.v1;
using CatsAndDogs.Business.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tests.CatsAndDogs.MockData;

namespace Tests.CatsAndDogs
{
    /// <summary>
    /// Class for testing the ListController
    /// </summary>
    public class ListControllerTest
    {
        private readonly Mock<ICatsAndDogsListService> service;
        private readonly CancellationToken cancellationToken;

        /// <summary>
        /// Constructor for the BreedsControllerTest, creates new instance of Mock(ICatsAndDogsListService) and cancellation token
        /// </summary>
        public ListControllerTest()
        {
            service = new Mock<ICatsAndDogsListService>();
            cancellationToken = new CancellationToken();
        }

        [Fact]
        public async Task GetList_ShouldReturn200Status()
        {
            // Arrange
            int page = 1;
            int limit = 20;

            service.Setup(s => s.GetList(cancellationToken, page, limit))
                .ReturnsAsync(GetListMockData.GetList_1Page_20Limit_ListImageMockData());
            var controller = new ListController(service.Object);

            // Act
            var result = (OkObjectResult)await controller.GetList(cancellationToken, page, limit);

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetList_ShouldReturn400Status_NegativePage()
        {
            // Arrange
            int page = -1;
            int limit = 20;

            service.Setup(s => s.GetList(cancellationToken, page, limit))
                .ReturnsAsync(GetListMockData.GetList_Negative1Page_20Limit_ListImageMockData());
            var controller = new ListController(service.Object);

            // Act
            var result = (BadRequestObjectResult)await controller.GetList(cancellationToken, page, limit);

            // Assert
            result.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task GetList_ShouldReturn400Status_NegativeLimit()
        {
            // Arrange
            int page = 1;
            int limit = -20;

            service.Setup(s => s.GetList(cancellationToken, page, limit))
                .ReturnsAsync(GetListMockData.GetList_1Page_Negative20Limit_ListImageMockData());
            var controller = new ListController(service.Object);

            // Act
            var result = (BadRequestObjectResult)await controller.GetList(cancellationToken, page, limit);

            // Assert
            result.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task GetList_ShouldReturn400Status_MoreThan100Limit()
        {
            // Arrange
            int page = 1;
            int limit = 999;

            var service = new Mock<ICatsAndDogsListService>();
            service.Setup(s => s.GetList(cancellationToken, page, limit))
                .ReturnsAsync(GetListMockData.GetList_1Page_MoreThan100Limit_ListImageMockData());
            var controller = new ListController(service.Object);

            // Act
            var result = (BadRequestObjectResult)await controller.GetList(cancellationToken, page, limit);

            // Assert
            result.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task GetList_ShouldReturn500Status_ExceptionEncountered()
        {
            // Arrange
            int page = 99999999;
            int limit = 99;

            var service = new Mock<ICatsAndDogsListService>();
            service.Setup(s => s.GetList(cancellationToken, page, limit))
                .Throws(new Exception("Test Exception"));
            var controller = new ListController(service.Object);

            // Act
            var result = (ObjectResult)await controller.GetList(cancellationToken, page, limit);

            // Assert
            result.StatusCode.Should().Be(500);
        }
    }
}
