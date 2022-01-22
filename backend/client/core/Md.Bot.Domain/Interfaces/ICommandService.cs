using Telegram.Bot.Types;

namespace Md.Bot.Domain.Interfaces
{
    public interface ICommandService
    {
        Task ExecuteAsync(Update update);
    }
}
