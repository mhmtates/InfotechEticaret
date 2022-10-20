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

            // Kontrol sonras� nas�l i�lem yap�laca��n� belirten kod blo�um.
            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x=>{
                    x.LoginPath = "/Login";
                    x.ExpireTimeSpan = TimeSpan.FromHours(1);
                    x.AccessDeniedPath = "/Denied";
            });
            // But�n Controller'da kontrol� Yapan Yap�m�zd�r.
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
            app.UseStaticFiles(); // wwwroot i�erisindeki Dosyalar� link yoluyla Kullanabilme imkan� sa�l�yor.
            app.UseRouting(); // URL Yap�m
            app.UseAuthentication(); // Giri� Kontrol�
            app.UseAuthorization(); // Yetki Kontrol�
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
