using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccessors;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindController : ControllerBase
    {
        public IFindAccessor findAccessor { get; set; }

        public FindController(IFindAccessor findAccessor)
        {
            this.findAccessor = findAccessor;  
        }

        [Route("/nearestactivedevice")]
        [HttpPost]
        public async Task<IActionResult> FindNearestActiveDevice(Position position)
        {
            var nearestPosition = await findAccessor.FindNearestActivePosition(position);

            return StatusCode(200, nearestPosition);
        }
    }
}
