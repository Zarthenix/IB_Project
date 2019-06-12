using Microsoft.AspNetCore.Http;
using Start.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Models.Viewmodels
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [DataType(DataType.Text)]
        [Display(Name = "Product name")]
        [StringLength(255, ErrorMessage = "Please do not exceed 255 characters for the name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Product price")]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        [Display(Name = "Product description")]
        public string Description { get; set; }
        [Range(1, 10000)]
        [Display(Name = "Product calories")]
        public int Calories { get; set; }
        [Display(Name = "Product available")]
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Please upload an image")]
        [Display(Name = "Product image")]
        public IFormFile Image { get; set; }
        public List<string> Categories { get; set; }


        public Product ConvertToProduct()
        {
            Product prod = new Product()
            {
                ProductName = Name,
                ProductCalories = Calories,
                ProductCategories = Categories,
                ProductDescription = Description,
                ProductPrice = Price,
                IsAvailable = IsActive
            };

            return prod;
        }
    }
}
