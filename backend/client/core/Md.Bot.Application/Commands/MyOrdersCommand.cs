using Md.Bot.Domain.Commands;
using Md.Bot.Domain.Constants;
using Md.Bot.Domain.Interfaces;
using Telegram.Bot.Types;

namespace Md.Bot.Application.Commands
{
    public class MyOrdersCommand : Command
    {
        private readonly IStateService _stateService;

        public MyOrdersCommand(IStateService stateService)
        {
            _stateService = stateService;
        }

        public override string Name => CommandNameConstants.MyOrdersCommand;

        public override string? PreviousCommandName => CommandNameConstants.Start;

        public override async Task ExecuteAsync(Update update)
        {
            await _stateService.ChangeUserState(update.Message!.From!.Id, PreviousCommandName!);
        }
    }
}
