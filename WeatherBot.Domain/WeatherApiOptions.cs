namespace WeatherBot.Domain
{
    public class WeatherApiOptions
    {
        public const string Path = "WeatherApiSettings";
        public string Url { get; init; } = string.Empty;
        public string ApiToken { get; init; } = string.Empty;
    }
}
