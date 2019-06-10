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

        public Product Create(Product product)
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

                product.ProductId = (long)sqlCommand.ExecuteScalar();

                connection.Close();
                return product;
            }
        }

        public Product GetById(long productId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM v_Products(@productid)", connection);
                sqlCommand.Parameters.AddWithValue("@productid", productId);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    Product prod = new Product();
                    while (reader.Read())
                    {
                        prod.ProductId = (long)reader["ProductId"];
                        prod.ProductName = reader["ProductName"].ToString();
                        prod.ProductCalories = (int)reader["ProductCalories"];
                        prod.ProductDescription = reader["ProductDescription"].ToString();
                        prod.ProductPrice = (decimal)reader["ProductPrice"];
                        prod.ProductImage = (byte[])reader["ProductImg"]; 
                    }
                    connection.Close();
                    reader.Close();
                    return prod;
                }
                else
                {
                    return default(Product);
                }
            }
        }
    }
}
