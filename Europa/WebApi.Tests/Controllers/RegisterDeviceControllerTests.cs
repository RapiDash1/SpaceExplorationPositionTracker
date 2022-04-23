using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;
using WebApi.Controllers;
using WebApi.Models;

namespace WebApi.Tests.Controllers
{
    [TestFixture]
    public class RegisterDeviceControllerTests
    {
        [Test]
        public void ReturnSuccess_When_ValidRegistrationDataIsReceived()
        {
            // Arrange
            var controller = new RegisterDeviceController();
            var registerDevice = new RegisterDevice { 
                Name = "Test Name",
                Description = "Test Description",
                Owner = "Test Owner",
                Weight = 10
            };

            // Act
            var response = controller.Register(registerDevice);

            // Assert
            var statusCodeResult = (StatusCodeResult)response;
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void ReturnError_When_InvalidRegistrationDataIsReceived()
        {
            // Arrange
            var controller = new RegisterDeviceController();
            var registerDevice = new RegisterDevice
            {
                Owner = "Test Owner",
                Weight = 10
            };

            // Act
            var response = controller.Register(registerDevice);

            // Assert
            var objectResult = (ObjectResult)response;
            Assert.That(objectResult.StatusCode, Is.EqualTo(400));
            Assert.That(objectResult.Value, Is.EqualTo(new List<string> { "Name cannot be Null or Empty", "Description cannot be Null or Empty" }));
        }
    }
}