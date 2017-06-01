using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public class ProductCategorieSQLContext : IProductCategorieContext
    {
        public List<ProductCategorie> GetAllCategories()
        {
            List<ProductCategorie> categories = new List<ProductCategorie>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM PRODUCTCAT ORDER BY id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(CreateProductCategorieFromReader(reader));
                        }
                    }
                }
            }
            return categories;
        }

        public void Insert(ProductCategorie productCategorie)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO PRODUCTCAT (productcat_id, naam)" +
                               "VALUES (@productcatid, @naam)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@productcatid", productCategorie.Id);
                    command.Parameters.AddWithValue("@naam", productCategorie.Naam);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(ProductCategorie productCategorie)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "UPDATE PRODUCTCAT" +
                               " SET productcat_id = @productcatid, naam = @naam" +
                               " WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", productCategorie.Id);
                    command.Parameters.AddWithValue("@productcatid", productCategorie.ProductCatId);
                    command.Parameters.AddWithValue("@naam", productCategorie.Naam);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(ProductCategorie productCategorie)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "DELETE FROM PRODUCTCAT WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", productCategorie.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        private ProductCategorie CreateProductCategorieFromReader(SqlDataReader reader)
        {
            
            if (reader["productcat_id"] != DBNull.Value)
            {
                return new ProductCategorie(
                    (decimal)(reader["id"]),
                    (decimal)(reader["productcat_id"]),
                    (string)(reader["naam"]));
            }
            else
            {
                return new ProductCategorie((decimal)reader["id"], (string)reader["naam"]);
            }
            


        }
    }
}