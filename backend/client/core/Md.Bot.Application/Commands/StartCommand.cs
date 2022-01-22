using Md.Bot.Application.Services;
using Md.Bot.Domain.Commands;
using Md.Bot.Domain.Constants;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Md.Bot.Application.Commands
{
    public sealed class StartCommand : Command
    {
        private readonly TelegramBotClient _telegramBotClient;

        public StartCommand(TelegramBotService telegramBotService)
        {
            _telegramBotClient = telegramBotService.GetBotAsync().Result;
        }

        public override string Name => CommandNameConstants.Start;

        public override async Task ExecuteAsync(Update update)
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new KeyboardButton[][]
            {
                new[]
                {
                     new KeyboardButton("Available orders")
                },

                new[]
                {
                     new KeyboardButton("My orders")

                }
            });

            await _telegramBotClient.SendTextMessageAsync(TelegramDataRetriver.GetChatId(update),
                 "Let's start to work", ParseMode.Markdown, replyMarkup: replyKeyboardMarkup);
        }
    }
}
