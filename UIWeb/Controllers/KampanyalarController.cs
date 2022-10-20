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
    public class KampanyalarController : Controller
    {
        private readonly IProductsService service;
        public KampanyalarController(IProductsService _service)
        {
            service = _service;
        }
        public IActionResult Index()
        {
            return View(service.GetAllKampanya());
        }
    }
}
