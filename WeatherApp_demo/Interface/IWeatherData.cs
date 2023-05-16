using WeatherApp_demo.Models;

namespace WeatherApp_demo.Interface
{
    public interface IWeatherData
    {
        Task<WeatherDataDto> GetById(int id);
        Task<WeatherDataDto> GetByName(string stationName);
    }
}
