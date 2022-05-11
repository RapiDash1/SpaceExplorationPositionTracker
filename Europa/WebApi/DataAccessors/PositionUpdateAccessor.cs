using Dapper;
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
                sqlConnection.Open();
                await sqlConnection.ExecuteAsync(
                    "AddPositionUpdate", 
                    new 
                    { 
                        deviceKey = positionUpdate.DeviceKey, 
                        latitude = positionUpdate.Latitude, 
                        longitude = positionUpdate.Longitude, 
                        dateTime = positionUpdate.DateTime 
                    }, 
                    commandType: CommandType.StoredProcedure);
                sqlConnection.Close();
            }
        }
    }
}
