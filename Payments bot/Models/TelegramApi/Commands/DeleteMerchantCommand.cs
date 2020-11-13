using Payments_bot.Data;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Payments_bot.Models.TelegramApi.Commands
{
    public class DeleteMerchantCommand : ITelegramCommand
    {
        private BotContext context;

        public DeleteMerchantCommand(BotContext context)
        {
            this.context = context;
        }
        public string Name { get; set; } = "/delete";

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
                    buttons.Add(InlineKeyboardButton.WithCallbackData($"Id:{merchant.Id}", $"delete={merchant.Id}"));
                }
                keyboard = new InlineKeyboardMarkup(buttons);


                return new ResponseTextMessage
                {
                   
                    ChatId = message.Chat.Id,
                    text = "выберите мерчанта из списка",
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
