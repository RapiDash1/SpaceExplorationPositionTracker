using WebApi.Models;

namespace WebApi.DataAccessors
{
    public interface IPositionUpdateAccessor
    {
        Task AddPositionUpdate(PositionUpdate positionUpdate);
    }
}
