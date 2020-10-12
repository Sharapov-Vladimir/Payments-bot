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
        public long UserId { get; set; }
        public IEnumerable<Merchant> Merchants { get; set; }
    }
}
