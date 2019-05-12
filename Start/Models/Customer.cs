using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Models
{
    public class Customer : BaseAccount
    {
        public String FullName { get; set; }
        public String Address { get; set; }
        public String ZipCode { get; set; }
        public String Email { get; set; }



    }
}
