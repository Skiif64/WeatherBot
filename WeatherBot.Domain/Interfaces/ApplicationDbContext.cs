using Microsoft.EntityFrameworkCore;
using WeatherBot.Domain.EntityTypeConfiguration;
using WeatherBot.Domain.Models;

namespace WeatherBot.Domain.Interfaces
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<LastCommand> LastCommands { get; set; } = null!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LastCommandEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
