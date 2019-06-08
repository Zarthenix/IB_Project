using Microsoft.Extensions.Configuration;
using Start.Classes;
using Start.Contexts.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Contexts.SQLContexts
{
    public class MSSQLProductContext : IProductContext
    {
        private readonly string _connectionString;

        public MSSQLProductContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public long Create(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand("dbo.CreateProduct", connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@name", product.ProductName);
                sqlCommand.Parameters.AddWithValue("@description", product.ProductDescription);
                sqlCommand.Parameters.AddWithValue("@price", product.ProductPrice);
                sqlCommand.Parameters.AddWithValue("@calories", product.ProductCalories);
                sqlCommand.Parameters.Add("@img", SqlDbType.VarBinary).Value = product.ProductImage;
                sqlCommand.Parameters.AddWithValue("@active", Convert.ToByte(product.IsAvailable));
                return (long)sqlCommand.ExecuteScalar();
            }
        }
    }
}
