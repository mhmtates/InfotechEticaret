using Business.Abstract;
using Core.Results.ComplexTypes;
using Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace UIWeb.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ITempBasketsService sepet;
        private readonly ICustomersService customers;
        private readonly IOrderDetailsService detail;
        private readonly IOrdersService order;
        public PaymentController(ITempBasketsService _sepet, ICustomersService _customers, IOrderDetailsService _detail, IOrdersService _order)
        {
            sepet = _sepet;
            customers = _customers;
            detail = _detail;
            order = _order;
        }
        public IActionResult Index()
        {
            int Cookie = Convert.ToInt32(Request.Cookies["SepetId"]);
            int BulunanUyeId = int.Parse(User.FindFirst(x => x.Type == "ID").Value.ToString());
            ViewBag.Uyeler = customers.GetById(BulunanUyeId).Data;

            return View(sepet.GetAll(Cookie).Data);
        }
        [HttpPost]
        public IActionResult Index(string OdemeYontemi)
        {
            int BulunanUyeId = int.Parse(User.FindFirst(x => x.Type == "ID").Value.ToString());
            int Cookie = Convert.ToInt32(Request.Cookies["SepetId"]);

            // NOT : Aldığımız Kayıt hatası bizim dikkatsizliğimizden kaynaklıdır. Eğer ilişkili tablolarda ekleme yapılıyorsa,ilk olarak ana tabloya veri eklenir, sonra ilişkili olduğu tabloya veri eklenir.

            // Order Kayıt.
            decimal ToplamFiyat = 0;
            foreach (var item in sepet.GetAll(Cookie).Data)
            {
                ToplamFiyat += item.Price * item.Piece;
            }
            OrderUpdateDto siparis = new OrderUpdateDto();
            siparis.Id = Cookie;
            siparis.CargoNumber = "0";
            siparis.CargoPrice = 0;
            siparis.CouponPrice = 0;
            siparis.Kdv = 18;
            siparis.OrderDate = DateTime.Now;
            siparis.TotalDiscount = 0;
            siparis.TotalPrice = ToplamFiyat;
            siparis.CustomersId = BulunanUyeId;
            // Geçici Sepettteki Tüm Ürünleri Getiriyor.
            siparis.OdemeTuru = OdemeYontemi;
            if (OdemeYontemi == "Kapıda Ödeme")
            {
                siparis.OrderStatus = "Onay Bekliyor.";
            }
            else if (OdemeYontemi == "Havale İle Ödeme")
            {
                siparis.OrderStatus = "Ödeme Bekleniyor.";
            }
            if (OdemeYontemi == "Kredi Kartı İle Ödeme")
            {
                siparis.OrderStatus = "Onaylandı.";
            }
            var Data = order.Add(siparis).ResultStatus;

            // OrderDetail Kayıt.
            foreach (var item in sepet.GetAll(Cookie).Data)
            {
                OrderDetailsDto dto = new OrderDetailsDto();
                dto.Name = item.Name;
                dto.VName = item.VName;
                dto.Price = item.Price;
                dto.OrdersId = Cookie;
                dto.Piece = item.Piece;
                dto.ProductsId = item.ProductsId;
                detail.Add(dto);
                // Orderdetails'e taşıdıktan sonra, Geçici Sepetten siliyoruz.
                sepet.Delete(item.Id);
            }
            if (Data == ResultStatus.Success)
            {
                TempData["Mesaj"] = Cookie + " Numaralı Siparişiniz Alınmıştır.";


                // İşlem Başarılı bir şekilde Tamamlandıysa Kullanıcıya Ait Cookies Silinir.
                // Tekrar Sipariş verecekse yenisi üretilir. Her sipariş başına 1 Cookies

                var GelenCookies = Request.Cookies["SepetId"];
                CookieOptions cookie = new CookieOptions();
                cookie.Expires = DateTime.Now.AddDays(-6);
                Response.Cookies.Append("SepetId", GelenCookies, cookie);


                return Redirect("Payment/Basarili");
            }
            else
            {
                return Redirect("Payment/Basarisiz");
            }
        }

        public IActionResult Basarili()
        {
            return View();
        }
        public IActionResult Basarisiz()
        {
            return View();
        }
    }
}
