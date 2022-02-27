using System.Collections.Generic;
using WeatherForecast.Entity;
using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    public interface IUserService
    {
        AuthenticationResponse Authenticate(AuthenticationRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}