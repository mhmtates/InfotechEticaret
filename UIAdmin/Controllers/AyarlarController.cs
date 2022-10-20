using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UIAdmin.Controllers
{
    public class AyarlarController : Controller
    {
        [Authorize(Roles = "admin,temsilci")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "admin,temsilci")]
        [HttpPost]
        public IActionResult Index(string a)
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public IActionResult Insert()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public IActionResult Update()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public IActionResult Delete()
        {
            return View();
        }
    }
}
