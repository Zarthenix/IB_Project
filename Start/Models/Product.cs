using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Classes
{
    public class Product
    {
        public long ProductId { get; set; }
        public String ProductName { get; set; }
        public String ProductDescription { get; set; }
        public int ProductCalories { get; set; }
        public decimal ProductPrice { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public bool IsAvailable { get; set; }
        public byte[] ProductImage { get; set; }
    }
}
