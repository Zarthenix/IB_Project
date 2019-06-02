using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Start.Models
{
    public class ProductViewModel
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
        [DataType(DataType.ImageUrl)]
        public string ProductImg { get; set; }

    }
}
