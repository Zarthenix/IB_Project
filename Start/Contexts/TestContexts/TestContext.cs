using System;
using System.Collections.Generic;
using System.Linq;
using Start.Models;
using System.Threading.Tasks;
using Start.Classes;

namespace Start.Context
{
    public class TestContext : IAuthContext
    {
        private List<BaseAccount> accounts = new List<BaseAccount>();

        public async Task<bool> Login(LoginViewModel loginViewModel)
        {
            return false;
        }

        public async Task<bool> Register(RegisterViewModel account, string Role)
        {
            return false;
        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
