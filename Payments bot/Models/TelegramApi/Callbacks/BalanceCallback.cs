using Payments_bot.Models.PrivatApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Payments_bot.Models.TelegramApi.Callbacks
{
    public class BalanceCallback : ICallback
    {
        public string Name { get; set; } = "balance";

        public void Execute(TelegramBotClient client, CallbackQuery callback)
        {
            
        }
    }
}
