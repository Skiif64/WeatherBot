using WeatherBot.Domain.Models;

namespace WeatherBot.Domain.Interfaces
{
    public interface ILastCommandRepository
    {
        LastCommand? GetLastCommand(long chatId);
        void AddOrUpdate(long chatId, string commandType);
    }
}
