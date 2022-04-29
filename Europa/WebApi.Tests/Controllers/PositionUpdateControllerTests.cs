using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.Models;

namespace WebApi.Tests.Controllers
{
    [TestFixture]
    public class PositionUpdateControllerTests : WebApiTests
    {
        [Test]
        public async Task AddPositionUpdateToDb_When_PositionUpdateIsValid()
        {
            // Arrange
            var serviceProvider = InjectionModule.Register(new ServiceCollection());
            var controller = serviceProvider.GetRequiredService<PositionUpdateController>();
            var guid = Guid.NewGuid();
            var positionUpdate = new PositionUpdate
            {
                DeviceKey = guid,
                Latitude = 12.345678m,
                Longitude = 123.456789m,
                DateTime = new DateTimeOffset(2022, 04, 27, 1, 2, 3, TimeSpan.Zero)
            };
            await AddDeviceInfo(guid, "Test Name", "Test Description", "Test Owner", 200);

            // Act
            var response = await controller.PositionUpdate(positionUpdate);

            // Assert
            var statusCodeResult = (StatusCodeResult)response;
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(200));

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand("SELECT DeviceKey FROM PositionUpdate", sqlConnection))
                {
                    sqlConnection.Open();
                    var actualGuid = await cmd.ExecuteScalarAsync();
                    Assert.That(actualGuid, Is.Not.Null);
                    Assert.That((Guid)actualGuid!, Is.EqualTo(guid));
                    sqlConnection.Close();
                }
            }
        }
    }
}
