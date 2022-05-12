using WebApi.Models;

namespace WebApi.Extensions
{
    public static class DeviceExtensions
    {
        public static IReadOnlyCollection<string> Validate(this Device registerDevice)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(registerDevice.Name))
            {
                errors.Add("Name cannot be Null or Empty");
            }

            if (string.IsNullOrEmpty(registerDevice.Description))
            {
                errors.Add("Description cannot be Null or Empty");
            }

            if (registerDevice.Height  * registerDevice.Width * registerDevice.Depth == 0)
            {
                errors.Add("Device dimensions(Height, Width, Depth) cannot be 0");
            }

            return errors;
        }
    }
}
