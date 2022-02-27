using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public class WeatherForecastDetails
    {
        public object coord { get; set; }
        public WeatherInfo[] Weather { get; set; }
        public MainDetails Main { get; set; }
        public int Visiblity { get; set; }
        public CloudinessDetails Clouds { get; set; }
    }

    public class WeatherInfo
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class MainDetails
    {
        public float Temp { get; set; }
        public float Feels_Like { get; set; }
        public float Temp_Min { get; set; }
        public float Temp_Max { get; set; }
        public float Pressure { get; set; }
        public float Humidity { get; set; }
    }
    
    public class CloudinessDetails
    {
        public int All { get; set; }
    }
}