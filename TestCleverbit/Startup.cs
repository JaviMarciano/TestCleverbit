using System;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestCleverbit.DependencyInjections;

namespace TestCleverbit
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;           
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddWebSiteDependencies(Configuration);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                spa.CheckAndStartAngular();
            });
        }
    }

    public static class SpaBuilderExtensions
    {        
        public static ISpaBuilder CheckAndStartAngular(this ISpaBuilder spa, string url = "http://localhost:4200/")
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead).Result;
                    spa.UseProxyToSpaDevelopmentServer(url);
                }
            }
            catch (Exception)
            {
                spa.UseAngularCliServer(npmScript: "start");
            }

            return spa;
        }
    }
}
