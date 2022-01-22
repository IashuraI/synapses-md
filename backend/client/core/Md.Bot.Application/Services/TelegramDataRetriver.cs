using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Md.Bot.Application.Services
{
    public static class TelegramDataRetriver
    {
        public static long GetChatId(Update update)
        {
            return update.Type switch
            {
                UpdateType.Message => update.Message!.Chat!.Id,
                UpdateType.CallbackQuery => update.CallbackQuery!.Message!.Chat.Id,
                UpdateType.EditedMessage => update.EditedMessage!.Chat!.Id,
                UpdateType.ChannelPost => update.ChannelPost!.Chat!.Id,
                UpdateType.EditedChannelPost => update.EditedChannelPost!.Chat!.Id,
                UpdateType.MyChatMember => update.MyChatMember!.Chat!.Id,
                UpdateType.ChatMember => update.ChatMember!.Chat!.Id,
                UpdateType.ChatJoinRequest => update.ChatJoinRequest!.Chat!.Id,
                _ => throw new Exception("This type of update doesn't have a chat id"),
            };
        }

        public static long GetUserId(Update update)
        {
            return update.Type switch
            {
                UpdateType.Message => update.Message!.From!.Id,
                UpdateType.CallbackQuery => update.CallbackQuery!.From!.Id,
                UpdateType.InlineQuery => update.InlineQuery!.From!.Id,
                UpdateType.ChosenInlineResult => update.ChosenInlineResult!.From.Id,
                UpdateType.EditedMessage => update.EditedMessage!.From!.Id,
                UpdateType.ChannelPost => update.ChannelPost!.From!.Id,
                UpdateType.EditedChannelPost => update.EditedChannelPost!.From!.Id,
                UpdateType.ShippingQuery => update.ShippingQuery!.From!.Id,
                UpdateType.PreCheckoutQuery => update.PreCheckoutQuery!.From!.Id,
                UpdateType.MyChatMember => update.MyChatMember!.From!.Id,
                UpdateType.ChatMember => update.ChatMember!.From!.Id,
                UpdateType.ChatJoinRequest => update.ChatJoinRequest!.From!.Id,
                _ => throw new Exception("This type of update doesn't have a user id"),
            };
        }
    }
}
