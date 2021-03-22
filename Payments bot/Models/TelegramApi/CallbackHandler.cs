using Payments_bot.Data;
using Payments_bot.Models.TelegramApi.Callbacks;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Payments_bot.Models.TelegramApi
{
    public static class CallbackHandler
    {
        public static ResponseTextMessage Handle(BotContext context, CallbackQuery data)
        {
            List<ICallback> callbacks = new List<ICallback>
            {
             new BalanceCallback(context),
             new HistoryCallback(context),
             new MerchCallback(context),
             new DeleteCallback(context)

            };
            
            var callback = callbacks.First(c =>data.Data.ToLowerInvariant().StartsWith(c.Name));
            
            var response = callback.Execute(data);
            
            return response;

            
        }

    }
}
