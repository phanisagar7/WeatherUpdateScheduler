
namespace WeatherUpdateScheduler.Models
{
    public class WeatherUpdateResponse
    {
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string Latitude { get; set; } = default!;
        public string Longitude { get; set; } = default!;
        public WeatherDetails Current_Weather { get; set; } = default!;
    }
}
