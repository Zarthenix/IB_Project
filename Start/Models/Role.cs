using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Models
{
    public class Role
    {
        public string RoleName { get; set; }
        public DateTime CreationDate { get; set; }


        public Role(string rolename)
        {
            this.RoleName = rolename;
        }
    }
}
