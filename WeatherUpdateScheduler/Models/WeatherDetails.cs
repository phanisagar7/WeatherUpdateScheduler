using System;

namespace WeatherUpdateScheduler.Models
{
    public class WeatherDetails
    {
        public decimal Temperature { get; set; } = default!;
        public decimal WindSpeed { get; set; } = default!;
        public decimal WindDirection { get; set; } = default!;
        public short WeatherCode { get; set; } = default!;
        public DateTime Time { get; set; } = default!;
    }
}
