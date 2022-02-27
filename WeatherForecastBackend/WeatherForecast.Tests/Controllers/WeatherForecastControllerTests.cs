using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using WeatherForecast.Controllers;
using WeatherForecast.Models;
using WeatherForecast.Services;

namespace WeatherForecast.Tests.Controller
{
    public class WeatherForecastControllerTests
    {
        private WeatherForecastController _weatherForecastController;

        [SetUp]
        public void Setup()
        {
            var service = new Mock<IForecastService>();
            var weatherForecastDetails = new WeatherForecastDetails();
            service.Setup(x => x.GetWeatherForecastByCity("testCity")).ReturnsAsync(weatherForecastDetails);
            _weatherForecastController = new WeatherForecastController(service.Object);
        }

        [Test]
        public async Task TestGetByCityAsync()
        {
            var result = await _weatherForecastController.GetByCityAsync("testCity") as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode,200);
        }
    }
}