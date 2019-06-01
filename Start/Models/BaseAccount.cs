using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Models
{
    public class BaseAccount
    {
        public string Password { get; set; }
        public Role Role { get; set; }
        public DateTime CreationDateTime { get; private set; }
        public long UserId { get; set; }
        public string NormalizedUsername { get; set; }
        public string NormalizedEmail { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }


        public BaseAccount(long id, string username, string email, string password)
        {
            this.UserId = id;
            this.Username = username;
            this.Email = email;
            this.Password = password;
        }

        public BaseAccount(long id, string username, string email)
        {
            this.UserId = id;
            this.Username = username;
            this.Email = email;
        }

        public BaseAccount(string username, string email)
        {
        }

        public BaseAccount()
        {
        }
    }
}
