using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using UIWeb.Models;
namespace UIWeb.Controllers
{
    [AllowAnonymous]
    public class DenemeController : Controller
    {
        public IActionResult Index()
        {
            TokenModel tk = new TokenModel();
            tk.kulAdi = "admin";
            tk.sifre = "123";
            tk.role = "admin";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.gulerarslan.com/api/Users/");
                var PostYapilacakAdres = client.PostAsJsonAsync<TokenModel>("TokenUret", tk);
                PostYapilacakAdres.Wait();

                if (PostYapilacakAdres.Exception != null)
                {
                    
                    ModelState.AddModelError(string.Empty, PostYapilacakAdres.Result.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    var data = PostYapilacakAdres.Result.Content.ReadAsStringAsync().Result.Replace("\"", "");
                }
            }

            return View();
        }

        public IActionResult VeriCek()
        {
            List<Veriler> urunlerim = new List<Veriler>();

            using (var client = new HttpClient())
            {
                // URL Tanıtma
                client.BaseAddress = new Uri("https://api.gulerarslan.com/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFkbWluIiwicm9sZSI6ImFkbWluIiwibmJmIjoxNjI0MTMxMDM2LCJleHAiOjE2MjQxMzQ2MzYsImlhdCI6MTYyNDEzMTAzNn0.aFFfPxdfaHEFhTvnGHqQ15whjkuLzap0R9ChtV3tx9w");
                // O Url içerisinde Hangi Sayfadan Veri Alacağım.
                var CekilenSayfa = client.GetAsync("Users");
                CekilenSayfa.Wait();

                // Nugget=> Microsoft.AspNet.WebApi.Client Yükle
                var DataCoz = CekilenSayfa.Result.Content.ReadAsAsync<List<Veriler>>();

                // Eğer Hata Mesajı Geliyorsa
                if (DataCoz.Exception != null)
                {
                    ViewBag.Message = CekilenSayfa.Result.Content.ReadAsStringAsync().Result.Replace("\"", "");
                }
                else
                {
                    urunlerim = DataCoz.Result;
                }
                return View(urunlerim);
            }
        }
    }
}
