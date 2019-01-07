using System;
using System.Collections.Generic;

namespace WeatherObjects
{

public class Country
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }

        public string Flag
        {
            get
            {
                return (Name.Replace(" ", "") + ".svg").ToLower();
            }
        }
    }
}
