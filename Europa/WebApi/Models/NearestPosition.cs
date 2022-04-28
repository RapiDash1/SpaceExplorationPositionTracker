namespace WebApi.Models
{
    public class NearestPosition
    {
        public Position? Position { get; set; }

        public double Distance { get; set; }

        public DateTimeOffset DateTime { get; set; }
    }
}
