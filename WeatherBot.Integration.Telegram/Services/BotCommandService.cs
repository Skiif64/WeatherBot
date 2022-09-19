using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using WeatherBot.Domain.Interfaces;
using WeatherBot.Integration.Telegram.Commands;
using WeatherBot.Integration.Telegram.ConsecutiveCommands;

namespace WeatherBot.Integration.Telegram.Services
{
    public class BotCommandService
    {
        private readonly Dictionary<string, BotCommandBase> _commands;
        private readonly Dictionary<string, ConsecutiveCommandBase> _consecutiveCommands;
        private readonly ILastCommandRepository _repository;
        public BotCommandService(IServiceProvider provider, ILastCommandRepository repository)
        {
            _repository = repository;
            var commands = provider.GetServices<BotCommandBase>();
            _commands = new Dictionary<string, BotCommandBase>();
            _consecutiveCommands = new Dictionary<string, ConsecutiveCommandBase>();
            var consecutiveCommand = provider.GetServices<ConsecutiveCommandBase>();
            foreach (var command in commands)
            {
                _commands.Add(command.Name, command);
            }

            foreach (var command in consecutiveCommand)
            {
                _consecutiveCommands.Add(command.Name, command);
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
            {
                await botCommand.Execute(chatId, args.Skip(1).ToArray());
                _repository.AddOrUpdate(chatId, botCommand.Name);
            }

            var lastCommandEntity = _repository.GetLastCommand(chatId);
            if (lastCommandEntity == null)
                return;

            var lastCommand = _commands.FirstOrDefault(c => c.Value.Name == lastCommandEntity.CommandName).Value;
            if (text.ToLower().Contains(lastCommand.Name))
                return;

            foreach (var command in _consecutiveCommands)
            {
                if (command.Value.CanExecute(lastCommand))
                    await command.Value.Execute(chatId, new[] { text });
            }
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
