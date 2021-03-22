using Payments_bot.Data;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Payments_bot.Models.TelegramApi.Commands
{
    public class MyMerchantsCommand : ITelegramCommand
    {
        private BotContext context;

        public MyMerchantsCommand(BotContext context)
        {
            this.context = context;
        }
        public string Name { get; set; } = "/merchants";




        public ResponseTextMessage Execute(Message message)
        {
            long user = message.From.Id;
            IEnumerable<Merchant> merchants;
            List<InlineKeyboardButton> buttons = new List<InlineKeyboardButton>();
            InlineKeyboardMarkup keyboard;


            merchants = context.Merchants.Where(u => u.user.Id == user).ToList();


            if (merchants.Count() > 0)
            {
                foreach (var merchant in merchants)
                {
                    buttons.Add(InlineKeyboardButton.WithCallbackData($"Id:{merchant.Id}", $"merch={merchant.Id}"));
                }
                keyboard = new InlineKeyboardMarkup(buttons);


                return new ResponseTextMessage
                {
                   
                    ChatId = message.Chat.Id,
                    text = "список ваших мерчантов",
                    keyboardMarkup = keyboard

                };
            }
            else
            {
                return new ResponseTextMessage
                {
                    ChatId = message.Chat.Id,
                    text = "список ваших мерчантов пуст"
                };
            }
        }
    }
}
