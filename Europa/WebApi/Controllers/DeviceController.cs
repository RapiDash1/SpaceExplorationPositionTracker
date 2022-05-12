using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccessors;
using WebApi.Extensions;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        public IDeviceAccessor accessor { get; set; }

        public DeviceController(IDeviceAccessor accessor)
        {
            this.accessor = accessor;
        }

        [Route("/register")]
        [HttpPost]
        public async Task<IActionResult> Register(Device registerDevice)
        {
            var errors = registerDevice.Validate();
            if (errors.Count > 0)
            {
                return StatusCode(400, errors);
            }

            var guid = await accessor.RegisterNewDevice(registerDevice);

            return StatusCode(200, new RegisterDeviceResponse { DeviceKey = guid });
        }
    }
}
