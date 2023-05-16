using System.Diagnostics.Contracts;
using System.Text.Json;
using System.Text.Json.Serialization;
using WeatherApp_demo.Exceptions;
using WeatherApp_demo.Interface;
using WeatherApp_demo.Models;

namespace WeatherApp_demo.Services
{
    public class WeatherData : IWeatherData
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherData(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            //_options = new JsonSerializerOptions(PropertyNameCaseInsensitive = true);
        }
        async public Task<WeatherDataDto> GetById(int id)
        {
            var httpClient = _httpClientFactory.CreateClient();

            using (var response = await httpClient.GetAsync($"https://danepubliczne.imgw.pl/api/data/synop/id/{id}",
                       HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStringAsync();
                var latestData = JsonSerializer.Deserialize<WeatherDataDto>(stream);
                return latestData;
            }

        }

        async public Task<WeatherDataDto> GetByName(string stationName)
        {
            var httpClient = _httpClientFactory.CreateClient();

            using (var response = await httpClient.GetAsync($"https://danepubliczne.imgw.pl/api/data/synop/station/{stationName}",
                       HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                if (response is null) throw new NotFoundException("Station not found");
                var stream = await response.Content.ReadAsStreamAsync();
                var latestData = await JsonSerializer.DeserializeAsync<WeatherDataDto>(stream);
                return latestData;
            }
        }
    }
}
