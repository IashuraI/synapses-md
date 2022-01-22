using Telegram.Bot.Types;

namespace Md.Bot.Domain.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public virtual string? PreviousCommandName { get; } = null;
        public abstract Task ExecuteAsync(Update update);

        public bool Contains(string command)
        {
            return command.Contains(Name);
        }
    }
}
