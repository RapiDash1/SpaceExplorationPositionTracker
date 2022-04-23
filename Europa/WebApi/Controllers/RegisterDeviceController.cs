using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterDeviceController : ControllerBase
    {
        [Route("/register")]
        [HttpPost]
        public IActionResult Register(RegisterDevice registerDevice)
        {
            var errors = registerDevice.Validate();
            if (errors.Count > 0)
            {
                return StatusCode(400, errors);
            }

            return StatusCode(200);
        }
    }
}
