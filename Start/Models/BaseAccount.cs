using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Models
{
    public abstract class BaseAccount
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String Role { get; set; }

        public DateTime AccountCreation { get; private set; }
        public int UserId { get; private set; }
    }
}
