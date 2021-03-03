using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payments_bot.Data;
using Payments_bot.Services;

namespace Payments_bot
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }
        
        
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddControllersWithViews().AddNewtonsoftJson(); 
            services.AddDbContext<BotContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BotContext")));
            services.AddTransient<IUpdateService, UpdateService>();
            

        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,BotContext context)
        {

            context.Database.Migrate(); 
            AppConfig.setWebHook();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(

                    name: "home",
                    pattern: "{controller}/{action}/{user?}"
                    );
            });

        }
    }
}
