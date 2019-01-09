using System;
using WeatherObjects.Enums;

namespace WeatherApplication.Services
{
    public static class IconSelector
    {
        private const string FilePrefix = "resource://WeatherApplication.Images.";
        public static string LoadWeatherIcon(Weather Weather)
        {


            if (Weather == Weather.Sunny)
                return FilePrefix + "sun.svg";
            if (Weather == Weather.Sunrise)
                return FilePrefix + "sunrise.svg";
            if (Weather == Weather.Sunset)
                return FilePrefix + "sunset.svg";


            return FilePrefix + "sun.svg";

        }
    }
}
