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
        public byte[] ProductImg { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public List<ProductCategory> ProductCategories { get; set; }

    }
}
