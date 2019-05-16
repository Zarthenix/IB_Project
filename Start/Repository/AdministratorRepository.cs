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
        IAuthContext context;

        public AdministratorRepository(IAuthContext context)
        {
            this.context = context;
        }


    }
}
