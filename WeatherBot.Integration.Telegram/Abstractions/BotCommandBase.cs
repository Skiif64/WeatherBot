using Telegram.Bot;
using Telegram.Bot.Types;

namespace WeatherBot.Integration.Telegram.Abstractions
{
    public abstract class BotCommandBase
    {
        protected readonly ITelegramBotClient Client;
        public abstract string Name { get; }
        public virtual string RequiredLastCommandName => "";

        public virtual bool CanExecute(string lastCommandName)
        {
            return lastCommandName == RequiredLastCommandName;
        }
        public BotCommandBase(ITelegramBotClient client)
        {
            Client = client;
        }

        public abstract Task Execute(long chatId, string[] args = null);

    }
}
