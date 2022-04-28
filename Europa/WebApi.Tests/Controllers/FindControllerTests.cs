using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand($"INSERT INTO DeviceInfo VALUES ('{guid}', 'Test Name', 'Test Description', 'Test Owner', 200)", sqlConnection))
                {
                    sqlConnection.Open();
                    await cmd.ExecuteNonQueryAsync();
                    sqlConnection.Close();
                }
            }

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand($"INSERT INTO PositionUpdate VALUES ('{guid}', '10', '110', '2022-04-28')", sqlConnection))
                {
                    sqlConnection.Open();
                    await cmd.ExecuteNonQueryAsync();
                    sqlConnection.Close();
                }
            }

            var position = new Position {
                Latitude = 1,
                Longitude = 130
            };
            var response = await controller.FindNearestActiveDevice(position);
            var nearestPosition = ((ObjectResult)response).Value as NearestPosition;

            Assert.IsNotNull(nearestPosition);
            Assert.IsNotNull(nearestPosition!.Position);
            Assert.That(nearestPosition.Position!.Latitude, Is.EqualTo(10));
            Assert.That(nearestPosition.Position!.Longitude, Is.EqualTo(110));
            Assert.That(nearestPosition.Distance, Is.EqualTo(2427.12956068571));
        }


        [Test]
        public async Task FindNearestActivePosition_When_ThereAreMultipleRowsInDb()
        {
            // Arrange
            var serviceProvider = InjectionModule.Register(new ServiceCollection());
            var controller = serviceProvider.GetRequiredService<FindController>();
            var guid = Guid.NewGuid();

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand($"INSERT INTO DeviceInfo VALUES ('{guid}', 'Test Name', 'Test Description', 'Test Owner', 200)", sqlConnection))
                {
                    sqlConnection.Open();
                    await cmd.ExecuteNonQueryAsync();
                    sqlConnection.Close();
                }
            }

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                using (var cmd = new SqlCommand($"INSERT INTO PositionUpdate VALUES ('{guid}', '10', '110', '2022-04-28')", sqlConnection))
                {
                    await cmd.ExecuteNonQueryAsync();
                }
                using (var cmd = new SqlCommand($"INSERT INTO PositionUpdate VALUES ('{guid}', '30', '130', '2022-04-28')", sqlConnection))
                {
                    await cmd.ExecuteNonQueryAsync();
                }
                sqlConnection.Close();
            }

            var position = new Position
            {
                Latitude = 10,
                Longitude = 130
            };
            var response = await controller.FindNearestActiveDevice(position);
            var nearestPosition = ((ObjectResult)response).Value as NearestPosition;

            Assert.IsNotNull(nearestPosition);
            Assert.IsNotNull(nearestPosition!.Position);
            Assert.That(nearestPosition.Position!.Latitude, Is.EqualTo(10));
            Assert.That(nearestPosition.Position!.Longitude, Is.EqualTo(110));
            Assert.That(nearestPosition.Distance, Is.EqualTo(2189.7730536778527));
        }
    }
}
