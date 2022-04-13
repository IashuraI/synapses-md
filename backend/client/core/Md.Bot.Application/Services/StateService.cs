using Md.Bot.Domain.Entities;
using Md.Bot.Domain.Interfaces;
using Synapsess.Infrastructure.Interfaces;

namespace Md.Bot.Application.Services
{
    public class StateService : IStateService
    {
        private readonly IRepository<TelegramUser, long> _userRepository;

        public StateService(IRepository<TelegramUser, long> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ChangeUserState(long userId, string previousCommandName)
        {
            TelegramUser? user = await _userRepository.Get(userId);


            if (user == null)
            {
                TelegramUser newUser = new() 
                { 
                    Id = userId, 
                    PreviousCommandName = previousCommandName
                }; 
                await _userRepository.Create(newUser);

                return;
            }

            user.PreviousCommandName = previousCommandName;
            await _userRepository.Update(user);
        }
    }
}
