using Md.Bot.Application.Services;
using Md.Bot.Domain.Commands;
using Md.Bot.Domain.Constants;
using Md.Bot.Domain.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Md.Bot.Application.Commands
{
    public sealed class StartCommand : Command
    {
        private readonly TelegramBotClient _telegramBotClient;
        private readonly ITelegramDataRetriver _telegramDataRetriver;

        public StartCommand(TelegramBotService telegramBotService, ITelegramDataRetriver telegramDataRetriver)
        {
            _telegramDataRetriver = telegramDataRetriver;
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

            await _telegramBotClient.SendTextMessageAsync(_telegramDataRetriver.GetChatId(update),
                 "Let's start to work", ParseMode.Markdown, replyMarkup: replyKeyboardMarkup);
        }
    }
}
