using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Payments_bot.Models.TelegramApi.Commands
{
    public class NewMerchantCommand:ICommand
    {
        public string Name { get; set; } = "/new merchant";
       


        public void Execute(TelegramBotClient client, Message message)
        {

            client.SendTextMessageAsync(
                chatId: message.Chat,
                text: "текст"
                // ссылка на форму регистрации

                );
           
        }
    }
}
