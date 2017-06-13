using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public class VerhuurSqlContext : IVerhuurContext
    {
        public List<Verhuurd> GetAllVerhuurdByAccountId(int accountId)
        {
            List<Verhuurd> verhuurden = new List<Verhuurd>();
            using (SqlConnection connection = Database.Connection)
            {
                string query =
                    "select pe.ID, pe.product_id, v.res_pb_id, v.datumIn, v.datumUit, v.prijs as totaalprijs, v.betaald,p.merk, p.serie, p.typenummer, " +
                    "p.prijs, pc.naam, pcc.naam as subnaam " +
                    "from RESERVERING_POLSBANDJE rp " +
                    "inner join verhuur v on rp.ID = v.res_pb_id " +
                    "inner join PRODUCTEXEMPLAAR pe on v.productexemplaar_id = pe.ID " +
                    "inner join product p on pe.product_id = p.ID " +
                    "left join PRODUCTCAT pc on p.productcat_id = pc.ID " +
                    "left join PRODUCTCAT pcc on pc.productcat_id = pcc.ID where account_id = @accountId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@accountId", accountId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            verhuurden.Add(CreateVerhuurdFromReader(reader));
                        }
                    }
                }
            }
            return verhuurden;

        }


        public void Insert(Verhuurd verhuurd)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO verhuur (productexemplaar_id, res_pb_id, datumIn, datumUit, Prijs, Betaald)" +
                               "VALUES (@productexemplaar_id, @res_pb_id, @datumIn, @datumUit, @Prijs, @Betaald)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@productexemplaar_id", verhuurd.ProductExemplaarId);
                    command.Parameters.AddWithValue("@res_pb_id", verhuurd.GroepsLidId);
                    command.Parameters.AddWithValue("@datumIn", verhuurd.DatumIn);
                    command.Parameters.AddWithValue("@datumUit", verhuurd.DatumUit);
                    command.Parameters.AddWithValue("@prijs", verhuurd.Prijs);
                    command.Parameters.AddWithValue("@betaald", verhuurd.Betaald);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Verhuurd verhuurd)
        {
            string query = "UPDATE Verhuurd" +
                           " SET productexemplaar_id = @productexemplaar_id, res_pb_id = @res_pb_id, datumIn = @datumIn, datumUit = @datumUit, Prijs = @Prijs, Betaald = @betaald" +
                           " WHERE id = @id";
            using (SqlCommand command = new SqlCommand(query, Database.Connection))
            {
                command.Parameters.AddWithValue("@id", verhuurd.Id);
                command.Parameters.AddWithValue("@productexemplaar_id", verhuurd.ProductExemplaarId);
                command.Parameters.AddWithValue("@res_pb_id", verhuurd.GroepsLidId);
                command.Parameters.AddWithValue("@datumIn", verhuurd.DatumIn);
                command.Parameters.AddWithValue("@datumUit", verhuurd.DatumUit);
                command.Parameters.AddWithValue("@prijs", verhuurd.Prijs);
                command.Parameters.AddWithValue("@betaald", verhuurd.Betaald);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(Verhuurd verhuurd)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "DELETE FROM Verhuurd WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", verhuurd.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        private Verhuurd CreateProductFromReader(SqlDataReader reader)
        {
            return new Verhuurd(
               (decimal)(reader["id"]),
                (decimal)(reader["productexemplaar_id"]),
              (decimal)(reader["res_pb_id"]),
                (DateTime)(reader["datumIn"]),
               (DateTime)(reader["DatumUit"]),
               (decimal)(reader["prijs"]),
               (decimal)(reader["betaald"]));
        }

        private Verhuurd CreateVerhuurdFromReader(SqlDataReader reader)
        {
            return new Verhuurd(
                (decimal) (reader["id"]),
                (decimal) (reader["product_id"]),
                (decimal) (reader["res_pb_id"]),
                (DateTime) (reader["datumIn"]),
                (DateTime) (reader["DatumUit"]),
                (decimal) (reader["totaalprijs"]),
                Convert.ToInt32(reader["betaald"]),
                Convert.ToString(reader["merk"] != DBNull.Value ? Convert.ToString(reader["merk"]) : ""),
                Convert.ToString(reader["serie"] != DBNull.Value ? Convert.ToString(reader["serie"]) : ""),
                Convert.ToString(reader["typenummer"] != DBNull.Value ? Convert.ToString(reader["typenummer"]) : ""),
                Convert.ToDecimal(reader["prijs"] != DBNull.Value ? Convert.ToDecimal(reader["prijs"]) : 0),
                Convert.ToString(reader["naam"] != DBNull.Value ? Convert.ToString(reader["naam"]) : ""),
                Convert.ToString(reader["subnaam"] != DBNull.Value ? Convert.ToString(reader["subnaam"]) : ""));
        }
    }
}