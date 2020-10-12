using Payments_bot.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Payments_bot.Models.TelegramApi.Commands
{
    public class MyMerchantsCommand : ICommand
    {
        public string Name { get; set; } = "/my merchants";
        

        public void Execute(TelegramBotClient client, Message message)
        {
            long user = message.From.Id;
            IEnumerable<Merchant> merchants;
            List<InlineKeyboardButton> buttons = new List<InlineKeyboardButton>();
            InlineKeyboardMarkup keyboard;
            using (var context = new BotContext())
            {
                merchants = context.Users.Find(user).Merchants.ToList();
            }

            if (merchants.Count() > 0)
            {
                foreach (var merchant in merchants)
                {
                    buttons.Add(InlineKeyboardButton.WithCallbackData($"Id:{merchant.Id}", $"merch={merchant.Id}"));
                }
                keyboard = new InlineKeyboardMarkup(buttons);

                client.SendTextMessageAsync(
                    chatId:message.Chat,
                    text:"список ваших мерчантов",
                    replyMarkup:keyboard

                    );
            }
            else
            {
                client.SendTextMessageAsync(
                      chatId: message.Chat,
                      text: "список ваших мерчантов пуст"
                      

                      );

            }
        }
    }
}
