using Microsoft.SqlServer.Dac;
using System.Data.SqlClient;

namespace DatabaseDeployment
{
    public static class Deployer
    {
        public static void Deploy(bool deleteOldDatabaseIfPresent = true)
        {
            if (deleteOldDatabaseIfPresent)
            {
                Delete();
            }

            var dacServices = new DacServices("Server=localhost;Database=SpaceExplorationPositionTracker;Trusted_Connection=True;");
            using (var dacPackage = DacPackage.Load("../../../../Database/bin/Debug/Database.dacpac"))
            {
                dacServices.Deploy(dacPackage, "SpaceExplorationPositionTracker", true);
            }
        }

        public static void Delete()
        {
            using (var sqlConnection = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;"))
            {
                sqlConnection.Open();
                var sqlCommand = new SqlCommand("DROP DATABASE SpaceExplorationPositionTracker", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}
