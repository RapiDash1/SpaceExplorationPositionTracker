using WebApi.Models;

namespace WebApi.DataAccessors
{
    public interface IRegisterDeviceAccessor
    {
        Task<Guid> RegisterNewDevice(RegisterDevice registerDevice);
    }
}
