using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public class ProductExemplaarSQLContext : IProductExemplaarContext
    {
        
        public List<ProductExemplaar> GetAllProductExemplaar()
        {
           List<ProductExemplaar> productExemplaren = new List<ProductExemplaar>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM ProductExemplaar ORDER BY id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productExemplaren.Add(CreateProductExemplaarFromReader(reader));
                        }
                    }
                }
            }
            return productExemplaren;
        }

        public void Insert(ProductExemplaar productExemplaar, Product product)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO ProductExemplaar (product_id, volgnummer, barcode)" +
                               "VALUES (@productid, @volgnummer, @barcode)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@productid", product.ProductId);
                    command.Parameters.AddWithValue("@volgnummer", productExemplaar.Volgnummer);
                    command.Parameters.AddWithValue("@barcode", productExemplaar.Barcode);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(ProductExemplaar productExemplaar)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "UPDATE ProductExemplaar" +
                               " SET volgnummer = @volgnummer, barcode = @barcode" +
                               " WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", productExemplaar.Id);
                    command.Parameters.AddWithValue("@volgnummer", productExemplaar.Volgnummer);
                    command.Parameters.AddWithValue("@barcode", productExemplaar.Barcode);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(ProductExemplaar productExemplaar)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "DELETE FROM ProductExemplaar WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", productExemplaar.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        private ProductExemplaar CreateProductExemplaarFromReader(SqlDataReader reader)
        {
            return new ProductExemplaar((decimal)(reader["id"]),
                (decimal)(reader["product_id"]),
                (decimal)(reader["volgnummer"]),
                (string)(reader["barcode"]),
                (bool)(reader["verhuurd"]));
        }
    }
}