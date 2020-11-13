using Payments_bot.Models.TelegramApi;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Payments_bot.Services
{
    public interface IUpdateService
    {
        
       
        public Task<ResponseTextMessage> Update(Update update);
    }
}
