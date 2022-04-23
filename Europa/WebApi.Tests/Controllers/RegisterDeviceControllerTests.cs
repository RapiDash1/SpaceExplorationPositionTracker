using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using WebApi.Controllers;
using WebApi.Models;

namespace WebApi.Tests
{
    public class RegisterDeviceControllerTests
    {
        [Test]
        public void ReturnSuccess_When_ValidRegistrationDataIsReceived()
        {
            var controller = new RegisterDeviceController();
            var registerDevice = new RegisterDevice { Name = "TestName" };

            var response = controller.Register(registerDevice);
            var statucCodeResult = (StatusCodeResult)response;
            Assert.That(statucCodeResult.StatusCode, Is.EqualTo(200));
        }
    }
}