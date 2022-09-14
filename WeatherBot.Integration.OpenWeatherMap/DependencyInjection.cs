using Microsoft.Extensions.DependencyInjection;
using WeatherBot.Domain.Interfaces;
using WeatherBot.Integration.OpenWeatherMap.Services;

namespace WeatherBot.Integration.OpenWeatherMap
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddOpenWeatherMap(this IServiceCollection services)
        {
            services.AddScoped<IWeatherApiService, OpenWeatherMapApiClient>();
            return services;
        }
    }
}
