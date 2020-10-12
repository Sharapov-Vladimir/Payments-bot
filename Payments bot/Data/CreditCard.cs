using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Payments_bot.Data
{
    public class CreditCard
    {
        [Key]
        public int Key { get; set; }

        public int MerchantKey { get; set; }

        public string Name { get; set; }

        public long CardNumber { get; set; }
        public Merchant merchant { get; set; }
    }
}
