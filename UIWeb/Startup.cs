using Business.AutoMapper.Profiles;
using Business.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace UIWeb
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.MyService();
            services.AddAutoMapper(typeof(AllProfile));

            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x => {
                    x.LoginPath = "/Customer";
                    // Cookies Tarayýcý açýlýp kapandýðýnda belirlenen süre kadar kalsýn.
                });
            services.AddControllersWithViews(x => {
                var dogrulama = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                x.Filters.Add(new AuthorizeFilter(dogrulama));
            });
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
                app.UseStatusCodePagesWithReExecute("/Home/HandleError");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
