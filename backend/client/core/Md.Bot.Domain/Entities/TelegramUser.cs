namespace Md.Bot.Domain.Entities
{
    public class TelegramUser
    {
        public long Id { get; set; }

        public string? PreviousCommandName { get; set; }
    }
}
