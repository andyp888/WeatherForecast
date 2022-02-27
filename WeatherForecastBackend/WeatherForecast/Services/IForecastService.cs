using System.Threading.Tasks;
using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    public interface IForecastService
    {
        Task<WeatherForecastDetails> GetWeatherForecastByCity(string city);
        public WeatherForecastDetails ConvertTempValues(WeatherForecastDetails details);
    }
}