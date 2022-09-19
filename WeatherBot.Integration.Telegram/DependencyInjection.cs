using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using WeatherBot.Integration.Telegram.Commands;
using WeatherBot.Integration.Telegram.Services;

namespace WeatherBot.Integration.Telegram
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTelegramBot(this IServiceCollection services, IConfiguration config)
        {
            var token = config.GetRequiredSection($"{BotSettings.Path}:BotToken").Value;

            services.AddSingleton<ITelegramBotClient>(new TelegramBotClient(token));
            services.AddHostedService<ConfigureBot>();
            services.AddScoped<BotCommandService>();
            services.AddScoped<BotCommandBase, GetWeatherCommand>();
            services.AddScoped<BotCommandBase, WeatherCommand>();
            return services;
        }
    }
}
