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

        public Task<bool> Login(LoginViewModel loginViewModel)
        {
            return null;
        }

        public void Register(BaseAccount account)
        {

        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
