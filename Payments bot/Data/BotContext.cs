using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments_bot.Data
{
    public class BotContext
    {
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CreditCard> Cards { get; set; }
    }
}
