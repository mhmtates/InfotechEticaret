using Business.Abstract;
using Core.Results.ComplexTypes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UIAdmin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsersAdminService db;
        public LoginController(IUsersAdminService _db)
        {
            db = _db;
        }
        [AllowAnonymous] //Authorization Özelliğinin Bu Sayfayı Kontrol Etmemesini Sağlıyor.
        public async Task<IActionResult> Index()
        {
            //var ClaimTypesName = User.Identity.Name;
            //var ClaimTypesRole = User.IsInRole("Admin");
            //var CustomId = User.Claims.FirstOrDefault(x => x.Type == "Id").Value.ToString();
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(string Email, string Password)
        {
            // using System.Security.Claims;
            if (db.Login(Email, Password).ResultStatus == ResultStatus.Success)
            {
                var data = db.Login(Email, Password).Data;
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,data.NameSurName),// Varsayılan yapıda Çağırmak kolay.
                    new Claim(ClaimTypes.Role, data.Roles), // Veriler Saklanırken şifrelicez daha sonra. Sha1,Md5
                    new Claim("Id",data.Id.ToString()),// Custom Tanımlamada Biraz Zordur.
                };
                var UserIdentity = new ClaimsIdentity(claims, "LoginControl"); // Talep'i Hazırlıyoruz.
                ClaimsPrincipal principal = new ClaimsPrincipal(UserIdentity); // Talep Sorumlusu, Yani Hazır Hale geliyor.
                await HttpContext.SignInAsync(principal);
                return Redirect("/Home");
            }
            else
            {
                return View();
            }
        }
    }
}
