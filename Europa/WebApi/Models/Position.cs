using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Models
{
    public class Position
    {
        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}
