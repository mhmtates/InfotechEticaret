using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UIAdmin.Controllers
{
    public class DeniedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
