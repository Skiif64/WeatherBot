using AutoMapper;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using System.Text.Json;
using WeatherBot.Domain;
using WeatherBot.Domain.Interfaces;
using WeatherBot.Domain.Models;
using WeatherBot.Integration.OpenWeatherMap.Models;

namespace WeatherBot.Integration.OpenWeatherMap.Services
{
    public class OpenWeatherMapApiClient : IWeatherApiService
    {
        private readonly WeatherApiSettings _options;
        private readonly HttpClient _client;        
        private readonly IMapper _mapper;

        public OpenWeatherMapApiClient(IOptions<WeatherApiSettings> options, IMapper mapper)
        {
            _client = new HttpClient();            
            _mapper = mapper;
            _options = options.Value;
        }

        public WeatherForecast? GetCityWeather(string cityName)
        {
            var uri = $"{_options.Url}?q={cityName}&appid={_options.ApiToken}&units=metric&lang=ru";            
            
            var json = _client.GetStringAsync(uri).Result;
            if (string.IsNullOrEmpty(json))
                return null;

            var response = JsonSerializer.Deserialize<WeatherForecastResponse>(json);
            var result = _mapper.Map<WeatherForecast>(response);
            return result;

        }
    }
}
