using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Start.Models;
using Start.Classes;
using Microsoft.AspNetCore.Identity;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

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
        public async Task<bool> Register(RegisterViewModel account, string role)
        {
            BaseAccount ba = account.ConvertToBaseAccount();
            var result = await userManager.CreateAsync(ba, ba.Password);
            
            if (result.Succeeded)
            {
                if (role == "Customer")
                {
                    using (var connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        SqlCommand sqlCommand = new SqlCommand("dbo.UpdateCustomerData", connection);
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@address", account.Address);
                        sqlCommand.Parameters.AddWithValue("@zipcode", account.Zipcode);
                        sqlCommand.Parameters.AddWithValue("@town", account.Town);
                        sqlCommand.Parameters.AddWithValue("@firstname", account.FirstName);
                        sqlCommand.Parameters.AddWithValue("@lastname", account.LastName);
                        sqlCommand.Parameters.AddWithValue("@username", account.Username);
                        int retAffectedRows = sqlCommand.ExecuteNonQuery();
                        if (retAffectedRows == -1)
                        {
                            return false;
                        }
                        connection.Close();
                        return true;
                    }
                }
                else return true;
            }
            else return false;
        }
    }
}
