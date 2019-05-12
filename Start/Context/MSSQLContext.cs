using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Start.Models;
using Start.Classes;

namespace Start.Context
{
    public class MSSQLContext : IContext
    {
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
