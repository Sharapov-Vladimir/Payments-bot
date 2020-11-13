using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Payments_bot.Models.TelegramApi
{
    public class ResponseTextMessage
    {
        public ChatId ChatId { get; set; }
        public string text { get; set; }
        public InlineKeyboardMarkup keyboardMarkup {get;set;}
    }
}
