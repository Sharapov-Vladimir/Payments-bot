using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Payments_bot.Data
{
    public class Merchant
    {
        [Key]
        public int Key { get; set; }
        public long Id { get; set; }
        public string Password { get; set; }
        public int UserKey { get; set; }
        public User user { get; set; }

        public Merchant(long Id, string Password, int UserKey)
        {
            this.Id = Id;
            this.Password = Password;
            this.UserKey = UserKey;
        }
        public IEnumerable<CreditCard> CreditCards { get; set; }

    }
}
