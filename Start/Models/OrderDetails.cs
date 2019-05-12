using Start.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Classes
{
    public class OrderDetails
    {
        public Order Order { get; set; }
        public List<int> ProductQuantities { get; set; }
        public List<Product> Products { get; set; }
        public Dictionary<Product, int> ProductsTotal { get; set; }
        public decimal Price { get; set; }
    }
}
