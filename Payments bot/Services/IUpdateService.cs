using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Payments_bot.Services
{
    public interface IUpdateService
    {
        public void Update(Update update);
    }
}
