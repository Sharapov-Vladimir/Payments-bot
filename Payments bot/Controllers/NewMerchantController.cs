using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Payments_bot.Controllers
{
    [Route("[controller]")]
    public class NewMerchantController : Controller
    {
        
        public IActionResult Index()
        {
            ViewBag.s = "kek";
            return View();
        }
    }
}