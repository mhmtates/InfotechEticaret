using Business.Abstract;
using Core.Results.ComplexTypes;
using Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace UIAdmin.Controllers
{
    [Authorize(Roles = "admin")]
    public class CustomerController : Controller
    {
        private readonly ICustomersService db;
        public CustomerController(ICustomersService _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            return View(db.GetAll().Data);
        }
        [Route("/Customer/Insert")]
        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            return View();
        }
        [Route("/Customer/Insert")]
        [HttpPost]
        public async Task<IActionResult> Insert(CustomersUpdateDto data)
        {
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
        [Route("/Customer/Update/{Id:int}")]
        [HttpGet]// Form Load. İlk Açılış Sayfam.
        public async Task<IActionResult> Update(int Id)
        {
            return View(db.GetById(Id).Data);
        }
        [Route("/Customer/Update/{Id:int}")]
        [HttpPost] // Butona Tıkladıktan Sonra Çalışacak.
        public async Task<IActionResult> Update(int Id, CustomersUpdateDto data)
        {
            data.Id = Id;
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
        [Route("/Customer/Delete/{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            db.Delete(Id);
            return RedirectToAction("Index", "Customer");
        }
    }
}
