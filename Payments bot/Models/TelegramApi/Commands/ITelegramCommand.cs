using Telegram.Bot;
using Telegram.Bot.Types;

namespace Payments_bot.Models.TelegramApi.Commands
{
   public interface ITelegramCommand
    {
        public string Name { get; set; }
        public ResponseTextMessage Execute(Message message);
    }
}
