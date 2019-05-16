using System;
using System.Collections.Generic;
using System.Linq;
using Start.Context;
using System.Threading.Tasks;
using Start.Models;

namespace Start.Repository
{
    public class AuthRepository : IAuthContext
    { 
      private readonly IAuthContext context;

        public AuthRepository(IAuthContext context)
        {
            this.context = context;
        }


        public void Register(BaseAccount account)
        {
            context.Register(account);
        }

        public Task<bool> Login(LoginViewModel loginViewModel)
        {
            return context.Login(loginViewModel);
        }
    }
}
