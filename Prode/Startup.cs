
using Datos.Interfaces.Equipo;
using Datos.Repository.Equipo;
using Entidades.DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Negocio.Equipo;
using Negocio.Interface.Equipo;

namespace Prode
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

            var connection = @"Server=.;Database=Prode;Trusted_Connection=True;";
            services.AddDbContext<ProdeContext>(options => options.UseSqlServer(connection));

            services.AddTransient<IJugadorNegocio, JugadorNegocio>();

            services.AddTransient<IJugadorRepository, JugadorRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
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
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

        }

    }
}
