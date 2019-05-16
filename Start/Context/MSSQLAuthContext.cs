using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Start.Models;
using Start.Classes;
using Microsoft.AspNetCore.Identity;

namespace Start.Context
{
    public class MSSQLAuthContext : IAuthContext
    {
        private readonly SignInManager<BaseAccount> signInManager;
        private readonly UserManager<BaseAccount> userManager;

        public MSSQLAuthContext(SignInManager<BaseAccount> signInManager, UserManager<BaseAccount> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<bool> Login(LoginViewModel loginViewModel)
        {
           var result = await signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, loginViewModel.Remember, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Register(BaseAccount account)
        {

        }
    }
}
