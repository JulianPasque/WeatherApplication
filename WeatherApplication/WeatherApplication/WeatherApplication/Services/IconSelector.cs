using WeatherObjects;

namespace WeatherApplication.Services
{
    public static class IconSelector
    {
        private const string FilePrefix = "resource://WeatherApplication.Images.";
        public static string LoadWeatherIcon(Weather Weather)
        {


            if (Weather.id == 800) //clearsky
            {
                if (Weather.icon[2] == 'd')
                    return FilePrefix + "sun.svg";
                else
                    return FilePrefix + "night.svg";
            }

            if (Weather.id == 900)
                return FilePrefix + "sunrise.svg";
            if (Weather.id == 901)
                return FilePrefix + "sunset.svg";

            //Rain 
            if (Weather.id >= 500 && Weather.id < 600 || Weather.id >= 300 && Weather.id < 400) 
            {
                if (Weather.icon[2] == 'd')
                    return FilePrefix + "rainday.svg";
                else
                    return FilePrefix + "rainnight.svg";
            }

            //Snow 
            if (Weather.id >= 600 && Weather.id < 700)
            {
                    return FilePrefix + "snow.svg";
            }

            //Clouds
            if (Weather.id >= 801 && Weather.id < 900) 
            {
                if (Weather.icon[2] == 'd')
                    return FilePrefix + "cloudday.svg";
                else
                    return FilePrefix + "cloudnight.svg";
            }

            //Thunderstorm 
            if (Weather.id >= 200 && Weather.id < 300)
            {
                if (Weather.icon[2] == 'd')
                    return FilePrefix + "thunderstormday.svg";
                else
                    return FilePrefix + "thunderstormnight.svg";
            }

            return FilePrefix + "spain.svg";
            //return FilePrefix + "sun.svg";

        }
    }
}
