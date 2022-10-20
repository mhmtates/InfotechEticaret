using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UIWeb.Controllers
{
    [AllowAnonymous]
    public class DetailController : Controller
    {
        private readonly IProductsService db;
        private readonly IPImagesService resim;
        private readonly IVariantService variant;
        public DetailController(IProductsService _db, IPImagesService _resim, IVariantService _variant)
        {
            db = _db;
            resim = _resim;
            variant = _variant;
        }

        [Route("/urun/{UrunAdi}/{Id:int}")]
        public IActionResult Index(string UrunAdi,int Id)
        {
            ViewBag.Resimler = resim.GetAll(Id).Data;
            ViewBag.Varyant = variant.GetAll(Id).Data;

            if (ViewBag.Varyant != null)
            {
                ViewBag.VaryantGroup = variant.GetAll(Id).Data.GroupBy(x => x.GroupName).FirstOrDefault().Key;
            }

            return View(db.GetById(Id).Data);
        }
    }
}
