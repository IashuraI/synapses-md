using Md.Bot.Domain.Commands;
using Md.Bot.Domain.Interfaces;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Md.Bot.Application.Services
{
    public class CommandService : ICommandService
    {
        private readonly List<Command> _commands;

        public CommandService(IEnumerable<Command> commands)
        {
            _commands = commands.ToList();
        }

        public async Task ExecuteAsync(Update? update)
        {
            if (update == null)
                return;

            if(update.Message != null && update.Message.Text != null)
                await ProccessCommand(update, update.Message!.Text!);

            if(update.CallbackQuery != null && update.CallbackQuery.Data != null)
                await ProccessCallbackQuery(update);
        }

        private async Task ProccessCallbackQuery(Update update)
        {
            IEnumerable<IEnumerable<InlineKeyboardButton>> setOfbuttons = update.CallbackQuery!.Message!
                .ReplyMarkup!.InlineKeyboard;

            foreach (IEnumerable<InlineKeyboardButton> buttons in setOfbuttons)
            {
                foreach (InlineKeyboardButton button in buttons)
                {
                    if(button.CallbackData == update.CallbackQuery!.Data)
                    {
                        await ProccessCommand(update, button.Text);
                    }
                }
            }
        }

        private async Task ProccessCommand(Update update, string commandName)
        {
            foreach (Command? command in _commands)
            {
                if (command!.Contains(commandName))
                {
                    await command.ExecuteAsync(update);
                    break;
                }
            }
        }
    }
}
