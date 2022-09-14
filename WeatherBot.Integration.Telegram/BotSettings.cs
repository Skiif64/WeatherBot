namespace WeatherBot.Integration.Telegram
{
    public class BotSettings
    {
        public const string Path = "BotSettings";
        public string BotToken { get; init; } = string.Empty;
        public string HookUrl { get; init; } = string.Empty;
    }
}