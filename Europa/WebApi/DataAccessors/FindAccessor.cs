using System.Data;
using System.Data.SqlClient;
using WebApi.Models;

namespace WebApi.DataAccessors
{
    public class FindAccessor : IFindAccessor
    {
        string ConnectionString { get; } = "Server=localhost;Database=SpaceExplorationPositionTracker;Trusted_Connection=True;";

        public async Task<NearestPosition> FindNearestActivePosition(Position position)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand("FindNearestActiveDevice", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@lat", position.Latitude);
                    cmd.Parameters.AddWithValue("@lon", position.Longitude);

                    sqlConnection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var latitude = reader.GetDecimal(1);
                        var longitude = reader.GetDecimal(2);
                        var dateTime = reader.GetDateTimeOffset(3);
                        var distance = reader.GetDouble(4);

                        return new NearestPosition
                        {
                            Position = new Position
                            {
                                Latitude = latitude,
                                Longitude = longitude
                            },
                            Distance = distance,
                            DateTime = dateTime
                        };
                    }
                    sqlConnection.Close();
                }
            }
            return new NearestPosition();
        }
    }
}
