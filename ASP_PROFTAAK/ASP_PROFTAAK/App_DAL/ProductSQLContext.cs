using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public class ProductSQLContext : IProductContext
    {
        // alle generieke producten
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM Product ORDER BY id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(CreateProductFromReader(reader));
                        }
                    }
                }
            }
            return products;
        }


        public void Insert(Product product, ProductCategorie productCategorie)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO Product (productcat_id, merk, serie, typenummer, prijs)" +
                               "VALUES (@productcatid, @merk, @serie, @typenummer, @prijs)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@productcatid", productCategorie.Id);
                    command.Parameters.AddWithValue("@merk", product.Merk);
                    command.Parameters.AddWithValue("@serie", product.Serie);
                    command.Parameters.AddWithValue("@typenummer", product.Typenummer);
                    command.Parameters.AddWithValue("@prijs", product.Prijs);
                    command.ExecuteNonQuery();
                    
                }
            }
        }

        public void Update(Product product, ProductCategorie productCategorie)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "UPDATE Product" +
                               " SET productcat_id = @productcatid, Merk = @merk, serie = @serie, Typnummer = @typenummer, prijs = @prijs" +
                               " WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", product.ProductId);
                    command.Parameters.AddWithValue("@productcatid", productCategorie.Id);
                    command.Parameters.AddWithValue("@merk", product.Merk);
                    command.Parameters.AddWithValue("@serie", product.Serie);
                    command.Parameters.AddWithValue("@typenummer", product.Typenummer);
                    command.Parameters.AddWithValue("@prijs", product.Prijs);
                    command.ExecuteNonQuery();
                }
            }
        }


        public void Delete(Product product)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "DELETE FROM Product WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", product.ProductId);
                    command.ExecuteNonQuery();
                }
            }
        }

        private Product CreateProductFromReader(SqlDataReader reader)
        {
            return new Product(
                Convert.ToInt32(reader["id"]),
                Convert.ToInt32(reader["productcat_id"]),
                Convert.ToString(reader["merk"]),
                Convert.ToString(reader["serie"]),
                Convert.ToString(reader["typenummer"]),
                Convert.ToDouble(reader["prijs"]));
        }
    }
}