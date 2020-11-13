using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Payments_bot.Data;
using Payments_bot.Models.TelegramApi;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Payments_bot.Services
{
    public class UpdateService : IUpdateService
    {
        
        
        private BotContext context;
        
        
        public UpdateService(BotContext context)
        {
            this.context = context;
            
        }

       
        private ResponseTextMessage Build(Update update)
        {
            

            if(UpdateType.Message.CompareTo(update.Type)==0) 
            {
               return CommandHandler.Handle(context, update.Message);
                
            }
             
            if(update.Type == UpdateType.CallbackQuery)
            {
               return CallbackHandler.Handle(context, update.CallbackQuery);    
            }

            return null;
        }

        public async Task<ResponseTextMessage> Update(Update update)
        {
            return Build(update);
        }
    }
}
