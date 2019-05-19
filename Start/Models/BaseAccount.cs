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
        public DateTime CreationDateTime { get; set; }
        public long UserId { get; set; }
        public string NormalizedUsername { get; set; }
        public string NormalizedEmail { get; set; }

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                NormalizedUsername = value.ToUpper();
                _username = value;
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                NormalizedEmail = value.ToUpper();
                _email = value;
            }
        }


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

        public BaseAccount()
        {

        }
    }
}
