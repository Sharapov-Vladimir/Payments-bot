using System;
using System.ComponentModel.DataAnnotations;


namespace Payments_bot.Models.other
{
    public class NewMerchantForm
    {
        
        public long User { get; set; }
       
        [Required]
        [Range(100000, 999999, ErrorMessage = "Id must be a 6 digit number")]
        public long? Id { get; set; }

        [Required]
        public string Password { get; set; }
       
        [Required]
        [Range(1000000000000000,9999999999999999, ErrorMessage="Ivalid card number")]
        public long? CreditCard { get; set; }


       
       

    }
}
