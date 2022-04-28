using WebApi.Models;

namespace WebApi.DataAccessors
{
    public interface IFindAccessor
    {
        Task<NearestPosition> FindNearestActivePosition(Position position);
    }
}
