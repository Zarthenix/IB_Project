using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Models
{
    public class Customer : BaseAccount
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Town { get; set; }




    }
}
