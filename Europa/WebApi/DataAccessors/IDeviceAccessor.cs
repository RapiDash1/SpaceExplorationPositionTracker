using WebApi.Models;

namespace WebApi.DataAccessors
{
    public interface IDeviceAccessor
    {
        Task<Guid> RegisterNewDevice(Device registerDevice);
    }
}
