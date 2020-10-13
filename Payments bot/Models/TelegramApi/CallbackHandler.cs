using Payments_bot.Data;
using Payments_bot.Models.TelegramApi.Callbacks;
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
        private static List<ICallback> callbacks = new List<ICallback>
        {


        };

        public static void Handle(TelegramBotClient client, CallbackQuery callback)
        {
            

            try
            {
                
            }
            catch (Exception e)
            {
               
            }

        }

    }
}
