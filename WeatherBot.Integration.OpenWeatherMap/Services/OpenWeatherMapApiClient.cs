using System.Text.Json;
using WeatherBot.Integration.OpenWeatherMap.Models;

namespace WeatherBot.Integration.OpenWeatherMap.Services
{
    public class OpenWeatherMapApiClient
    {
        private const string URL = "https://api.openweathermap.org/data/2.5/weather";

        private readonly HttpClient _client;
        private readonly string _appId;

        public OpenWeatherMapApiClient(string appId)
        {
            _client = new HttpClient();
            _appId = appId;
        }

        public WeatherForecastResponse GetCityWeather(string cityName)
        {
            var uri = $"{URL}?q={cityName}&appid={_appId}&units=metric&lang=ru";            
            
            var response = _client.GetStringAsync(uri).Result;

            var result = JsonSerializer.Deserialize<WeatherForecastResponse>(response);
            return result;

        }
    }
}
