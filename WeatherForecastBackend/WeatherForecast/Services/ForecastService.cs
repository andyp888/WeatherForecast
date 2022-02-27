using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.Helpers;
using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    public class ForecastService : IForecastService
    {
        private const float kelvinValue = 273.15f;

        public async Task<WeatherForecastDetails> GetWeatherForecastByCity(string city)
        {
            //Call out to https://openweathermap.org/api to retrieve weather details

            var client = new RestClient(BuildRequestUrl(city));
            var response = await client.ExecuteAsync<WeatherForecastDetails>(new RestRequest());
            return response.Data;
        }

        //API returns temperature values in Kelvin, so convert to celcius
        public WeatherForecastDetails ConvertTempValues(WeatherForecastDetails details)
        {
            details.Main.Temp = details.Main.Temp - kelvinValue;
            details.Main.Feels_Like = details.Main.Feels_Like - kelvinValue;
            details.Main.Temp_Min = details.Main.Temp_Min - kelvinValue;
            details.Main.Temp_Max = details.Main.Temp_Max - kelvinValue;

            return details;
        }

        private string BuildRequestUrl(string city)
        {
            return $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={Constants.openWeatherApiKey}";
        }
    }
}
