using Telegram.Bot;
using WeatherBot.Integration.Telegram.Commands;

namespace WeatherBot.Integration.Telegram.ConsecutiveCommands
{
    public abstract class ConsecutiveCommandBase : BotCommandBase
    {
        protected ConsecutiveCommandBase(ITelegramBotClient client) : base(client)
        {
        }

        public abstract bool CanExecute(BotCommandBase previousCommand);
    }
}
