using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Models
{
    public class BaseAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public DateTime AccountCreation { get; private set; }
        public int UserId { get; set; }

        public string NormalizedUsername { get; set; }
        public string NormalizedEmail { get; set; }

        public BaseAccount(long id, string username, string email, string password)
        {

        }

        public BaseAccount(long id, string username, string email)
        {

        }
    }
}
