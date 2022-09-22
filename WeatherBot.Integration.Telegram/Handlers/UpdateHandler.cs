using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using WeatherBot.Domain.Interfaces;
using WeatherBot.Integration.Telegram.Abstractions;

namespace WeatherBot.Integration.Telegram.Handlers
{
    public class UpdateHandler
    {
        private readonly Dictionary<string, BotCommandBase> _commands;
        private readonly ILastCommandRepository _repository;
        public UpdateHandler(IServiceProvider provider, ILastCommandRepository repository)
        {
            _repository = repository;
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
            {
                await botCommand.Execute(chatId, args.Skip(1).ToArray());
                _repository.AddOrUpdate(chatId, botCommand.Name);
            }

            var lastCommand = _repository.GetLastCommand(chatId);
            if (lastCommand == null)
                return;


            if (text.ToLower().Contains(lastCommand.CommandName))
                return;

            foreach (var command in _commands)
            {
                if (command.Value.CanExecute(lastCommand.CommandName))
                {
                    await command.Value.Execute(chatId, new[] { text });
                    return;
                }

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
