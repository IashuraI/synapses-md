using Md.Bot.Application.Services;
using Md.Bot.Domain.Commands;
using Md.Bot.Domain.Constants;
using Md.Bot.Domain.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Md.Bot.Application.Commands
{
    public class AvailableOrdersCommand : Command
    {
        private readonly IStateService _stateService;
        private readonly ITelegramDataRetriver _telegramDataRetriver;
        private readonly TelegramBotClient _telegramBotClient;

        public AvailableOrdersCommand(IStateService stateService, ITelegramDataRetriver telegramDataRetriver,
            TelegramBotService telegramBotService)
        {
            _stateService = stateService;
            _telegramDataRetriver = telegramDataRetriver;
            _telegramBotClient = telegramBotService.GetBotAsync().Result;
        }

        public override string Name => CommandNameConstants.AvailableOrders;

        public override string? PreviousCommandName => CommandNameConstants.Start;

        public override async Task ExecuteAsync(Update update)
        {
            await _stateService.ChangeUserState(_telegramDataRetriver.GetUserId(update), PreviousCommandName!);
        }
    }
}
