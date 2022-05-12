using Dapper;
using System.Data;
using System.Data.SqlClient;
using WebApi.Models;

namespace WebApi.DataAccessors
{
    public class DeviceAccessor : IDeviceAccessor
    {
        string ConnectionString { get; } = "Server=localhost;Database=SpaceExplorationPositionTracker;Trusted_Connection=True;";

        public async Task<Guid> RegisterNewDevice(Device registerDevice)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var deviceKey = Guid.NewGuid();

                sqlConnection.Open();
                await sqlConnection.ExecuteAsync(
                    "RegisterNewDevice",
                    new
                    {
                        name = registerDevice.Name,
                        description = registerDevice.Description,
                        deviceKey = deviceKey,
                        owner = registerDevice.Owner,
                        weight = registerDevice.Weight
                    },
                    commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                sqlConnection.Close();

                return deviceKey;
            }
        }
    }
}
