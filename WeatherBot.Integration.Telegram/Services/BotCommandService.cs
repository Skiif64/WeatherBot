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
                UpdateType.Message => HandleMessage(update)
            };

            await handler;
        }

        private async Task ExecuteCommand(string command, Update update)
        {
            var args = command.Split(' ');
            args[0] = args[0].ToLower();
            if (_commands.TryGetValue(args[0], out var botCommand))
                await botCommand.Execute(update, args.Skip(1).ToArray());
        }

        private async Task HandleMessage(Update update)
        {
            var text = update.Message?.Text;
            if (text == null)
                return;

            await ExecuteCommand(text, update);
        }


    }
}
