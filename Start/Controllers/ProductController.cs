using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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

        public IActionResult Create()
        {
            return View(new CreateProductViewModel {IsActive = true});
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel pvm)
        {
            if (ModelState.IsValid)
            {
                Product product = pvm.ConvertToProduct();

                using (var memoryStream = new MemoryStream())
                {
                    await pvm.Image.CopyToAsync(memoryStream);
                    product.ProductImage = memoryStream.ToArray();

                }

                long productId = productRepository.Create(product);

                if (productId == -1)
                {
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    return RedirectToAction("Details", "Product", new { id = productId });
                }
            }

            return View(pvm);
        }
    }
}