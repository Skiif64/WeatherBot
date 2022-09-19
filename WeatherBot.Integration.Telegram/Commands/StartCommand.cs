using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace WeatherBot.Integration.Telegram.Commands
{
    public class StartCommand : BotCommandBase
    {
        public override string Name => "/start";

        public StartCommand(ITelegramBotClient client) : base(client)
        {
        }


        public override async Task Execute(long chatId, string[] args = null)
        {
            var message = "Привет. Данный бот позволяет узнать погоду в любом городе.\n" +
                "Воспользуйтесь встроеной клавиатурой или введите /help, чтобы узнать команды бота";

            var replyMarkupKeyboard = new ReplyKeyboardMarkup(new[]
            {
                new KeyboardButton[] {"Погода"}
            })
            {
                ResizeKeyboard = true
            };
            await Client.SendTextMessageAsync(chatId, message, replyMarkup: replyMarkupKeyboard);
        }
    }
}
