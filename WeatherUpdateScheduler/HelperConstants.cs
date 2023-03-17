using System.Collections.Generic;
using WeatherUpdateScheduler.Models;

namespace WeatherUpdateScheduler
{
    public class HelperConstants
    {
        public static readonly List<City> Cities = new() { new City { Country = "India", Name = "Hyderabad", Latitude = "17.366", Longitude = "78.476" },
                                                           new City { Country = "Afghanistan", Name = "Kabul", Latitude = "34.28", Longitude = "69.11" },
                                                           new City { Country = "Belgium", Name = "Brussels", Latitude = "50.51", Longitude = "4.21" },
                                                           new City { Country = "Australia", Name = "Canberra", Latitude = "35.15", Longitude = "149.08" },
                                                           new City { Country = "Colombia", Name = "Bogota", Latitude = "4.34", Longitude = "74.00" },
                                                           new City { Country = "Germany", Name = "Berlin", Latitude = "52.30", Longitude = "13.25" },
                                                           new City { Country = "Italy", Name = "Rome", Latitude = "41.54", Longitude = "12.29" },
                                                           new City { Country = "Jamaica", Name = "Kingston", Latitude = "18.00", Longitude = "76.50" },
                                                           new City { Country = "Latvia", Name = "Riga", Latitude = "56.53", Longitude = "24.08" },
                                                           new City { Country = "USA", Name = "Washington DC", Latitude = "39.91", Longitude = "77.02" },
                                                           new City { Country = "UK", Name = "London", Latitude = "5.36", Longitude = "00.05" } };

        public static readonly string WeatherDetailTable = "dbo.weather";

        public static readonly List<string> WeatherDetailTableColumns = new List<string>() { "Id", "Country", "City", "Temperature", "WindSpeed", "LastUpdateTime", "WeatherCode" };
    }
}
