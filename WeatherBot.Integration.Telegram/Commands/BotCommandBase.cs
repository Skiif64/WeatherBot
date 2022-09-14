using Telegram.Bot;
using Telegram.Bot.Types;

namespace WeatherBot.Integration.Telegram.Commands
{
    public abstract class BotCommandBase
    {
        protected readonly ITelegramBotClient Client;
        public abstract string Name { get; }

        public BotCommandBase(ITelegramBotClient client)
        {
            Client = client;
        }

        public abstract Task Execute(Update update, string[] args = null);

    }
}
