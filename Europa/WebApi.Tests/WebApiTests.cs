using NUnit.Framework;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace WebApi.Tests
{
    public class WebApiTests
    {
        public string ConnectionString { get; set; }

        public WebApiTests()
        {
            ConnectionString = "Server=localhost;Database=SpaceExplorationPositionTracker;Trusted_Connection=True;";
        }

        [SetUp]
        public async Task SetUp()
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand("EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'; EXEC sp_MSForEachTable 'DELETE ?'; EXEC sp_MSForEachTable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL';", sqlConnection))
                {
                    sqlConnection.Open();
                    await cmd.ExecuteNonQueryAsync();
                    sqlConnection.Close();
                }
            }
        }

        protected async Task AddDeviceInfo(Guid guid, string name, string description, string owner, decimal weight)
        {

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand($"INSERT INTO DeviceInfo VALUES ('{guid}', '{name}', '{description}', '{owner}', {weight})", sqlConnection))
                {
                    sqlConnection.Open();
                    await cmd.ExecuteNonQueryAsync();
                    sqlConnection.Close();
                }
            }
        }

        protected async Task AddPositionUpdate(Guid guid, decimal latitude, decimal longitude, DateTimeOffset dateTime)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand($"INSERT INTO PositionUpdate VALUES ('{guid}', '{latitude}', '{longitude}', '{dateTime.ToString("yyyy-MM-dd HH:mm:ss")}')", sqlConnection))
                {
                    sqlConnection.Open();
                    await cmd.ExecuteNonQueryAsync();
                    sqlConnection.Close();
                }
            }
        }
    }
}
