﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Payments_bot.Data;
using Payments_bot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Payments_bot.Services
{
    public static class AppConfig
    {
        public static readonly string AppUrl = "https://00e29ed505ad.ngrok.io";
        private static readonly string BotToken = "1359314134:AAG14ANbOji--DOOcZ6IbBNnKB4nidN8E9U";
        
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