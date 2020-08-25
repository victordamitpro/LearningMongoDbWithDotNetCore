using Electric.API.Controllers;
using Electric.Application.Commands;
using Electric.Application.Queries;
using Electric.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Electric.Test.ControllerTest
{
    public class DeviceControllerTest
    {
        private Mock<IMediator> mockMediator;
        private Mock<IDeviceQuery> mockElectricQuery;
       
        public  DeviceControllerTest()
        {
            mockMediator = new Mock<IMediator>();
            mockElectricQuery = new Mock<IDeviceQuery>();
        }

        [Fact]
        public async Task CreateDeviceItem_AndReturnOK()
        {
            // Arrange
            mockMediator
             .Setup(m => m.Send(It.IsAny<CreateElectricMetterCommand>(), It.IsAny<CancellationToken>()))
             .ReturnsAsync(new Response<string> { });
            var deviceController = new ElectricController(mockMediator.Object, mockElectricQuery.Object);
            // Act
            var actionResult = await deviceController.CreateDevice( new CreateElectricMetterCommand());
            // Assert
            Assert.Equal((actionResult as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetAllDevice_AndReturnOK()
        {
            // Arrange
            mockElectricQuery.Setup(e => e.GetAlls()).Returns(Task.FromResult(new List<DeviceResponse> { }.AsEnumerable()));
            var deviceController = new ElectricController(mockMediator.Object, mockElectricQuery.Object);
            // Act
            var actionResult = await deviceController.GetAll();
            // Assert
            Assert.Equal((actionResult.Result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetAll_ReturnNotFound()
        {
            // Arrange
            mockElectricQuery.Setup(e => e.GetAlls()).Returns(Task.FromResult(new List<DeviceResponse>().AsEnumerable()));
            var deviceController = new ElectricController(mockMediator.Object, mockElectricQuery.Object);
            // Act
            var actionResult = await deviceController.GetAll();
            // Assert
            Assert.Equal((actionResult.Result as NotFoundResult).StatusCode, (int)System.Net.HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetElectric_ReturnOK()
        {
            // Arrange
            string id = string.Empty;
            mockElectricQuery.Setup(e => e.GetDetailElectric(id)).Returns(Task.FromResult(new DeviceResponse()));
            var deviceController = new ElectricController(mockMediator.Object, mockElectricQuery.Object);
            // Act
            var actionResult = await deviceController.GetDetail(id);
            // Assert
            Assert.Equal((actionResult.Result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetElectric_ReturnNotFound()
        {
            // Arrange
            string id = string.Empty;
            var deviceController = new ElectricController(mockMediator.Object, mockElectricQuery.Object);
            // Act
            var actionResult = await deviceController.GetDetail(id);
            // Assert
            Assert.Equal((actionResult.Result as NotFoundResult).StatusCode, (int)System.Net.HttpStatusCode.NotFound);
        }
    }
}
