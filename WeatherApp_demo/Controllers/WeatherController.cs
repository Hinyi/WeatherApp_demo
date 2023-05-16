using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherApp_demo.Interface;

namespace WeatherApp_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherData _weatherData;

        public WeatherController(IWeatherData weatherData)
        {
            _weatherData = weatherData;
        }

        [HttpGet("GetById/{stationId}")]
        public async Task<IActionResult> getById(int stationId)
        {
            var data = await _weatherData.GetById(stationId);
            return Ok(data);
        }

        [HttpGet("GetByName/{stationName}")]
        public async Task<IActionResult> getByName(string stationName)
        {
            var data = await _weatherData.GetByName(stationName);
            return Ok(data);
        }
    }
}
