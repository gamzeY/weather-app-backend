using Microsoft.AspNetCore.Mvc;
using WeatherMicroservice.Models;
using WeatherMicroservice.Services;

namespace WeatherMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        // GET api/Weather/London
        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeather(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                return BadRequest("City is required.");
            }

            var weather = await _weatherService.GetWeatherAsync(city);
            if (weather == null)
            {
                return NotFound($"Weather data for city '{city}' not found.");
            }

            return Ok(weather);
        }
    }
}
