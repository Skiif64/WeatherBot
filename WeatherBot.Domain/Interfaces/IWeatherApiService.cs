using WeatherBot.Domain.Models;

namespace WeatherBot.Domain.Interfaces
{
    public interface IWeatherApiService
    {
        Task<WeatherForecast?> GetCityWeather(string cityName);
    }
}
