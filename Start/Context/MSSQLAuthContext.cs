using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Start.Models;
using Start.Classes;
using Microsoft.AspNetCore.Identity;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Start.Context
{
    public class MSSQLAuthContext : IAuthContext
    {
        private readonly string _connectionString;
        private readonly SignInManager<BaseAccount> signInManager;
        private readonly UserManager<BaseAccount> userManager;

        public MSSQLAuthContext(SignInManager<BaseAccount> signInManager, UserManager<BaseAccount> userManager, IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<bool> Login(LoginViewModel loginViewModel)
        {
            var result = await signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, loginViewModel.Remember, lockoutOnFailure: false);
            return result.Succeeded;
        }
        public async Task<bool> Register(RegisterViewModel account)
        {
            var result = await userManager.CreateAsync(new BaseAccount(account.Username, account.Email), account.Password);
            
            if (result.Succeeded)
            {
                await RegisterDetails(account);
            }
        }

        public async Task<bool> RegisterDetails(RegisterViewModel account)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("UPDATE IB_User SET )", connection);
                    sqlCommand.Parameters.AddWithValue("@username", user.Username);
                    sqlCommand.Parameters.AddWithValue("@email", user.Email);
                    sqlCommand.Parameters.AddWithValue("@password", user.Password);
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
