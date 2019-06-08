using Start.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Contexts.Interfaces
{
    public interface IProductContext
    {
        long Create(Product product);
    }
}
