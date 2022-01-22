using Md.Bot.Domain.Interfaces;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Md.Bot.Application.Services
{
    public class TelegramDataRetriver : ITelegramDataRetriver
    {
        public long GetChatId(Update update)
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                    return update.Message!.Chat!.Id;
                case UpdateType.CallbackQuery:
                    return update.CallbackQuery!.Message!.Chat.Id;
                case UpdateType.EditedMessage:
                    return update.EditedMessage!.Chat!.Id;
                case UpdateType.ChannelPost:
                    return update.ChannelPost!.Chat!.Id;
                case UpdateType.EditedChannelPost:
                    return update.EditedChannelPost!.Chat!.Id;
                case UpdateType.MyChatMember:
                    return update.MyChatMember!.Chat!.Id;
                case UpdateType.ChatMember:
                    return update.ChatMember!.Chat!.Id;
                case UpdateType.ChatJoinRequest:
                    return update.ChatJoinRequest!.Chat!.Id;
                default:
                    throw new Exception("This type of update doesn't have a chat id");
            }
        }

        public long GetUserId(Update update)
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                    return update.Message!.From!.Id;
                case UpdateType.CallbackQuery:
                    return update.CallbackQuery!.From!.Id;
                case UpdateType.InlineQuery:
                    return update.InlineQuery!.From!.Id;
                case UpdateType.ChosenInlineResult:
                    return update.ChosenInlineResult!.From.Id;
                case UpdateType.EditedMessage:
                    return update.EditedMessage!.From!.Id;
                case UpdateType.ChannelPost:
                    return update.ChannelPost!.From!.Id;
                case UpdateType.EditedChannelPost:
                    return update.EditedChannelPost!.From!.Id;
                case UpdateType.ShippingQuery:
                    return update.ShippingQuery!.From!.Id;
                case UpdateType.PreCheckoutQuery:
                    return update.PreCheckoutQuery!.From!.Id;
                case UpdateType.MyChatMember:
                    return update.MyChatMember!.From!.Id;
                case UpdateType.ChatMember:
                    return update.ChatMember!.From!.Id;
                case UpdateType.ChatJoinRequest:
                    return update.ChatJoinRequest!.From!.Id;
                default: 
                    throw new Exception("This type of update doesn't have a user id");
            }
        }
    }
}
