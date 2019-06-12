using Start.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Contexts.Interfaces
{
    public interface IProductContext
    {
        Product Create(Product product);
        Product GetById(long productId);
        List<Product> GetAll();
    }
}
