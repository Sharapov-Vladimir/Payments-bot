using Payments_bot.Data;
using Payments_bot.Models.PrivatApi;
using System;
using System.Linq;
using Telegram.Bot.Types;

namespace Payments_bot.Models.TelegramApi.Callbacks
{
    public class HistoryCallback : ICallback
    {
        private BotContext context;
       
        public HistoryCallback(BotContext context)
        {
            this.context = context;
        }
       
        public string Name { get; set; } = "history";

   
       public ResponseTextMessage Execute(CallbackQuery callback)
        {
            long merchID = long.Parse(callback.Data.Split("=")[1]);
            int period = int.Parse(callback.Data.Split("=")[2]);
            DateTime ed = DateTime.Now;
            DateTime sd = ed.AddDays(-period);
            Merchant merchant = context.Merchants.FirstOrDefault(m => m.Id == merchID);
            string response = ResponseBuilder.GetHistory(merchant, sd, ed);


            return new ResponseTextMessage
            {

                ChatId = callback.Message.Chat.Id,
                text = response,
                keyboardMarkup = null

            };
        }
    }
}
