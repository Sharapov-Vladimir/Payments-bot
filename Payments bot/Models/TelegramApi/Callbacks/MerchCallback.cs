using Payments_bot.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Payments_bot.Models.TelegramApi.Callbacks
{
    public class MerchCallback : ICallback
    {
        public string Name { get; set; } = "merch";

        public void Execute(TelegramBotClient client, CallbackQuery callback)
        {
            long merchId = long.Parse(callback.Data.Split("=")[1]);
            IEnumerable<CreditCard> cards;
            List<InlineKeyboardButton> buttons = new List<InlineKeyboardButton>();
            InlineKeyboardMarkup keyboard;

            using (var context = new BotContext())
            {
                cards = context.Merchants.Find(merchId).CreditCards.ToList();
            }
            if (cards.Count() > 0)
            {
                foreach (var card in cards)
                {
                    buttons.Add(InlineKeyboardButton.WithCallbackData($"Карта-{card.Name}", $"card={card.CardNumber}={merchId}"));
                }
                keyboard = new InlineKeyboardMarkup(buttons);

                client.SendTextMessageAsync(
                    chatId: callback.ChatInstance,
                    text: "список ваших карт",
                    replyMarkup: keyboard

                    );
            }
            else
            {
                client.SendTextMessageAsync(
                      chatId: callback.ChatInstance,
                      text: "список ваших карт пуст"


                      );

            }
        }
    }
}
