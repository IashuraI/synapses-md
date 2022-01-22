using Telegram.Bot.Types;

namespace Md.Bot.Domain.Interfaces
{
    public interface ITelegramDataRetriver
    {
        long GetUserId(Update update);
        long GetChatId(Update update);
    }
}
