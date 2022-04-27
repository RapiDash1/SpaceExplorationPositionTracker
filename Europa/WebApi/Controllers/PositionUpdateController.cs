using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccessors;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PositionUpdateController : ControllerBase
    {
        public IPositionUpdateAccessor positionUpdateAccessor { get; set; }

        public PositionUpdateController(IPositionUpdateAccessor positionUpdateAccessor)
        {
            this.positionUpdateAccessor = positionUpdateAccessor;
        }

        [Route("/positionupdate")]
        [HttpPost]
        public async Task<IActionResult> PositionUpdate(PositionUpdate positionUpdate)
        {
            await positionUpdateAccessor.AddPositionUpdate(positionUpdate);

            return StatusCode(200);
        }
    }
}
