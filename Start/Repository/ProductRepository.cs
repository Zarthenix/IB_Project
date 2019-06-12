using Start.Classes;
using Start.Contexts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Repository
{
    public class ProductRepository : IProductContext
    {
        private readonly IProductContext context;

        public ProductRepository(IProductContext context)
        {
            this.context = context;
        }

        public Product Create(Product product)
        {
            return context.Create(product);
        }

        public Product GetById(long id)
        {
            return context.GetById(id);
        }

        public List<Product> GetAll()
        {
            return context.GetAll();
        }
    }
}
