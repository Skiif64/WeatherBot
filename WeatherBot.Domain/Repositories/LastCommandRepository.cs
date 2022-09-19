using WeatherBot.Domain.Interfaces;
using WeatherBot.Domain.Models;

namespace WeatherBot.Domain.Repositories
{
    public class LastCommandRepository : ILastCommandRepository
    {
        private readonly ApplicationDbContext _context;

        public LastCommandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddOrUpdate(long chatId, string commandType)
        {
            var command = _context.LastCommands.SingleOrDefault(c => c.ChatId == chatId);

            if (command != null)
            {
                command.CommandName = commandType;
                command.Date = DateTime.UtcNow;
                _context.LastCommands.Update(command);
                _context.SaveChanges();
                return;
            }

            command = new LastCommand
            {
                ChatId = chatId,
                CommandName = commandType,
                Date = DateTime.UtcNow
            };
            _context.LastCommands.Add(command);
            _context.SaveChanges();
        }

        public LastCommand? GetLastCommand(long chatId)
        {
            var command = _context.LastCommands.SingleOrDefault(c => c.ChatId == chatId);
            return command;
        }
    }
}
