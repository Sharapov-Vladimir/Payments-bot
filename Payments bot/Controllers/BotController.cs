using Microsoft.AspNetCore.Mvc;
using Payments_bot.Models.TelegramApi;
using Payments_bot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Payments_bot.Controllers
{
    [Route("api/[controller]")]
    public class BotController : Controller
    {

        private IUpdateService updateservice;
        private TelegramBotClient client;
        private ResponseTextMessage response;
        public BotController(IUpdateService updateservice,IBotService botService)
        {
            this.updateservice = updateservice;
            client = botService.GetClient();
        }
        [HttpPost]
        public  async void Post([FromBody] Update update)
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
            
           
        }


    }
}
