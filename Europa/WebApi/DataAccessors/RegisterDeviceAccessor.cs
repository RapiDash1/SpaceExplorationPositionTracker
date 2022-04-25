using System.Data;
using System.Data.SqlClient;
using WebApi.Models;

namespace WebApi.DataAccessors
{
    public class RegisterDeviceAccessor : IRegisterDeviceAccessor
    {
        string ConnectionString { get; } = "Server=localhost;Database=SpaceExplorationPositionTracker;Trusted_Connection=True;";

        public async Task RegisterNewDevice(RegisterDevice registerDevice)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand("RegisterNewDevice", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", registerDevice.Name);
                    cmd.Parameters.AddWithValue("@description", registerDevice.Description);
                    cmd.Parameters.AddWithValue("@owner", registerDevice.Owner);
                    cmd.Parameters.AddWithValue("@weight", registerDevice.Weight);

                    sqlConnection.Open();
                    await cmd.ExecuteNonQueryAsync();
                    sqlConnection.Close();
                }
            }
        }
    }
}
