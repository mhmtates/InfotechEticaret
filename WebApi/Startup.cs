using Business.AutoMapper.Profiles;
using Business.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebApi.JwtAuthorizeToken.Abstract;
using WebApi.JwtAuthorizeToken.Concrete;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(x => 
            x.AddPolicy("CorsPolicy",c=> c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

            services.AddControllers();
            services.MyService();
            services.AddAutoMapper(typeof(AllProfile));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });
            // appSettings içerisinde Security Key Çekiyoruz.
            string SecurityKey = Configuration["Token:SecurityKey"];
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false, // Herkes Kullanabilir.
                    ValidAudience = Configuration["Token:Audience"], // Kullanacak Adresler.
                    ValidateIssuer = false, // Dağıtım Yapan Bilgisi Açık.
                    ValidIssuer = Configuration["Token:Issuer"], // Dağıtım Yapan.
                    ValidateIssuerSigningKey = true, // Çözmek için Güvenlik Anahtarı var
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey))
                };
            });
            services.AddScoped<IAuthService, AuthManager>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gulerarslan.com");
                    c.DefaultModelsExpandDepth(-1);
                });
            }
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
