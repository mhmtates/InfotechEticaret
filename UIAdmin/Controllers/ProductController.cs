using Business.Abstract;
using Core.Results.ComplexTypes;
using Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace UIAdmin.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private readonly IProductsService db;
        private readonly IPImagesService imagesdb;
        public ProductController(IProductsService _db, IPImagesService _imagesdb)
        {
            db = _db;
            imagesdb = _imagesdb;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(db.GetAll().Data);
        }
        [Route("/Product/Insert")]
        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            return View();
        }
        [Route("/Product/Insert")]
        [HttpPost]
        public async Task<IActionResult> Insert(ProductsUpdateDto data, IFormFile Files, IList<IFormFile> MultiFiles)
        {
            var DataKategori = Request.Form["CategoriesId"];
            foreach (var item in DataKategori)
            {
                if (item != "0")
                {
                    data.CategoriesId = Convert.ToInt32(item);
                }
            }
            if (Files != null)
            {
                //024ab727-bfab-411a-8ae3-a3d9f16f2c8a.jpg;
                string NewName = Guid.NewGuid() + Path.GetExtension(Files.FileName);
                string KayitYolu = Path.Combine(URLPath.URLFile, $"wwwroot/images/Products/" + NewName);
                Files.CopyTo(new FileStream(KayitYolu, FileMode.Create));
                data.MainImages = NewName;
                if (db.Add(data).ResultStatus == ResultStatus.Success)
                {
                    // Detay Resmi Ekleme Bölümü. Ürün Eklemesi Başarılı ise Detay Resimlerini Eklemeye Başlasın.
                    int BulunanId = db.SearchId(data.Name, data.Price, data.Stock).Data;
                    //Detay Resmi Ekleme Zorunluluğu Yok.
                    if (MultiFiles != null)
                    {
                        foreach (var item in MultiFiles)
                        {
                            string NewNameDetail = Guid.NewGuid() + Path.GetExtension(item.FileName);
                            string KayitYoluDetail = Path.Combine(URLPath.URLFile, $"wwwroot/images/Products/detail/" + NewNameDetail);
                            item.CopyTo(new FileStream(KayitYoluDetail, FileMode.Create));
                            PImagesDto pImages = new PImagesDto();
                            pImages.ProductsId = BulunanId;
                            pImages.Name = NewNameDetail;
                            imagesdb.Add(pImages);
                        }
                    }
                    ViewData["Message"] = "<div class='alert alert-success'>Bilgiler Eklendi.</div>";
                }
                else
                {
                    ViewData["Message"] = "<div class='alert alert-danger'>Bir Hata ile Karşılaşıldı Lütfen Tekrar Deneyiniz.</div>";
                }
            }
            else
            {
                ViewData["Message"] = "<div class='alert alert-danger'>Ürün Ana Resmi Seçilmedi..</div>";
            }
            return View();
        }

        [Route("/Product/Update/{Id:int}")]
        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            ViewBag.detayResim = imagesdb.GetAll(Id).Data;
            return View(db.GetById(Id).Data);
        }
        [Route("/Product/Update/{Id:int}")]
        [HttpPost]
        public async Task<IActionResult> Update(int Id, ProductsUpdateDto data, IFormFile Files, IList<IFormFile> MultiFiles)
        {
            if (Request.Form["CategoriesId"] != "0")
            {
                var DataKategori = Request.Form["CategoriesId"];
                foreach (var item in DataKategori)
                {
                    if (item != "0")
                    {
                        data.CategoriesId = Convert.ToInt32(item);
                    }
                }
            }
            else
            {
                data.CategoriesId = Convert.ToInt32(Request.Form["KategoriGizli"]);
            }
            // Detay Resmi Kontrol.
            if (MultiFiles != null)
            {
                foreach (var item in MultiFiles)
                {
                    string NewNameDetail = Guid.NewGuid() + Path.GetExtension(item.FileName);
                    string KayitYoluDetail = Path.Combine(URLPath.URLFile, $"wwwroot/images/Products/detail/" + NewNameDetail);
                    item.CopyTo(new FileStream(KayitYoluDetail, FileMode.Create));
                    PImagesDto pImages = new PImagesDto();
                    pImages.ProductsId = Id;
                    pImages.Name = NewNameDetail;
                    imagesdb.Add(pImages);
                }
            }
            // Ana Resim Güncellenmek isteniyorsa
            if (Files != null)
            {
                // Silinecek olan Dosyanın Konumu ve ismini belirtip siliyoruz.
              //System.IO.File.Delete(Path.Combine(URLPath.URLFile, $"wwwroot/images/Products/" + db.GetById(Id).Data.MainImages));

                string NewName = Guid.NewGuid() + Path.GetExtension(Files.FileName);
                string KayitYolu = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/Products/" + NewName);
                Files.CopyTo(new FileStream(KayitYolu, FileMode.Create));
                data.MainImages = NewName;
                if (db.Update(data).ResultStatus == ResultStatus.Success)
                {
                    ViewData["Message"] = "<div class='alert alert-success'>Bilgiler Güncellendi.</div>";
                }
                else
                {
                    ViewData["Message"] = "<div class='alert alert-danger'>Bilgiler Güncellenemedi.</div>";
                }
            }
            else
            {
                // Ana Resim Güncellenmek istenmiyor ise
                if (db.Update(data).ResultStatus == ResultStatus.Success)
                {
                    ViewData["Message"] = "<div class='alert alert-success'>Bilgiler Güncellendi.</div>";
                }
                else
                {
                    ViewData["Message"] = "<div class='alert alert-danger'>Bilgiler Güncellenemedi.</div>";
                }
            }
            ViewBag.detayResim = imagesdb.GetAll(Id).Data;
            return View(db.GetById(Id).Data);
        }


        [Route("/Product/Delete/{Id:int}")]
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var Productdata = db.GetById(Id).Data;
            db.Delete(Id);

            System.IO.File.Delete(Path.Combine(URLPath.URLFile, $"wwwroot/images/Products/" + Productdata.MainImages));

            if (imagesdb.GetAll(Productdata.Id).ResultStatus == ResultStatus.Success)
            {
                foreach (var item in imagesdb.GetAll(Productdata.Id).Data)
                {
                    imagesdb.Delete(item.Id);
                    System.IO.File.Delete(Path.Combine(URLPath.URLFile, $"wwwroot/images/Products/detail/" + item.Name));
                }
            }
            return Redirect("/Product");
        }
        [Route("/Product/ImagesDelete/{Id:int}")]
        public async Task<JsonResult> ImagesDelete(int Id)
        {
            var ImagesData = imagesdb.GetByIdFirst(Id);
            imagesdb.Delete(Id);
            System.IO.File.Delete(Path.Combine(URLPath.URLFile, $"wwwroot/images/Products/detail/" + ImagesData.Name));
            return Json("Resim Silindi.");
        }

    }
}
