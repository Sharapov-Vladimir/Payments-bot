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
        [Key]
        public int Key { get; set; }
        public long Id { get; set; }
        public string Password { get; set; }
        public long CreditCard { get; set; }
        public int UserKey { get; set; }
        public User user { get; set; } = new User();
       
        
       
        
        public Merchant()
        {

        }
        public Merchant(  long? Id, string Password, long UserId , long? CreditCard)
        {
            this.Id = (long)Id;
            this.Password = Password;
            user.Id = UserId;
            this.CreditCard = (long)CreditCard;
        }
        

    }
}
