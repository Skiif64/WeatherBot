using WeatherBot.Domain;
using WeatherBot.Integration.OpenWeatherMap;
using WeatherBot.Integration.Telegram;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<WeatherApiSettings>(builder.Configuration.GetRequiredSection(WeatherApiSettings.Path));
builder.Services.Configure<BotSettings>(builder.Configuration.GetRequiredSection(BotSettings.Path));
builder.Services.AddOpenWeatherMap();
builder.Services.AddTelegramBot(builder.Configuration);
builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

app.MapControllers();

app.Run();