using WebApi.Models;

namespace WebApi.DataAccessors
{
    public interface IRegisterDeviceAccessor
    {
        Task RegisterNewDevice(RegisterDevice registerDevice);
    }
}
