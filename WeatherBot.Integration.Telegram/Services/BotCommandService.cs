using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using WeatherBot.Integration.Telegram.Commands;

namespace WeatherBot.Integration.Telegram.Services
{
    public class BotCommandService
    {
        private readonly Dictionary<string, BotCommandBase> _commands;
        public BotCommandService(IServiceProvider provider)
        {
            var commands = provider.GetServices<BotCommandBase>();
            _commands = new Dictionary<string, BotCommandBase>();
            foreach (var command in commands)
            {
                _commands.Add(command.Name, command);
            }
        }

        public async Task HandleUpdate(Update update)
        {
            var handler = update.Type switch
            {
                UpdateType.Message => HandleMessage(update.Message),
                _ => HandleUnknown(update.Message)
            };

            await handler;
        }        

        private async Task ExecuteCommand(string text, long chatId)
        {
            var args = text.Split(' ');
            args[0] = args[0].ToLower();
            if (_commands.TryGetValue(args[0], out var botCommand))
                await botCommand.Execute(chatId, args.Skip(1).ToArray());
        }

        private async Task HandleMessage(Message? message)
        {
            if (message == null || message.Text == null)
                return;

            var text = message.Text;
            var chatId = message.Chat.Id;            

            await ExecuteCommand(text, chatId);
        }

        private Task HandleUnknown(Message? message)
        {
            return Task.CompletedTask;
        }


    }
}
