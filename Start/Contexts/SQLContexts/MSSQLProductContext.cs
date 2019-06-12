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

                using (SqlCommand sqlCommand = new SqlCommand("CreateProduct", connection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@name", product.ProductName);
                    sqlCommand.Parameters.AddWithValue("@description", product.ProductDescription);
                    sqlCommand.Parameters.AddWithValue("@price", product.ProductPrice);
                    sqlCommand.Parameters.AddWithValue("@calories", product.ProductCalories);
                    sqlCommand.Parameters.Add("@img", SqlDbType.VarBinary).Value = product.ProductImage;
                    sqlCommand.Parameters.AddWithValue("@active", Convert.ToByte(product.IsAvailable));

                    product.ProductId = (long)sqlCommand.ExecuteScalar();
                }                   
                return product;
            }
        }

        public Product GetById(long id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM v_Products(@productid)", connection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@productid", id);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {


                        if (reader.HasRows)
                        {
                            Product prod = new Product(id);
                            while (reader.Read())
                            {
                                prod.ProductName = reader["ProductName"].ToString();
                                if (!reader.IsDBNull(reader.GetOrdinal("ProductCalories")))
                                {
                                    prod.ProductCalories = (int)reader["ProductCalories"];
                                }
                                else { prod.ProductCalories = 0; }
                                prod.ProductDescription = reader["ProductDescription"].ToString();
                                prod.ProductPrice = (decimal)reader["ProductPrice"];
                                prod.ProductImage = (byte[])reader["ProductImg"];
                            }
                            return prod;
                        }
                        else
                        {
                            return new Product(-1);
                        }
                    }
                }
            }
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            DataSet sqlDataSet = new DataSet();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [Active Products]", connection))
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                {
                    sqlDataAdapter.SelectCommand = sqlCommand;
                    sqlDataAdapter.Fill(sqlDataSet);
                }
            }

            foreach (DataRow dr in sqlDataSet.Tables[0].Rows)
            {
                if (products.Where(p => p.ProductId == (long)dr["ProductId"]).ToList().Count == 0)
                {
                    Product product = new Product()
                    {
                        ProductId = (long)dr["ProductId"],
                        ProductName = dr["ProductName"].ToString(),
                        ProductDescription = dr["ProductDescription"].ToString(),
                        ProductPrice = (decimal)dr["ProductPrice"],
                        ProductImage = (byte[])dr["ProductImg"],
                        ProductCategories = new List<string>()
                    };
                    product.ProductCategories.Add(dr["ProductCategoryName"].ToString());
                    if (!dr.IsNull("ProductCalories"))
                    {
                        product.ProductCalories = (int)dr["ProductCalories"];
                    }
                    else { product.ProductCalories = 0; }

                    products.Add(product);
                }        
                else
                {
                    products.FirstOrDefault(id => id.ProductId == (long)dr["ProductId"]).ProductCategories.Add(dr["ProductCategoryName"].ToString());
                }
            }
            return products;
        }
    }
}
