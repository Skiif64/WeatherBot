using System.ComponentModel.DataAnnotations;

namespace WeatherBot.Domain.Models
{
    public class LastCommand
    {        
        public long ChatId { get; set; }
        public string CommandName { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
