using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Payments_bot.Data;
using Payments_bot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Payments_bot.Models
{
    public static class AppConfig
    {
        public static readonly string AppUrl = "https://...";
        private static readonly string BotToken = "...";
        
        public static TelegramBotClient GetClient()
        {
            return new TelegramBotClient(BotToken);
        }

        public static async void setWebHook()
        {
            TelegramBotClient client = new TelegramBotClient(BotToken);
            await client.SetWebhookAsync(AppUrl + "/api/Bot");
            
        }

     
    }
}
