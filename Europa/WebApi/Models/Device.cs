namespace WebApi.Models
{
    public class Device
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal Depth { get; set; }

        public decimal Height { get; set; }

        public bool IsActive { get; set; }

        public bool IsMobile { get; set; }

        public string? Owner { get; set; }

        public DateTimeOffset? RegsiteredDateTime { get; set; } = DateTimeOffset.Now;

        public decimal Weight { get; set; }

        public decimal Width { get; set; }
    }
}
