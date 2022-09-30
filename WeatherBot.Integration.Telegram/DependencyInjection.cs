using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using WeatherBot.Integration.Telegram.Abstractions;
using WeatherBot.Integration.Telegram.Commands;
using WeatherBot.Integration.Telegram.Handlers;

namespace WeatherBot.Integration.Telegram
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTelegramBot(this IServiceCollection services, IConfiguration config)
        {
            var token = config.GetRequiredSection($"{BotSettings.Path}:BotToken").Value;

            services.AddSingleton<ITelegramBotClient>(new TelegramBotClient(token));
            services.AddHostedService<ConfigureBot>();
            services.AddScoped<UpdateHandler>();            

            services.AddTransient<BotCommandBase, StartCommand>();
            services.AddTransient<BotCommandBase, WeatherCommand>();
            services.AddTransient<BotCommandBase, HelpCommand>();
            services.AddTransient<BotCommandBase, GetWeatherCommand>();
            return services;
        }
    }
}
