using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace UIWeb.Controllers
{
    [AllowAnonymous]
    public class PartialViewController : Controller
    {
        private readonly ITempBasketsService db;
        public PartialViewController(ITempBasketsService _db)
        {
            db = _db;
        }
        
        public IActionResult SepetAdetKontrol()
        {
            int Cookie = Convert.ToInt32(Request.Cookies["SepetId"]);
            if (db.GetAll(Cookie).Data == null)
            {
                return PartialView("/Views/PartialView/_PartialViewSepetAdet.cshtml", db.GetAll(Cookie).Data);
            }
            else
            {
                return PartialView("/Views/PartialView/_PartialViewSepetAdet.cshtml", db.GetAll(Cookie).Data.Count);
            }
        }
    }
}
