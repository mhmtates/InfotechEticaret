using Business.Abstract;
using Core.Results.ComplexTypes;
using Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace UIAdmin.Controllers
{
    [Authorize(Roles = "admin")]
    public class KategoriController : Controller
    {
        private readonly ICategoriesService db;
        public KategoriController(ICategoriesService _db)
        {
            db = _db;
        }
        [Route("/Kategori/{Id:int?}")]
        public async Task<IActionResult> Index(int? Id)
        {
            if (Id == null)
            {
                return View(db.GetAll(0).Data);
            }
            else
            {
                TempData["Kategori"] = db.GetById(Convert.ToInt32(Id)).Data.Name;
                return View(db.GetAll(Convert.ToInt32(Id)).Data);
            }
        }
        [Route("/Kategori/Insert/{id:int?}")]
        [HttpGet]
        public async Task<IActionResult> Insert(int id)
        {
            return View();
        }
        [Route("/Kategori/Insert/{id:int?}")]
        [HttpPost]
        public async Task<IActionResult> Insert(int id,CategoriesDto data)
        {
            if (id != null)
            {
                data.ParentId = id;
                data.Id = 0;
            }
            else
            {
                data.ParentId = 0;
            }
            var DataMessage = db.Add(data);
            if (DataMessage.ResultStatus == ResultStatus.Success)
            {
                ViewData["Message"] = "<div class='alert alert-success'>" + DataMessage.Message + "</div>";
            }
            else
            {
                ViewData["Message"] = "<div class='alert alert-danger'>" + DataMessage.Message + "</div>";
            }
            return View();
        }

        [Route("/Kategori/Update/{Id:int}")]
        [HttpGet]// Form Load. İlk Açılış Sayfam.
        public async Task<IActionResult> Update(int Id)
        {
            return View(db.GetById(Id).Data);
        }
        [Route("/Kategori/Update/{Id:int}")]
        [HttpPost] // Butona Tıkladıktan Sonra Çalışacak.
        public async Task<IActionResult> Update(int Id, CategoriesDto data)
        {
            var DataMessage = db.Update(data);
            if (DataMessage.ResultStatus == ResultStatus.Success)
            {
                ViewData["Message"] = "<div class='alert alert-success'>" + DataMessage.Message + "</div>";
            }
            else
            {
                ViewData["Message"] = "<div class='alert alert-danger'>" + DataMessage.Message + "</div>";
            }
            return View(db.GetById(Id).Data);// Sayfa Post Edildiğinde Güncel olan Veriyi Getiriyoruz.
        }
        [Route("/Kategori/Delete/{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            db.Delete(Id);
            return RedirectToAction("Index", "Kategori");
        }
    }
}
