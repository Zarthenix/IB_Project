using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Start.Models;

namespace Start.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            List<CartProduct> products = HttpContext.Session.GetComplexData<List<CartProduct>>("userCart");
            return PartialView(products);
        }

        [HttpPost]
        public IActionResult Add()
        {
            StreamReader sr = new StreamReader(Request.Body);
            string data = sr.ReadToEnd();
           
            CatalogProductViewModel cpvm = Newtonsoft.Json.JsonConvert.DeserializeObject<CatalogProductViewModel>(data);
          
            List<CartProduct> products = HttpContext.Session.GetComplexData<List<CartProduct>>("userCart");

            if (products == null)
            {
                products = new List<CartProduct>();
            }

            if (products.Where(x => x.Id == cpvm.ProductId).ToList().Count == 0)
            {

                CartProduct cp = new CartProduct
                {
                    Id = cpvm.ProductId,
                    Name = cpvm.ProductName,
                    Price = cpvm.ProductPrice,
                    Img = cpvm.ProductImg,
                    Quantity = 1
                };

                products.Add(cp);
            }
            else
            {
                products.FirstOrDefault(x => x.Id == cpvm.ProductId).Quantity += 1;
            }

            HttpContext.Session.SetComplexData("userCart", products);

            return Content(products.Sum(x => x.Quantity).ToString());
        }
    }
}