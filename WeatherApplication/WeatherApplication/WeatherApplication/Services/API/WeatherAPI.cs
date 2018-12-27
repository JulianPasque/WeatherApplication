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
      
        public static async Task<WeatherContainer> GetWeather()
        {
            try
            { 
            var httpClient = new HttpClient();
            var Response = await httpClient.GetAsync(new Uri("http://api.openweathermap.org/data/2.5/weather?q=London,uk&APPID=3c8cca1d3ee836b0f48694e47f4ea0d8"));

            if (Response.StatusCode == System.Net.HttpStatusCode.OK)

                return JsonConvert.DeserializeObject<WeatherContainer>(await Response.Content.ReadAsStringAsync());

            


            }catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null; 

        }


    }
}
