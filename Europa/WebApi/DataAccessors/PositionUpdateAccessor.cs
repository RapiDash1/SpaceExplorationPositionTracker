using System.Data;
using System.Data.SqlClient;
using WebApi.Models;

namespace WebApi.DataAccessors
{
    public class PositionUpdateAccessor : IPositionUpdateAccessor
    {
        string ConnectionString { get; } = "Server=localhost;Database=SpaceExplorationPositionTracker;Trusted_Connection=True;";

        public async Task AddPositionUpdate(PositionUpdate positionUpdate)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand("AddPositionUpdate", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@deviceKey", positionUpdate.DeviceKey);
                    cmd.Parameters.AddWithValue("@latitude", positionUpdate.Latitude);
                    cmd.Parameters.AddWithValue("@longitude", positionUpdate.Longitude);
                    cmd.Parameters.AddWithValue("@dateTime", positionUpdate.DateTime);

                    sqlConnection.Open();
                    await cmd.ExecuteNonQueryAsync();
                    sqlConnection.Close();
                }
            }
        }
    }
}
