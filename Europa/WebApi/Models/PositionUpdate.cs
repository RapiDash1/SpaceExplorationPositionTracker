namespace WebApi.Models
{
    public class PositionUpdate
    {
        public Guid DeviceKey { get; set; }

        public decimal Latitude { get; set; }   

        public decimal Longitude { get; set; }

        public DateTimeOffset DateTime { get; set; }
    }
}
