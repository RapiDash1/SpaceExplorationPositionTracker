namespace WebApi.Models
{
    public class NearestPosition
    {
        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public double Distance { get; set; }

        public DateTimeOffset DateTime { get; set; }
    }
}
