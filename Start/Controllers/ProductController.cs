using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Start.Classes;
using Start.Models;
using Start.Models.Viewmodels;
using Start.Repository;

namespace Start.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository productRepository;

        public ProductController(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        
        [Authorize(Roles = "Employee, Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateProductViewModel {IsActive = true});
        }

        [Authorize(Roles = "Employee, Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel pvm)
        {
            IActionResult retval = View(pvm);

            if (ModelState.IsValid)
            {
                Product product = pvm.ConvertToProduct();

                using (var memoryStream = new MemoryStream())
                {
                    await pvm.Image.CopyToAsync(memoryStream);
                    product.ProductImage = memoryStream.ToArray();
                }

                product = productRepository.Create(product);

                if (product.ProductId == -1)
                {
                    retval = RedirectToAction("Login", "Home");
                }
                else
                {
                    retval = RedirectToAction("Details", "Product", product);
                }
            }
            return retval;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Details(Product product)
        {


            return View();
        }
    }
}