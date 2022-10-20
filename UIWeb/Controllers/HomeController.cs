using Business.Abstract;
using Core.Results.ComplexTypes;
using Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UIWeb.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IProductsService service;
        private readonly IVariantService v;
        private readonly ITempBasketsService sepet;
        public HomeController(IProductsService _service, ITempBasketsService _sepet, IVariantService _v)
        {
            service = _service;
            sepet = _sepet;
            v = _v;
        }
        public IActionResult Index()
        {
            var data = service.GetAll(); // IList //IEnumerable / 2 defa  Oluştu.
            return View(service.GetAll());
        }
        public JsonResult SepetEkle(string ID)
        {
            string Mesaj = "";
            if (v.GetAll(int.Parse(ID)).Data != null)
            {
                Mesaj = "Bu Ürüne Ait varyasyonlar olduğu için detay sayfasından seçim yaparak ekleyebilirsiniz.";
            }
            else
            {
                if (Request.Cookies["SepetId"] == null)
                {
                    // Yeni Cookies Üretme Ekranı.
                    int Bulunan = sepet.GetByIdAuto(1).Data.Uretilen + 1;// İlk Başta Veritanındaki Cookie'yi alıp üzerine 1 ekliyor.
                    CookieOptions cookie = new CookieOptions();
                    cookie.Expires = DateTime.Now.AddDays(6);
                    Response.Cookies.Append("SepetId", Bulunan.ToString(), cookie);

                    AutoBasketDto dto = sepet.GetByIdAuto(1).Data;
                    dto.Uretilen++;
                    sepet.AutoBasketUpdate(dto);
                    // Yeni Cookies Üretme Ekranı.

                    Mesaj = sepet.AddUpdate(Convert.ToInt32(ID), Bulunan,0).Message;
                }
                else
                {
                    int Cookie = Convert.ToInt32(Request.Cookies["SepetId"]);
                    Mesaj = sepet.AddUpdate(Convert.ToInt32(ID), Cookie,0).Message;
                }
            }
            return Json(Mesaj);
        }
    }
}
