using AutoMapper.Configuration;
using Business.Abstract;
using Core.Results.ComplexTypes;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.JwtAuthorizeToken.Abstract;
namespace WebApi.JwtAuthorizeToken.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly string SecretKey;
        private readonly IUsersAdminService users;
        private readonly Microsoft.Extensions.Configuration.IConfiguration config;
        // Readonly kullanılan değişken veya interface sadece Yapıcı sayesinde türetilebilir.
        public AuthManager(IUsersAdminService _users, Microsoft.Extensions.Configuration.IConfiguration _config)
        {
            config = _config;
            users = _users;
            SecretKey = config["Token:SecurityKey"];
        }
        public string Authenticate(string username, string password)
        {
            var Data = users.Login(username, password);
            if (Data.ResultStatus == ResultStatus.Success)
            {
                var TokenHandler = new JwtSecurityTokenHandler(); // Token üretip, Kullanıcıya ileticek olan sınıfım.
                var TokenKey = Encoding.ASCII.GetBytes(SecretKey); // Güvenlik Anahtarı AppSettings 'den Çekilecek.

                // Hangi Algoritmayı Kullanacağı, hangi bilgileri tutacağı ve Ne kadar Süre geçerli kalacağı.
                var TokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim("Id", Data.Data.Id.ToString()), // Kullanıcının ID bilgisi tutuluyor.
                        new Claim(ClaimTypes.Name, Data.Data.NameSurName), // Giriş Yapanın Adı
                        new Claim(ClaimTypes.Role, Data.Data.Roles) //Role Bilgisi
                    }),
                    Expires = DateTime.UtcNow.AddHours(2), // Token'ın Ne kadar Kalacağı Belirtiliyor.
                    // Hangi Key'i ve Algoritmayı kullanacağı belirtiliyor.
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(TokenKey),SecurityAlgorithms.HmacSha256Signature)
                };
                // Yukarıdaki Descriptor içindeki bilgileri baz alarak algoritmayı üret.
                var Token = TokenHandler.CreateToken(TokenDescriptor);
                // Üretilen Token'ı Kullanıcıya göster.
                return TokenHandler.WriteToken(Token);
            }
            else
            {
                return "Böyle Bir Kullanıcı Bulunamadı.";
            }
        }
    }
}
