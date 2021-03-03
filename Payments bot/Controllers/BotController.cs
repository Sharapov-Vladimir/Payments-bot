using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Payments_bot.Models.TelegramApi;
using Payments_bot.Services;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Payments_bot.Controllers
{
    [Route("api/[controller]")]
    public class BotController : Controller
    {

        private IUpdateService updateservice;
        private ResponseTextMessage response;
        private TelegramBotClient client = AppConfig.GetClient();
        public BotController(IUpdateService updateservice)
        {
            this.updateservice = updateservice; 
        }

        [HttpPost]
        public  async Task<IActionResult> Post([FromBody] Update update)
        {
           response = await updateservice.Update(update);
            
            if (response != null)
            {
                await client.SendTextMessageAsync(
                    chatId: response.ChatId,
                    text: response.text,
                    replyMarkup: response.keyboardMarkup
                    );
               
            }

            return Ok();
        }


    }
}
