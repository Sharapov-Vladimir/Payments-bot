using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Payments_bot.Data
{
    public class Merchant
    {
       
        public long Id { get; set; }
        public string Password { get; set; }
        public long UserId { get; set; }
        public User user { get; set; }
       
        [NotMapped]
        public long SelectedCard { get; set; }

        public Merchant(long Id, string Password, int UserId)
        {
            this.Id = Id;
            this.Password = Password;
            this.UserId = UserId;
        }
        public IEnumerable<CreditCard> CreditCards { get; set; }

    }
}
