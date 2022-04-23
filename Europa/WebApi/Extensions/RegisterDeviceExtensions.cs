using WebApi.Models;

namespace WebApi.Extensions
{
    public static class RegisterDeviceExtensions
    {
        public static IReadOnlyCollection<string> Validate(this RegisterDevice registerDevice)
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

            return errors;
        }
    }
}
