using Microsoft.Extensions.Configuration;
using Telegram.Bot;

namespace Md.Bot.Application.Services
{
    public class TelegramBotService
    {
        private readonly IConfiguration _configuration;
        private TelegramBotClient _botClient = null!;

        public TelegramBotService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<TelegramBotClient> GetBotAsync()
        {
            if (_botClient != null)
            {
                return _botClient;
            }

            _botClient = new TelegramBotClient(_configuration
                .GetRequiredSection("TelegramCredentials")["Token"]);

            var hook = $"{_configuration.GetRequiredSection("TelegramCredentials")["Url"]}api/message/update";
            await _botClient.SetWebhookAsync(hook);

            return _botClient;
        }
    }
}
