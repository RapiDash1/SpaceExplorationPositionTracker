using Dapper;
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
                sqlConnection.Open();
                var nearestPosition = await sqlConnection.QuerySingleAsync<NearestPosition>("FindNearestActiveDevice", new { lat = position.Latitude, lon = position.Longitude }, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                sqlConnection.Close();
                return nearestPosition;
            }
        }
    }
}
