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


        public ProductExemplaar GetByProductExemplaarID(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "select pe.ID, pe.product_id, pe.volgnummer, pe.barcode, pe.verhuurd, p.merk, p.serie, p.typenummer, p.prijs, pc.naam, pcc.naam as subnaam from productexemplaar pe inner join product p on pe.product_id = p.ID left join PRODUCTCAT pc on p.productcat_id = pc.ID left join PRODUCTCAT pcc on pc.productcat_id = pcc.ID where pe.verhuurd = 0 and pe.id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return CreateProductExemplaarVoorVerhuurFromReader(reader);
                        }
                    }
                }
            }
            return null;
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
                               " SET verhuurd = 'true'" +
                               " WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", productExemplaar.Id);
                    

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

        public List<ProductExemplaar> GetAllBeschikbareProductExemplaren()
        {
            List<ProductExemplaar> products = new List<ProductExemplaar>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "select pe.ID, pe.product_id, pe.volgnummer, pe.barcode, pe.verhuurd, p.merk, p.serie, p.typenummer, p.prijs, pc.naam, pcc.naam as subnaam from productexemplaar pe inner join product p on pe.product_id = p.ID left join PRODUCTCAT pc on p.productcat_id = pc.ID left join PRODUCTCAT pcc on pc.productcat_id = pcc.ID where pe.verhuurd = 0";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(CreateProductExemplaarVoorVerhuurFromReader(reader));
                        }
                    }
                }
            }
            return products;
        }
        private ProductExemplaar CreateProductExemplaarFromReader(SqlDataReader reader)
        {
            return new ProductExemplaar(
                Convert.ToInt32(reader["ID"]),
                Convert.ToInt32(reader["product_id"]),
                Convert.ToInt32(reader["volgnummer"]),
                Convert.ToString(reader["barcode"]),
                Convert.ToString("verhuurd"));
        }

        private ProductExemplaar CreateProductExemplaarVoorVerhuurFromReader(SqlDataReader reader)
        {
            return new ProductExemplaar(
                Convert.ToInt32(reader["ID"]),
                Convert.ToInt32(reader["product_id"]),
                Convert.ToInt32(reader["volgnummer"]),
                Convert.ToString(reader["barcode"]),
                Convert.ToString(reader["verhuurd"]),
                Convert.ToString(reader["merk"] != DBNull.Value ? Convert.ToString(reader["merk"]) : ""),
                Convert.ToString(reader["serie"] != DBNull.Value ? Convert.ToString(reader["serie"]) : ""),
                Convert.ToString(reader["typenummer"] != DBNull.Value ? Convert.ToString(reader["typenummer"]) : ""),
                Convert.ToDecimal(reader["prijs"] != DBNull.Value ? Convert.ToDecimal(reader["prijs"]) : 0),
                Convert.ToString(reader["naam"] != DBNull.Value ? Convert.ToString(reader["naam"]) : ""),
                Convert.ToString(reader["subnaam"] != DBNull.Value ? Convert.ToString(reader["subnaam"]) : ""));
        }
        //private ProductExemplaar CreateProductExemplaarFromReader(SqlDataReader reader)
        //{
        //    return new ProductExemplaar((decimal)(reader["id"]),
        //        (decimal)(reader["product_id"]),
        //        (decimal)(reader["volgnummer"]),
        //        (string)(reader["barcode"]),
        //        (bool)(reader["verhuurd"]));
        //}
    }
}