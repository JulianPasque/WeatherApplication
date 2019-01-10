using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherObjects;

namespace WeatherApplication.Services.API
{
    public static class WeatherAPI
    {

        public static async Task<WeatherContainer> GetCurrentWeatherForCity(string City, string CountryCode)
        {
            try
            {
                var httpClient = new HttpClient();
                var Response = await httpClient.GetAsync(new Uri("http://api.openweathermap.org/data/2.5/weather?q=" + City + "," + CountryCode + "&APPID=3c8cca1d3ee836b0f48694e47f4ea0d8&units=metric"));

                if (Response.StatusCode == System.Net.HttpStatusCode.OK)

                    return JsonConvert.DeserializeObject<WeatherContainer>(await Response.Content.ReadAsStringAsync());

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;

        }

        public static async Task<WeatherForecastContainer> GetForecastForCity(string City, string CountryCode)
        {
            try
            {
                var httpClient = new HttpClient();
                var Response = await httpClient.GetAsync(new Uri("http://api.openweathermap.org/data/2.5/forecast?q=" + City + "," + CountryCode + "&APPID=3c8cca1d3ee836b0f48694e47f4ea0d8&units=metric"));

                if (Response.StatusCode == System.Net.HttpStatusCode.OK)

                    return JsonConvert.DeserializeObject<WeatherForecastContainer>(await Response.Content.ReadAsStringAsync());
                    

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;

        }

        public static async Task<WeatherContainer> GetCurrentWeatherForLocation(double Latitude, double Longitude)
        {
            try
            {
                var httpClient = new HttpClient();
                var Response = await httpClient.GetAsync(new Uri("http://api.openweathermap.org/data/2.5/weather?lat=" + Latitude + "&lon=" + Longitude + "&appid=3c8cca1d3ee836b0f48694e47f4ea0d8&units=metric"));

                if (Response.StatusCode == System.Net.HttpStatusCode.OK)

                    return JsonConvert.DeserializeObject<WeatherContainer>(await Response.Content.ReadAsStringAsync());

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;

        }


        public static async Task<WeatherForecastContainer> GetForecastForLocation(double Latitude, double Longitude)
        {
            try
            {
                var httpClient = new HttpClient();
                var Response = await httpClient.GetAsync(new Uri("http://api.openweathermap.org/data/2.5/forecast?lat=" + Latitude + "&lon=" + Longitude + "&appid=3c8cca1d3ee836b0f48694e47f4ea0d8&units=metric"));

                if (Response.StatusCode == System.Net.HttpStatusCode.OK)

                    return JsonConvert.DeserializeObject<WeatherForecastContainer>(await Response.Content.ReadAsStringAsync());

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;

        }

    }
}
