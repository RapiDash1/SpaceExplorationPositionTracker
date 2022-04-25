﻿using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccessors;
using WebApi.Extensions;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterDeviceController : ControllerBase
    {
        public IRegisterDeviceAccessor accessor { get; set; }

        public RegisterDeviceController(IRegisterDeviceAccessor accessor)
        {
            this.accessor = accessor;
        }

        [Route("/register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDevice registerDevice)
        {
            var errors = registerDevice.Validate();
            if (errors.Count > 0)
            {
                return StatusCode(400, errors);
            }

            await accessor.RegisterNewDevice(registerDevice);

            return StatusCode(200);
        }
    }
}
