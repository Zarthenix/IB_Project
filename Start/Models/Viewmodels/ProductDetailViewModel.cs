using Start.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Models.Viewmodels
{
    public class ProductDetailViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Calories { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public List<string> Categories { get; set; }

        public ProductDetailViewModel(Product prod)
        {
            Name = prod.ProductName;
            Price = prod.ProductPrice;
            Calories = prod.ProductCalories;
            Description = prod.ProductDescription;
            Image = prod.ProductImage;
            Categories = prod.ProductCategories;
        }
    }
}
