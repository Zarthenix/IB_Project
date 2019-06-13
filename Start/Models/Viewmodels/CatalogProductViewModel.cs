using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Start.Classes;

namespace Start.Models
{
    public class CatalogProductViewModel
    {
        public long ProductId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(255)]
        public string ProductName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(8000)]
        public string ProductDescription { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal ProductPrice { get; set; }
        public int ProductCalories { get; set; }
        [Required]
        public string ProductImg { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public List<string> ProductCategories { get; set; }


        public CatalogProductViewModel ConvertToViewModel(Product p)
        {
            ProductId = p.ProductId;
            ProductName = p.ProductName;
            ProductDescription = p.ProductDescription;
            ProductPrice = p.ProductPrice;
            ProductCalories = p.ProductCalories;
            ProductCategories = p.ProductCategories;
            ProductImg = Convert.ToBase64String(p.ProductImage);
            return this;
        }
    }
}
