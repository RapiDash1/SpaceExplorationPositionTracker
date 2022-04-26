using System.Data;
using System.Data.SqlClient;
using WebApi.Models;

namespace WebApi.DataAccessors
{
    public class RegisterDeviceAccessor : IRegisterDeviceAccessor
    {
        string ConnectionString { get; } = "Server=localhost;Database=SpaceExplorationPositionTracker;Trusted_Connection=True;";

        public async Task<Guid> RegisterNewDevice(RegisterDevice registerDevice)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand("RegisterNewDevice", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var deviceKey = Guid.NewGuid();
                    cmd.Parameters.AddWithValue("@name", registerDevice.Name);
                    cmd.Parameters.AddWithValue("@deviceKey", deviceKey);
                    cmd.Parameters.AddWithValue("@description", registerDevice.Description);
                    cmd.Parameters.AddWithValue("@owner", registerDevice.Owner);
                    cmd.Parameters.AddWithValue("@weight", registerDevice.Weight);

                    sqlConnection.Open();
                    await cmd.ExecuteNonQueryAsync();
                    sqlConnection.Close();

                    return deviceKey;
                }
            }
        }
    }
}
