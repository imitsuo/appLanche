using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using appLanche.Domain;
using appLanche.Infrastructure;
using appLanche.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace appLanche.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LancheContext>(opt => opt.UseInMemoryDatabase("LancheDB"));
            services.AddTransient<IRepository<Lanche>, Repository<Lanche>>();
            services.AddTransient<IRepository<ItemDoPedido>, Repository<ItemDoPedido>>();
            services.AddTransient<IRepository<Ingrediente>, Repository<Ingrediente>>();
            services.AddTransient<IRepository<Promocao>, Repository<Promocao>>();
            services.AddTransient<IPedidoService, PedidoService>();
            services.AddTransient<IDbInitializer, DbInitializer>();
            services.AddLogging();
            services.AddMvc().AddJsonOptions(options => {
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {

            loggerFactory
            .AddConsole(LogLevel.Debug)  // This will output to the console/terminal
            .AddDebug(LogLevel.Debug);

            if (env.IsDevelopment())
            {
                
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
