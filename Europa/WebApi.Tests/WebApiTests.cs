using Microsoft.Extensions.Configuration;
using NUnit.Framework;
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
    }
}
