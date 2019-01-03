using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoaspnetcli.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace demoaspnetcli
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ISaluto,FirstClass>();
            services.AddSingleton<IStudenti,DatiStudenti>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IConfiguration configuration, ISaluto saluto, ILogger<Startup> logger)
        {
            app.UseStaticFiles();
            //app.UseWelcomePage();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(next => {
                return async context => {
                    if (context.Request.Path.StartsWithSegments("/pippo")){
                        logger.LogCritical("Stacca stacca!");
                        await context.Response.WriteAsync("Non sei autorizzato");
                    }
                    else {
                        logger.LogInformation("Genero la risposta");
                        await next(context);
                    }
                };
            });

            app.Run(async (context) =>
            {
                logger.LogInformation("Richiesta ricevuta.");
                logger.LogInformation(env.EnvironmentName);
                var salutodev = configuration["saluto"];
                await context.Response.WriteAsync(salutodev);
            });
        }
    }
}
