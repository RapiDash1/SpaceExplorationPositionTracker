using Microsoft.Extensions.Configuration;
using Microsoft.SqlServer.Dac;
using NUnit.Framework;
using System.Data.SqlClient;

namespace WebApi.Tests
{
    [SetUpFixture]
    public class Setup
    {
        [OneTimeSetUp]
        public void DeployDatabase()
        {
            var dacServices = new DacServices("Server=localhost;Database=SpaceExplorationPositionTracker;Trusted_Connection=True;");
            using (var dacPackage = DacPackage.Load("../../../../Database/bin/Debug/Database.dacpac"))
            {
                dacServices.Deploy(dacPackage, "SpaceExplorationPositionTracker", true);
            }
        }

        [OneTimeTearDown]
        public void TearDownDatabase()
        {
            /*using (var sqlConnection = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;"))
            {
                sqlConnection.Open();
                var sqlCommand = new SqlCommand("DROP DATABASE SpaceExplorationPositionTracker", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }*/
        }
    }
}
