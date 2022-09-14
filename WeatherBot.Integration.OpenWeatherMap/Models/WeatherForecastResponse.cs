using System.Text.Json.Serialization;
using WeatherBot.Integration.OpenWeatherMap.Converters;

namespace WeatherBot.Integration.OpenWeatherMap.Models
{
    public class WeatherForecastResponse
    {
        [JsonPropertyName("weather")]
        public WeatherInfo[] Weather { get; set; }
        [JsonPropertyName("base")]
        public string Base { get; set; }
        [JsonPropertyName("main")]
        public WeatherResponseInfo Response { get; set; }
        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }
        [JsonPropertyName("wind")]
        public WindInfo Wind { get; set; }
        [JsonPropertyName("dt")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime DateTime { get; set; }
        [JsonPropertyName("sys")]
        public SystemInfo System { get; set; }
        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("cod")]
        public int Cod { get; set; }
    }

    public class WeatherResponseInfo
    {
        [JsonPropertyName("temp")]
        public float Temperture { get; set; }
        [JsonPropertyName("feels_like")]
        public float FeelsLike { get; set; }
        [JsonPropertyName("pressure")]
        public int PressureHpa { get; set; }
        public int PressureMmHg => (int)Math.Round(PressureHpa * 0.75006);
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }

    public class WindInfo
    {
        [JsonPropertyName("speed")]
        public float Speed { get; set; }
        [JsonPropertyName("deg")]
        public int Degress { get; set; }
        [JsonPropertyName("gust")]
        public float Gust { get; set; }
    }

    public class SystemInfo
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("sunrise")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Sunrise { get; set; }
        [JsonPropertyName("sunset")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Sunset { get; set; }
    }

    public class WeatherInfo
    {
        [JsonPropertyName("main")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}