using Business.Abstract;
using Core.Results.ComplexTypes;
using Entities.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UIWeb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomersService db;
        public CustomerController(ICustomersService _db)
        {
            db = _db;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(string KullaniciSifre,string KullaniciAdi)
        {
            bool sonuc = (KullaniciAdi.Contains("@") ? true : false);
            if (sonuc) // True ise mail olarak algınacak.
            {
                var data = db.Login(KullaniciAdi, null, KullaniciSifre);
                var claims = new List<Claim>
                {
                    new Claim("ID",data.Data.Id.ToString()),
                    new Claim(ClaimTypes.Name,data.Data.NameSurname),
                };
                var UserIdentity = new ClaimsIdentity(claims, "LoginGiris");
                ClaimsPrincipal principal = new ClaimsPrincipal(UserIdentity);

                var CookiesSuresi = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddMinutes(120), // Kaç Dakika Kalacağı
                    IsPersistent = true // Tarayıcı Kapanıp açıldığında Duracak mı ?
                };
                await HttpContext.SignInAsync(principal, CookiesSuresi);
                return Redirect("/");
            }
            else // telefon olarak
            {
                var data = db.Login(null,KullaniciAdi, KullaniciSifre);
                var claims = new List<Claim>
                {
                    new Claim("ID",data.Data.Id.ToString()),
                    new Claim(ClaimTypes.Name,data.Data.NameSurname),
                };
                var UserIdentity = new ClaimsIdentity(claims, "LoginGiris");
                ClaimsPrincipal principal = new ClaimsPrincipal(UserIdentity);
             
                var CookiesSuresi = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddMinutes(120), // Kaç Dakika Kalacağı
                    IsPersistent = true // Tarayıcı Kapanıp açıldığında Duracak mı ?
                };

                await HttpContext.SignInAsync(principal, CookiesSuresi);

                return Redirect("/");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(CustomersUpdateDto data)
        {
            if (Request.Form["Advert"] == "on")
            {
                data.Advert = true;
            }
            data.Gender = true;
            if (db.Add(data).ResultStatus == ResultStatus.Success)
            {
                CustomersDto uye = db.Login(data.Email, data.Phone, data.Password).Data;
            
                var claims = new List<Claim>
                {
                    new Claim("ID",uye.Id.ToString()),
                    new Claim(ClaimTypes.Name,uye.NameSurname),
                };
                var UserIdentity = new ClaimsIdentity(claims, "LoginGiris");
                ClaimsPrincipal principal = new ClaimsPrincipal(UserIdentity);

                var CookiesSuresi = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(120), // Kaç Dakika Kalacağı
                    IsPersistent = true // Tarayıcı Kapanıp açıldığında Duracak mı ?
                };

                await HttpContext.SignInAsync(principal, CookiesSuresi);
                return Redirect("/");
            }
            else
            {
                TempData["Error"] = "Kayıt Başarısız, Lütfen Tekrar Deneyiniz..";
                return View();

            }
        }
        public IActionResult Hesabim()
        {
            return View();
        }
        public IActionResult Siparislerim()
        {
            return View();
        }
    }
}
