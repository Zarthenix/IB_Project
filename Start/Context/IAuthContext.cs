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
        Task<bool> Register(RegisterViewModel account);
        Task<bool> Login(LoginViewModel loginViewModel);
    }
}
