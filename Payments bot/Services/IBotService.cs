using Telegram.Bot;

namespace Payments_bot.Services
{
    public interface IBotService
    {
        
        public TelegramBotClient GetClient();
        public  void setWebHook();
    }
}
