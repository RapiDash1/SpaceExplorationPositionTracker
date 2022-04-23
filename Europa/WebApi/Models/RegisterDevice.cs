namespace WebApi.Models
{
    public class RegisterDevice
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Owner { get; set; }

        public decimal Weight { get; set; }
    }
}
