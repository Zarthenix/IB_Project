using Start.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Start.Models;

namespace Start.Repository
{
    public class AdministratorRepository
    {
        IContext context;

        public AdministratorRepository(IContext context)
        {
            this.context = context;
        }


    }
}
