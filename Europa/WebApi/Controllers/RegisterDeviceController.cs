using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return StatusCode(200);
        }
    }
}
