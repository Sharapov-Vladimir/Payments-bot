using Payments_bot.Data;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Payments_bot.Models.TelegramApi.Callbacks
{
    public class MerchCallback : ICallback
    {
        private BotContext context;
      
        public MerchCallback(BotContext context)
        {
            this.context = context;
        }
       
        public string Name { get; set; } = "merch";

       
        public ResponseTextMessage Execute(CallbackQuery callback)
        {
            long merchId = long.Parse(callback.Data.Split("=")[1]);
            List<InlineKeyboardButton> buttons = new List<InlineKeyboardButton>();


            Merchant merchant = context.Merchants.FirstOrDefault(m => m.Id == merchId);
            List<List<InlineKeyboardButton>> rows = new List<List<InlineKeyboardButton>>();
            List<InlineKeyboardButton> row1 = new List<InlineKeyboardButton>
            {

                InlineKeyboardButton.WithCallbackData("Текущий баланс на карте", $"balance={merchant.Id}"),
            };
            List<InlineKeyboardButton> row2 = new List<InlineKeyboardButton>
            {
                InlineKeyboardButton.WithCallbackData("История платежей за неделю", $"history={merchant.Id}=7")
            };
            List<InlineKeyboardButton> row3 = new List<InlineKeyboardButton>
            {
                InlineKeyboardButton.WithCallbackData("История платежей за последние 30 дней", $"history={merchant.Id}=30")
            };
            List<InlineKeyboardButton> row4 = new List<InlineKeyboardButton>
            {
                InlineKeyboardButton.WithCallbackData("История платежей за последние 90 дней", $"history={merchant.Id}=90")
            };

            rows.Add(row1);
            rows.Add(row2);
            rows.Add(row3);
            rows.Add(row4);

            InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup(rows);

            return new ResponseTextMessage
            {
               
                ChatId = callback.Message.Chat.Id,
                text = "Доступные операции по мерчанту",
                keyboardMarkup = keyboard

            };
        }
    }
}
