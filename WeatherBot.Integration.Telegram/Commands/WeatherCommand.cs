using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace WeatherBot.Integration.Telegram.Commands
{
    public class WeatherCommand : BotCommandBase
    {
        public override string Name => "погода";

        public WeatherCommand(ITelegramBotClient client) : base(client)
        {

        }

        public override async Task Execute(long chatId, string[] args = null)
        {
            var message = "Для отображения погода по городу, укажите название города." +
                " Пробелы в названии города замените на '-'";
            await Client.SendChatActionAsync(chatId, ChatAction.Typing);
            await Client.SendTextMessageAsync(chatId, message);
        }
    }
}
