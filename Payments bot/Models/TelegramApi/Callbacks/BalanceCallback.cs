using Payments_bot.Data;
using Payments_bot.Models.PrivatApi;
using Payments_bot.Models.PrivatApi.Responses;
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

        public async void Execute(TelegramBotClient client, CallbackQuery callback)
        {
            long CardNumber = long.Parse(callback.Data.Split("=")[1]);
            long merchID = long.Parse(callback.Data.Split("=")[2]);
            Merchant merchant;

            using(var context = new BotContext())
            {
                merchant = context.Merchants.Find(merchID);
            }
            
            merchant.SelectedCard = CardNumber;

            BalanceResponse response = await Requester.GetBalanceResult(merchant);
            
            
        }
    }
}
