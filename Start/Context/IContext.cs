using System;
using Start.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Start.Classes;

namespace Start.Context
{
    public interface IContext
    {
        void Register(BaseAccount account);
        BaseAccount Login(string username, string password);
        List<Product> GetProducts();

    }
}
