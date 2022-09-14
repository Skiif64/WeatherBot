using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using WeatherBot.Integration.Telegram.Services;

namespace WeatherBot.Controllers
{
    [ApiController]
    [Route("api/bot/")]
    public class BotController : ControllerBase
    {
        private readonly BotCommandService _botCommandService;

        public BotController(BotCommandService botCommandService)
        {
            _botCommandService = botCommandService;
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] Update update)
        {
            if (update.Message == null && update.CallbackQuery == null)
                return BadRequest();
            await _botCommandService.HandleUpdate(update);
            return Ok();
        }
    }
}
