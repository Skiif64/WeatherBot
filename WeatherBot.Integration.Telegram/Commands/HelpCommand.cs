using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace WeatherBot.Integration.Telegram.Commands
{
    public class HelpCommand : BotCommandBase
    {
        public override string Name => "/help";

        public HelpCommand(ITelegramBotClient client) : base(client)
        {
        }


        public override async Task Execute(long chatId, string[] args = null)
        {
            var message = "/start - начать работу с ботом\n" +
                "/help - список команд\n" +
                "Погода - узнать погоду";
            await Client.SendChatActionAsync(chatId, ChatAction.Typing);
            await Client.SendTextMessageAsync(chatId, message);
        }
    }
}
