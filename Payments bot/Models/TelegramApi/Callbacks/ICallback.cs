using Telegram.Bot;
using Telegram.Bot.Types;

namespace Payments_bot.Models.TelegramApi.Callbacks
{
    interface ICallback
    {
        public string Name { get; set; }
        public ResponseTextMessage Execute(CallbackQuery callback);
    }
}
