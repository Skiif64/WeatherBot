using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace WeatherBot.Integration.Telegram
{
    public class ConfigureBot : IHostedService
    {
        private readonly ITelegramBotClient _client;
        private readonly BotSettings _settings;

        public ConfigureBot(IOptions<BotSettings> settings, ITelegramBotClient client)
        {
            _settings = settings.Value;
            _client = client;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var url = $"{_settings.HookUrl}/api/bot/";
            await _client.SetWebhookAsync(
                url: url,
                allowedUpdates: Array.Empty<UpdateType>(),
                cancellationToken: cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _client.DeleteWebhookAsync(cancellationToken: cancellationToken);
        }
    }
}
