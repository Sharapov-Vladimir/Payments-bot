using Payments_bot.Data;
using System;
using System.Linq;
using Telegram.Bot.Types;


namespace Payments_bot.Models.TelegramApi.Callbacks
{
    public class DeleteCallback : ICallback
    {
        public string Name { get; set; } = "delete";
        private BotContext context;

        public DeleteCallback(BotContext context)
        {
            this.context = context;
        }


        public ResponseTextMessage Execute(CallbackQuery callback)
        {
            long merchID = long.Parse(callback.Data.Split("=")[1]);
           
            
            try 
            {
                Merchant Selectedmerchant = context.Merchants.FirstOrDefault(m => m.Id == merchID);
                context.Merchants.Remove(Selectedmerchant);
                context.SaveChanges();
                return new ResponseTextMessage
                {

                    ChatId = callback.Message.Chat.Id,
                    text = "Мерчант удален",
                    keyboardMarkup = null

                };
            }
            catch (Exception)
            {
                return new ResponseTextMessage
                {

                    ChatId = callback.Message.Chat.Id,
                    text = "Мерчант уже был удален" ,
                    keyboardMarkup = null

                };
            }
          
            
           
           

           

        }
    }
}
