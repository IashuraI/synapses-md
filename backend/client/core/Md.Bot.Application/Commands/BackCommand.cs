using Microsoft.Extensions.DependencyInjection;
using Md.Bot.Domain.Commands;
using Md.Bot.Domain.Constants;
using Md.Bot.Domain.Interfaces;
using Md.Bot.Domain.Entities;
using Telegram.Bot.Types;
using Md.Infrastructure.Interfaces;

namespace Md.Bot.Application.Commands
{
    public class BackCommand : Command
    {
        private readonly IRepository<TelegramUser, long> _telegramUserRepository;
        private readonly ITelegramDataRetriver _telegramUserIdRetriver;
        private readonly IServiceProvider _serviceProvider;
        private List<Command> _commands = null!;


        public BackCommand(IRepository<TelegramUser, long> telegramUserRepository, IServiceProvider serviceProvider,
            ITelegramDataRetriver telegramUserIdRetriver)
        {
            _telegramUserIdRetriver = telegramUserIdRetriver;
            _telegramUserRepository = telegramUserRepository;
            _serviceProvider = serviceProvider;
        }

        public override string Name => CommandNameConstants.Back;

        private void InitializeCommands()
        {
            if (_commands != null)
                return;

            _commands = _serviceProvider.GetServices<Command>()
                .Where(x => x.Name != CommandNameConstants.Back).ToList();
        }

        public override async Task ExecuteAsync(Update update)
        {
            long userId = _telegramUserIdRetriver.GetUserId(update);

            TelegramUser? user = await _telegramUserRepository.Get(userId);

            if(user != null)
            {
                InitializeCommands();

                foreach (Command command in _commands)
                {
                    if (user.PreviousCommandName != null && command.Contains(user.PreviousCommandName!))
                    {
                        await command.ExecuteAsync(update);

                        user!.PreviousCommandName = command.PreviousCommandName;
                        await _telegramUserRepository.Update(user);
                        break;
                    }
                    else if(user.PreviousCommandName == null)
                    {
                        foreach (Command startCommand in _commands)
                        {
                            if (command.Contains(CommandNameConstants.Start!))
                            {
                                await startCommand.ExecuteAsync(update);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
