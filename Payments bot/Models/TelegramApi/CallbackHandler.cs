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

            string CallbackName = callback.Data.Split('=')[0];
            string CallbackData = callback.Data.Split('=')[1];


            switch (CallbackName)
            {

                case "merch":
                    Merch(CallbackData);
                    break;
                case "card":
                    Card(CallbackData);
                    break;
                case "getbalance":
                    GetBalance(CallbackData);
                    break;
                case "gethistory":
                    GetHistory(CallbackData);
                    break;

                default:
                    return;
            }

        }
        private static void Merch(string CallbackData)
        {

        }
        private static void Card(string CallbackData)
        {

        }
        private static void GetBalance(string CallbackData)
        {

        }
        private static void GetHistory(string CallbackData)
        {

        }
    }
}
