using WeatherBot.Domain.Models;

namespace WeatherBot.Domain.Interfaces
{
    public interface IWeatherApiService
    {
        WeatherForecast GetCityWeather(string cityName);
    }
}
