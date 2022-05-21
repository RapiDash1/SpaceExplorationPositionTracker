using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {

        [HttpGet]
        public IActionResult Check()
        {
            return StatusCode(200);
        }
    }
}
