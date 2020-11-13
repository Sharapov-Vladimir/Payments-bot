using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Payments_bot.Data;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Payments_bot.Services
{
    public class BotService:IBotService
    {
        private IConfiguration configuration;
        

        public BotService(IConfiguration configuration , BotContext context)
        {
            this.configuration = configuration;
        }
        
        public TelegramBotClient GetClient()
        {
            return new TelegramBotClient(configuration.GetConnectionString("Telegram_Token"));
        }
        public async void setWebHook()
        {
            TelegramBotClient client = new TelegramBotClient(configuration.GetConnectionString("Telegram_Token"));
            await client.SetWebhookAsync(configuration.GetConnectionString("App_Url") + "/api/Bot");
            
        }
    }
}
