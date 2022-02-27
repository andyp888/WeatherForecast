using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Authorization;
using WeatherForecast.Services;

namespace WeatherForecast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IForecastService _forecastService;

        public WeatherForecastController(IForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetByCityAsync(string cityName)
        {
            var result = await _forecastService.GetWeatherForecastByCity(cityName);
            return Ok(_forecastService.ConvertTempValues(result));
        }
    }
}
