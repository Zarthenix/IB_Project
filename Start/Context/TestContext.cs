using System;
using System.Collections.Generic;
using System.Linq;
using Start.Models;
using System.Threading.Tasks;
using Start.Classes;

namespace Start.Context
{
    public class TestContext : IContext
    {
        private List<BaseAccount> accounts = new List<BaseAccount>();

        public BaseAccount Login(string username, string password)
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
