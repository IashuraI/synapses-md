using Microsoft.AspNetCore.Mvc;
using Md.Bot.Domain.Interfaces;
using Telegram.Bot.Types;
using Md.Bot.Domain.Entities;
using Synapsess.Infrastructure.Interfaces;
using Md.Bot.Application.Services;

namespace Md.Bot.WebApi.Controllers
{

    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ICommandService _commandService;
        private readonly IRepository<TelegramUser, long> _userRepository;

        public MessageController(ICommandService commandService, IRepository<TelegramUser, long> userRepository)
        {
            _commandService = commandService;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route(@"api/message/update")]
        public async Task Update([FromBody] Update update)
        {
            if (await _userRepository.Get(TelegramDataRetriver.GetUserId(update)) != null)
            {
                await _commandService.ExecuteAsync(update);
            }
        }
    }
}
