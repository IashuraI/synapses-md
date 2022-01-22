namespace Md.Bot.Domain.Interfaces
{
    public interface IStateService
    {
        Task ChangeUserState(long userId, string previousCommandName);
    }
}
