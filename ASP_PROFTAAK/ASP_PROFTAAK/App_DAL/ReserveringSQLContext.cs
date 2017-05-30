using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public class ReserveringSQLContext : IReserveringContext
    {
        private List<Reservering> reserveringen = new List<Reservering>();

        public List<Reservering> GetAllReserveringen()
        {
            List<Reservering> reserveringen = new List<Reservering>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM RESERVERING ORDER BY Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reserveringen.Add(CreateReserveringFromReader(reader));
                        }
                    }
                }
            }
            return reserveringen;
        }



        public Reservering InsertReservering(Reservering reserveringen)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO RESERVERING (DatumStart, DatumEinde, Betaald)" +
                    " VALUES (@datumstart, @datumeinde, @betaald)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@datumstart", reserveringen.DatumStart);
                    command.Parameters.AddWithValue("@datumeinde", reserveringen.DatumEinde);
                    command.Parameters.AddWithValue("@betaald", reserveringen.Betaald);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                }
                return reserveringen;
            }
        }

        

        public void UpdateReservering(Reservering reserveringen)
        {
            string query = "UPDATE RESERVERING SET DatumStart = @datumstart, DatumEinde = @datumeinde, Betaald = @betaald WHERE Id = @id";
            using (SqlConnection connection = Database.Connection)
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", reserveringen.Id);
                command.Parameters.AddWithValue("@datumstart", reserveringen.DatumStart);
                command.Parameters.AddWithValue("@datumeinde", reserveringen.DatumEinde);
                command.Parameters.AddWithValue("@betaald", reserveringen.Betaald);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteReservering(Reservering reserveringen)
        {
            string query = "DELETE FROM RESERVERING WHERE Id = @id";
            using (SqlConnection connection = Database.Connection)
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", reserveringen.Id);
                command.ExecuteNonQuery();
            }
        }

        private Reservering CreateReserveringFromReader(SqlDataReader reader)
        {
            return new Reservering(
                Convert.ToInt32(reader["ID"]),
                Convert.ToDateTime(reader["DatumStart"]),
                Convert.ToDateTime(reader["DatumEinde"]),
                Convert.ToBoolean(reader["Betaald"]));
        }
    }
}