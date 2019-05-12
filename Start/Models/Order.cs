using Start.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Classes
{
    public class Order
    {        
        public int OrderId { get; set; }
        public Customer User { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
