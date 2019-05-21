using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Start.Models;

namespace Start.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel pvm)
        {
            return View();
        }
    }
}