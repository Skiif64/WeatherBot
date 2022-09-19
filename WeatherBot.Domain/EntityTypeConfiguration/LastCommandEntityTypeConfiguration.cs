using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherBot.Domain.Models;

namespace WeatherBot.Domain.EntityTypeConfiguration
{
    public class LastCommandEntityTypeConfiguration : IEntityTypeConfiguration<LastCommand>
    {
        public void Configure(EntityTypeBuilder<LastCommand> builder)
        {
            builder.HasKey(k => k.ChatId);
        }
    }
}
