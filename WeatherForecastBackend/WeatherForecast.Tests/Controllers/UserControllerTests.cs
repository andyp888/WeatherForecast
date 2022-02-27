using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using WeatherForecast.Controllers;
using WeatherForecast.Entity;
using WeatherForecast.Models;
using WeatherForecast.Services;

namespace WeatherForecast.Tests.Controllers
{
    public class UserControllerTests
    {
        private UsersController _userController;
        private AuthenticationRequest validRequest = new AuthenticationRequest { Username = "testUserSuccess", Password = "testPasswordSuccess" };
        private AuthenticationRequest invalidRequest = new AuthenticationRequest { Username = "testUserFail", Password = "testPasswordFail" };
        private AuthenticationResponse nullAuthResponse;
        
        [SetUp]
        public void Setup()
        {
            var service = new Mock<IUserService>();
            service.Setup(x => x.Authenticate(validRequest)).Returns(new AuthenticationResponse(new User(), "token"));
            service.Setup(x => x.Authenticate(invalidRequest)).Returns(nullAuthResponse);
            _userController = new UsersController(service.Object);
        }

        [Test]
        public void TestCallWithValidRequest()
        {
            var result = _userController.Authenticate(validRequest) as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, 200);
        }

        [Test]
        public void TestCallWithInvalidRequest()
        {
            var result = _userController.Authenticate(invalidRequest) as BadRequestObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, 400);
        }
    }
}