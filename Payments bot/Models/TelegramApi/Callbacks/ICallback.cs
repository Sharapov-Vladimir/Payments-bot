using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Payments_bot.Models.TelegramApi.Callbacks
{
    interface ICallback
    {
        public string Name { get; set; }
        public void Execute(TelegramBotClient client, CallbackQuery callback);
    }
}
