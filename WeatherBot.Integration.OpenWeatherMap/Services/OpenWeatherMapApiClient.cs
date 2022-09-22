using AutoMapper;
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

        public async Task<WeatherForecast?> GetCityWeather(string cityName)
        {
            var uri = $"{_options.Url}?q={cityName}&appid={_options.ApiToken}&units=metric&lang=ru";
            string json;
            try
            {
                json = await _client.GetStringAsync(uri);
            }
            catch (HttpRequestException exception)
            {
                return null;
            }

            var response = JsonSerializer.Deserialize<WeatherForecastResponse>(json);
            var result = _mapper.Map<WeatherForecast>(response);
            return result;

        }
    }
}
