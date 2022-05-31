using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        } 

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();//redirect to exception page when env.variable is assigned as development
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");//here u can change default error page of the application
            }
            app.UseHttpsRedirection();//UseHttpsRedirection Middleware redirect HTTP requests to HTTPS. 

            app.UseStaticFiles();

            app.UseRouting();// Matches request to an endpoint.


            app.UseEndpoints(endpoints =>//// Must be after UseRouting()
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");//The EndpointMiddleware is responsible for execution the Endpoint.
            });
            //the MapControllerRoute creates a single route, 
            //which is named as default and the URL Pattern of the route is {controller=Home}/{action=Index}/{id?}

        }
    }
}
