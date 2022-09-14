using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot.Types;
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
            foreach(var command in commands)
            {
                _commands.Add(command.Name, command);
            }
        }

        public async Task HandleUpdate(Update update)
        {

        }

        public async Task ExecuteCommand(string command, Update update)
        {
            var args = command.Split(' ');
            await _commands[args[0].ToLower()].Execute(update);
        }


    }
}
