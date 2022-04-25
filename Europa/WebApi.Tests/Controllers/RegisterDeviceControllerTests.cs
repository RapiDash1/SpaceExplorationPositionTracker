using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.Models;

namespace WebApi.Tests.Controllers
{
    [TestFixture]
    public class RegisterDeviceControllerTests : WebApiTests
    {
        [Test]
        public async Task ReturnSuccess_When_ValidRegistrationDataIsReceived()
        {
            // Arrange
            var serviceProvider = InjectionModule.Register(new ServiceCollection());
            var controller = serviceProvider.GetRequiredService<RegisterDeviceController>();
            var registerDevice = new RegisterDevice { 
                Name = "Test Name",
                Description = "Test Description",
                Owner = "Test Owner",
                Weight = 10
            };

            // Act
            var response = await controller.Register(registerDevice);

            // Assert
            var statusCodeResult = (StatusCodeResult)response;
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public async Task ReturnError_When_InvalidRegistrationDataIsReceived()
        {
            // Arrange
            var serviceProvider = InjectionModule.Register(new ServiceCollection());
            var controller = serviceProvider.GetRequiredService<RegisterDeviceController>();
            var registerDevice = new RegisterDevice
            {
                Owner = "Test Owner",
                Weight = 10
            };

            // Act
            var response = await controller.Register(registerDevice);

            // Assert
            var objectResult = (ObjectResult)response;
            Assert.That(objectResult.StatusCode, Is.EqualTo(400));
            Assert.That(objectResult.Value, Is.EqualTo(new List<string> { "Name cannot be Null or Empty", "Description cannot be Null or Empty" }));
        }
    }
}