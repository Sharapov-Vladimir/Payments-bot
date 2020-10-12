using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Payments_bot.Models.TelegramApi
{
    public static class CallbackHandler
    {
        public static void Handle(TelegramBotClient client , CallbackQuery callback ) 
        {
            switch (callback.Data)
            {
               

                default:
                    return;
            }

        }
        
    }
}
