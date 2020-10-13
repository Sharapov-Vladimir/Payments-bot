using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Payments_bot.Models.TelegramApi.Callbacks
{
    public class CardCallback : ICallback
    {
        public string Name { get; set; } = "card";

        public void Execute(TelegramBotClient client, CallbackQuery callback)
        {
            long CardNumber = long.Parse(callback.Data.Split("=")[1]);
            long MerchId = long.Parse(callback.Data.Split("=")[2]);
            InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup(new InlineKeyboardButton[]

            {
            InlineKeyboardButton.WithCallbackData("Текущий баланс на карте", $"balance={CardNumber}={MerchId}"),
            InlineKeyboardButton.WithCallbackData("История платежей", $"history={CardNumber}={MerchId}")

            });

            client.SendTextMessageAsync(
                   chatId: callback.ChatInstance,
                   text: "Операции по карте",
                   replyMarkup: keyboard

                   ); 

        }
    }
}
