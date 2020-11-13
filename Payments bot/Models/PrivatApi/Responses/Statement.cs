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
        public double Amount { get; set; }
        public double CardAmount { get; set; }
        public double Rest { get; set; }

       

    }
}
