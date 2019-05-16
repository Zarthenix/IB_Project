using System;
using Start.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Start.Classes;

namespace Start.Context
{
    public interface IAuthContext
    {
        void Register(BaseAccount account);
        Task<bool> Login(LoginViewModel loginViewModel);
    }
}
