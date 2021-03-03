using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Payments_bot.Data;
using Payments_bot.Models.other;

namespace Payments_bot.Controllers
{
    
    public class HomeController : Controller
    {
        private BotContext context;

        public HomeController(BotContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult NewMerchant(int user)
        {
            ViewBag.User = user;
            return View();
        }
        [HttpGet]
        public IActionResult Success()
        {
            
            return View();
        }
        public IActionResult Error()
        {

            return View();
        }

        [HttpPost]
        public IActionResult NewMerchant(NewMerchantForm form)
        {
            if (ModelState.IsValid)
            {
                Merchant unverified = new Merchant(form.Id, form.Password, form.User, form.CreditCard);
                bool exists = context.Merchants.FirstOrDefault(m => m.Id == unverified.Id) != null;

                if (exists == false)
                {
                    context.Merchants.Add(unverified);
                    context.SaveChanges();
                    return RedirectToAction("Success");
                }
                return RedirectToAction("Error");
            }

            return View();

          
                   
        }
       

     
    }
}