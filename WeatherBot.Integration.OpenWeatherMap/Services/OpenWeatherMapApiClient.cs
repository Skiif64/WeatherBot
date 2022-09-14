using AutoMapper;
using System.Text.Json;
using WeatherBot.Domain.Interfaces;
using WeatherBot.Domain.Models;
using WeatherBot.Integration.OpenWeatherMap.Models;

namespace WeatherBot.Integration.OpenWeatherMap.Services
{
    public class OpenWeatherMapApiClient : IWeatherApiService
    {
        private const string URL = "https://api.openweathermap.org/data/2.5/weather";

        private readonly HttpClient _client;
        private readonly string _appId;
        private readonly IMapper _mapper;

        public OpenWeatherMapApiClient(string appId, IMapper mapper)
        {
            _client = new HttpClient();
            _appId = appId;
            _mapper = mapper;
        }

        public WeatherForecast GetCityWeather(string cityName)
        {
            var uri = $"{URL}?q={cityName}&appid={_appId}&units=metric&lang=ru";            
            
            var json = _client.GetStringAsync(uri).Result;
            var response = JsonSerializer.Deserialize<WeatherForecastResponse>(json);
            var result = _mapper.Map<WeatherForecast>(response);
            return result;

        }
    }
}
