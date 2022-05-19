using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.Models;

namespace WebApi.Tests.Controllers
{
    [TestFixture]
    public class FindControllerTests : WebApiTests
    {
        [Test]
        public async Task FindNearestActivePosition_When_ThereIsDataInDb()
        {
            // Arrange
            var serviceProvider = InjectionModule.Register(new ServiceCollection());
            var controller = serviceProvider.GetRequiredService<FindController>();
            var guid = Guid.NewGuid();
            await AddCelestialObjectInfo(new[] { ( "Radius", "6371" ) });
            await AddDeviceInfo(guid, "Test Name", "Test Description", "Test Owner", 200);
            await AddPositionUpdate(guid, 10, 110, DateTimeOffset.Now);
            var position = new Position {
                Latitude = 1,
                Longitude = 130
            };

            // Act
            var response = await controller.FindNearestActiveDevice(position);

            // Assert
            var nearestPosition = ((ObjectResult)response).Value as NearestPosition;
            Assert.IsNotNull(nearestPosition);
            Assert.That(nearestPosition!.Latitude, Is.EqualTo(10));
            Assert.That(nearestPosition!.Longitude, Is.EqualTo(110));
            Assert.That(nearestPosition!.Distance, Is.EqualTo(2427.12956068571));
        }


        [Test]
        public async Task FindNearestActivePosition_When_ThereAreMultipleRowsInDb()
        {
            // Arrange
            var serviceProvider = InjectionModule.Register(new ServiceCollection());
            var controller = serviceProvider.GetRequiredService<FindController>();
            var guid = Guid.NewGuid();
            await AddCelestialObjectInfo(new[] { ("Radius", "6371") });
            await AddDeviceInfo(guid, "Test Name", "Test Description", "Test Owner", 200);
            await AddPositionUpdate(guid, 10, 110, DateTimeOffset.Now);
            await AddPositionUpdate(guid, 30, 130, DateTimeOffset.Now);
            var position = new Position
            {
                Latitude = 10,
                Longitude = 130
            };

            // Act
            var response = await controller.FindNearestActiveDevice(position);

            // Assert
            var nearestPosition = ((ObjectResult)response).Value as NearestPosition;
            Assert.IsNotNull(nearestPosition);
            Assert.That(nearestPosition!.Latitude, Is.EqualTo(10));
            Assert.That(nearestPosition!.Longitude, Is.EqualTo(110));
            Assert.That(nearestPosition.Distance, Is.EqualTo(2189.7730536778527));
        }
    }
}
