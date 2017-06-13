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
        private Reservering reservering;

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
        public Reservering GetReserveringById(decimal id)
        {
            
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM RESERVERING WHERE Id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            reservering = CreateReserveringFromReader(reader);
                        }
                    }
                }
            }
            return reservering;
        }



        public List<Reservering> GetReserveringByAccountId(decimal accountid)
        {
            List<Reservering>reservering = new List<Reservering>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "select RESERVERING.*, RESERVERING_POLSBANDJE.* " +
                               "from RESERVERING inner join RESERVERING_POLSBANDJE on reservering.ID = RESERVERING_POLSBANDJE.reservering_id " +
                               "where account_id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", accountid);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           reservering.Add(CreateReserveringFromReader(reader));
                        }
                    }
                }
            }
            return reservering;
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

        public void CreateReservering(DateTime datumStart, DateTime datumEinde, int betaald, int accountId, int aanwezig, string plekId, string voornaam, string tussenvoegsel, string achternaam, string straat, string huisnummer, string woonplaats, string banknummer)
        {
            using (SqlConnection connection = Database.Connection)
            {

                using (SqlCommand command = new SqlCommand("ReserveringMaken", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@datumStart", datumStart);
                    command.Parameters.AddWithValue("@datumEinde", datumEinde);
                    command.Parameters.AddWithValue("@betaald", betaald);
                    command.Parameters.AddWithValue("@accountId", accountId);
                    command.Parameters.AddWithValue("@aanwezig", aanwezig);
                    command.Parameters.AddWithValue("@plekId", plekId);
                    command.Parameters.AddWithValue("@voornaam", voornaam);
                    command.Parameters.AddWithValue("@tussenvoegsel", tussenvoegsel);
                    command.Parameters.AddWithValue("@achternaam", achternaam);
                    command.Parameters.AddWithValue("@straat", straat);
                    command.Parameters.AddWithValue("@huisnummer", huisnummer);
                    command.Parameters.AddWithValue("@woonplaats", woonplaats);
                    command.Parameters.AddWithValue("@banknummer", banknummer);
                    command.ExecuteNonQuery();
                }
            }
        }

        

        //@datumStart date,
        //    @datumEinde date,
        //@betaald numeric(1,0),
        //@accountId numeric(10,0),
        //@aanwezig numeric(1,0),
        //@plekId numeric(10,0),
        //@voornaam nvarchar(255),
        //@tussenvoegsel nvarchar(255),
        //@achternaam nvarchar(255),
        //@straat nvarchar(255),
        //@huisnummer nvarchar(255),
        //@woonplaats nvarchar(255),
        //@banknummer nvarchar(255)


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
                Convert.ToDecimal(reader["ID"]),
                Convert.ToDecimal(reader["persoon_id"]),
                Convert.ToDateTime(reader["DatumStart"]),
                Convert.ToDateTime(reader["DatumEinde"]),
                Convert.ToBoolean(reader["Betaald"]));
        }
    }
}