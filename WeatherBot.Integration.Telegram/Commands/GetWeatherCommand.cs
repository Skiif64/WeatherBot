using Telegram.Bot;
using Telegram.Bot.Types;
using WeatherBot.Domain.Interfaces;

namespace WeatherBot.Integration.Telegram.Commands
{
    public class GetWeatherCommand : BotCommandBase
    {
        private readonly IWeatherApiService _weatherApiService;
        public override string Name => "/weather";

        public GetWeatherCommand(ITelegramBotClient client, IWeatherApiService weatherApiService) : base(client)
        {
            _weatherApiService = weatherApiService;
        }

        public override async Task Execute(Update update, string[] args = null)
        {
            if (args.Length < 1)
                return;

            var city = args[0];
            var weather = _weatherApiService.GetCityWeather(city);

            var chatId = update.Message.Chat.Id;

            var message = $"Погода в городе {weather.City} за {weather.Date.ToShortTimeString()}\n" +
                $"Погода: {string.Join(", ", weather.Weather)}\n" +
                $"Температура: {weather.Temperture}, Ощущаеться как: {weather.FeelsLike}\n" +
                $"Атмосферное давление: {weather.PressureMmHg} мм. рт. \n" +
                $"Влажность: {weather.Humidity}\n" +
                $"Ветер: {weather.WindSpeed:f1} м/с. Направление: {weather.WindDegress}\n" +
                $"Порыв: {weather.WindGust:f1} м/c.";

            await Client.SendTextMessageAsync(chatId, message);
        }
    }
}
