using Auth0.AspNetCore.Authentication;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using DAL;
using Microsoft.IdentityModel.Tokens;

namespace WRA
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            // Configure services
            Configuration = configuration;
            DbController.Start(configuration.GetConnectionString("conStr"));
            /*Mailer.MailServer.Configure(
                configuration.GetValue<string>("MailHost"),
                configuration.GetValue<int>("MailPort"),
                configuration.GetValue<string>("MailUser"),
                configuration.GetValue<string>("MailPass")
                );*/
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddAuthorization(options => {
                options.AddPolicy("ADMIN", authBuilder => { authBuilder.RequireRole("ADMIN"); });
                options.AddPolicy("SECRETARY", authBuilder => { authBuilder.RequireRole("SECRETARY"); });
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuth0WebAppAuthentication(options => {
                options.Domain = Configuration["Auth0:Domain"];
                options.ClientId = Configuration["Auth0:ClientId"];
            });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
