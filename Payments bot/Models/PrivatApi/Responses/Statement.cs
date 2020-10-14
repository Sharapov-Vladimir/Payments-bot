using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments_bot.Models.PrivatApi.Responses
{
    public class Statement
    {
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Amount { get; set; }
        public string CardAmount { get; set; }
        public string Rest { get; set; }
        
    }
}
