using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Payments_bot.Data
{
    public class User
    {
        [Key]
        public int Key { get; set; }
        
        public long Id { get; set; }

        public List<Merchant> Merchants { get; set; } = new List<Merchant>();
    }
}
