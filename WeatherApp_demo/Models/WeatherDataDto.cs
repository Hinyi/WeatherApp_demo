using System.Text.Json.Serialization;

namespace WeatherApp_demo.Models
{
    public class WeatherDataDto
    {
        [JsonPropertyName("id_stacji")]
        public string? Id { get; set; }
        [JsonPropertyName("stacja")]
        public string? Station { get; set; }
        [JsonPropertyName("data_pomiaru")]
        public string? Date { get; set; }
        [JsonPropertyName("godzina_pomiaru")]
        public string? Hour { get; set; }
        [JsonPropertyName("temperatura")]
        public string? Temperature { get; set; }
        [JsonPropertyName("predkosc_wiatru")]
        public string? SpeedOfWind { get; set; }
        [JsonPropertyName("kierunek_wiatru")]
        public string? DirectionOfWind { get; set; }
        [JsonPropertyName("wilgotnosc_wzgledna")]
        public string? Moisture { get; set; }
        [JsonPropertyName("suma_opadu")]
        public string? Precipitation { get; set; }
        [JsonPropertyName("cisnienie")]
        public string? Pressure { get; set; }
    }
}
