using Payments_bot.Data;
using Payments_bot.Models.PrivatApi;
using System.Linq;
using Telegram.Bot.Types;

namespace Payments_bot.Models.TelegramApi.Callbacks
{
    public class BalanceCallback : ICallback
    {
        private BotContext context;
        
        public BalanceCallback(BotContext context)
        {
            this.context = context;
        }

       
        public string Name { get; set; } = "balance";

        

       public ResponseTextMessage Execute(CallbackQuery callback)
        {

            long merchID = long.Parse(callback.Data.Split("=")[1]);
            Merchant merchant = context.Merchants.FirstOrDefault(m => m.Id == merchID);
            string response = ResponseBuilder.GetBalance(merchant);

            return new ResponseTextMessage
            { 
                ChatId = callback.Message.Chat.Id,
                text = response,
                keyboardMarkup = null

            };
        }
    }
}
