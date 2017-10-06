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
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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
