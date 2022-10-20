using Business.AutoMapper.Profiles;
using Business.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace UIAdmin
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddFluentValidation();
            services.MyService();
            services.AddAutoMapper(typeof(AllProfile));

            // Kontrol sonrasý nasýl iþlem yapýlacaðýný belirten kod bloðum.
            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x=>{
                    x.LoginPath = "/Login";
                    x.ExpireTimeSpan = TimeSpan.FromHours(1);
                    x.AccessDeniedPath = "/Denied";
            });
            // Butün Controller'da kontrolü Yapan Yapýmýzdýr.
            services.AddControllersWithViews(x => {
                var dogrulama = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                x.Filters.Add(new AuthorizeFilter(dogrulama));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles(); // wwwroot içerisindeki Dosyalarý link yoluyla Kullanabilme imkaný saðlýyor.
            app.UseRouting(); // URL Yapým
            app.UseAuthentication(); // Giriþ Kontrolü
            app.UseAuthorization(); // Yetki Kontrolü
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
