using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payments_bot.Services;
using Telegram.Bot.Types;

namespace Payments_bot.Controllers
{
    [Route("api/[controller]")]
    public class BotController : Controller
    {

        private IUpdateService service;
        public BotController(IUpdateService service)
        {
            this.service = service;
        }
        [HttpPost]
        public void Post([FromBody] Update update)
        {
            service.Update(update);


        }


    }
}
