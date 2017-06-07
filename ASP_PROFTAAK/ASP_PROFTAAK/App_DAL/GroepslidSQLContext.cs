using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public class GroepslidSQLContext: IGroepslidContext
    {
        public List<Groepslid> getGroepsledenByReserveringId(int id)
        {
            List<Groepslid>groepsleden = new List<Groepslid>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "select * from RESERVERING_POLSBANDJE where reservering_id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            groepsleden.Add(createGroepslidFromReader(reader));

                        }
                    }
                }
            }
            return groepsleden;
        }

        public void GeefGroepslidBandjeEnKoppelAanLaatstGeinserteReservering(int accountId)//checken of niet aanwezig goed is en of er genoeg bandjes zijn
        {
            using (SqlConnection connection = Database.Connection)
            {

                using (SqlCommand command = new SqlCommand("Polsbandjetoewijzen", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@accountId", accountId);
                    command.Parameters.AddWithValue("@aanwezig", 0);
                    command.ExecuteNonQuery();
                }
            }
        }


        private Groepslid createGroepslidFromReader(SqlDataReader reader)
        {
            return new Groepslid(
                Convert.ToInt32(reader["ID"]),
                Convert.ToInt32(reader["reservering_id"]),
                Convert.ToInt32(reader["polsbandje_id"]),
                Convert.ToInt32(reader["account_id"]),
                Convert.ToBoolean(reader["aanwezig"]));
        }
    }
}