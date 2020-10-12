using Payments_bot.Models.TelegramApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Payments_bot.Services
{
    public class UpdateService : IUpdateService
    {
       //клиент для доступа к TelegramApi с уникальным токеном для бота
        private TelegramBotClient client = new TelegramBotClient("1359314134:AAGIj8oCReXJTh8hHIkOHthfEBcpcu9k6o8");
        public void Update(Update update)
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                    CommandHandler.Handle(client, update.Message);
                    break;
                case UpdateType.CallbackQuery:
                    CallbackHandler.Handle(client, update.CallbackQuery);
                    break;
                default:
                    break;

            }
        }
    }
}
