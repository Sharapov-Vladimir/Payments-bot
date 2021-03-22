using Microsoft.EntityFrameworkCore;
using Payments_bot.Services;

namespace Payments_bot.Data
{
    public class BotContext:DbContext
    {
        public BotContext(DbContextOptions<BotContext> options) : base(options) {}
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<User> Users { get; set; }

       
       
        
    }
}
