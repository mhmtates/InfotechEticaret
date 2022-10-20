using Business.Abstract;
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
    public class CategoryController : Controller
    {
        private readonly ICategoriesService db;
        private readonly IProductsService Pdb;
        public CategoryController(ICategoriesService _db, IProductsService _Pdb)
        {
            db = _db;
            Pdb = _Pdb;
        }
        [Route("/{GetName}/{id:int}")]
        public IActionResult Index(string GetName, int id)
        {

            string Siralama = HttpContext.Request.Query["Sira"];


            ViewBag.Kategori = db.GetById(id).Data;
            ViewBag.AltKategori = db.GetAll(id).Data;
            IList<ProductsDto> products = new List<ProductsDto>();
            // Tıklanan Kategori içerisinde ürün var ise getiriyor.
            if (Pdb.KategoriyeGoreUrunGetirme(db.GetById(id).Data.Id).Data != null)
            {
                foreach (var c in Pdb.KategoriyeGoreUrunGetirme(db.GetById(id).Data.Id).Data)
                {
                    products.Add(c);
                }
            }

            if (db.GetAll(id).Data != null)
            {
                // Tıklanan Kategorinin Alt Kategorileri içierisinde ürün var ise getiriyor.
                // Bütün Alt Kategorileri ve alt kategorinin alt kategorilerini getiriyor alttaki foreach.
                // A >  B >  C
                foreach (var item in db.GetAll(id).Data)
                {
                    // Elektronik => Dizustu
                    // Tıklanan Kategorinin Alt Kategorisi içierisinde ürün var ise getiriyor.
                    if (Pdb.KategoriyeGoreUrunGetirme(item.Id).Data != null)
                    {
                        foreach (var c in Pdb.KategoriyeGoreUrunGetirme(item.Id).Data)
                        {
                            products.Add(c);
                        }
                    }
                    // Elektronik => Dizustu => Oyuncu Özel Bilgisayar
                    // Tıklanan Kategorinin Alt Kategorisinin Alt kategorisinde içierisinde ürün var ise getiriyor.
                    if (db.GetAll(item.Id).Data != null)
                    {
                        foreach (var a1 in db.GetAll(item.Id).Data)
                        {
                            if (Pdb.KategoriyeGoreUrunGetirme(a1.Id).Data != null)
                            {
                                foreach (var c in Pdb.KategoriyeGoreUrunGetirme(a1.Id).Data)
                                {
                                    products.Add(c);
                                }
                            }
                            if (db.GetAll(a1.Id).Data != null)
                            {
                                foreach (var a2 in db.GetAll(a1.Id).Data)
                                {
                                    if (Pdb.KategoriyeGoreUrunGetirme(a2.Id).Data != null)
                                    {
                                        foreach (var c in Pdb.KategoriyeGoreUrunGetirme(a2.Id).Data)
                                        {
                                            products.Add(c);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (Siralama == "FGA")
            {
                return View(products.OrderBy(x => x.Discount));
            }
            else if (Siralama == "FGAZ")
            {
                return View(products.OrderByDescending(x => x.Discount));
            }
            else if (Siralama == "AZ")
            {
                return View(products.OrderBy(x => x.Name));
            }
            else if (Siralama == "ZA")
            {
                return View(products.OrderByDescending(x => x.Name));
            }
            else
            {
                return View(products);
            }
        }
    }
}
