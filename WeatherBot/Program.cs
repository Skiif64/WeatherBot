using Microsoft.EntityFrameworkCore;
using WeatherBot.Domain;
using WeatherBot.Domain.Interfaces;
using WeatherBot.Domain.Repositories;
using WeatherBot.Integration.OpenWeatherMap;
using WeatherBot.Integration.Telegram;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<WeatherApiSettings>(builder.Configuration.GetRequiredSection(WeatherApiSettings.Path));
builder.Services.Configure<BotSettings>(builder.Configuration.GetRequiredSection(BotSettings.Path));
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlite(connectionString));
builder.Services.AddScoped<ILastCommandRepository, LastCommandRepository>();
builder.Services.AddOpenWeatherMap();
builder.Services.AddTelegramBot(builder.Configuration);
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<OpenWeatherMapApiMapping>());
builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

app.MapControllers();

app.Run();