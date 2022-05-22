using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
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

            AddTextToTextSearchQueue(registerDevice.Description!);

            return StatusCode(200, new RegisterDeviceResponse { DeviceKey = guid });
        }

        void AddTextToTextSearchQueue(string description)
        {
            var factory = new ConnectionFactory{ HostName = "localhost" };
            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {
                channel.QueueDeclare("HubbleTextSearch", false, false, false, null);
                var data = Encoding.UTF8.GetBytes(description);

                channel.BasicPublish(exchange: string.Empty, routingKey: "HubbleTextSearch", basicProperties: null, body: data);
            }
        }
    }
}
