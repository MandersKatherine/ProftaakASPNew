using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public class PlekSQLContext : IPlekContext
    {
        public bool DeletePlek(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "DELETE FROM PLEK WHERE ID=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    if (Convert.ToInt32(command.ExecuteNonQuery()) == 1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public List<Plek> GetAll()
        {
            List<Plek> Plekken = new List<Plek>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM PLEK ORDER BY ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Plekken.Add(CreatePlekFromReader(reader));
                        }
                    }
                }
            }
            return Plekken;
        }
        public List<Decimal> GetPlekId(decimal id)
        {
            List<Decimal> Plekken = new List<Decimal>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT plek_id FROM RESERVERING INNER JOIN PLEK_RESERVERING ON RESERVERING.ID = PLEK_RESERVERING.reservering_id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Plekken.Add(reader.GetDecimal(0));
                        }
                    }
                }
            }
            return Plekken;
        }
        public List<Plek> GetPlekById(List<decimal> id)
        {
            List<Plek> Plekken = new List<Plek>();

            foreach (decimal newId in id)
            {

                using (SqlConnection connection = Database.Connection)
                {
                    string query = "SELECT * FROM PLEK WHERE ID = @id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("id", newId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                Plekken.Add(CreatePlekFromReader(reader));

                            }

                        }
                    }
                }
            }
            return Plekken;
        }

        public Plek GetPlekById(int id)
        {

            using (SqlConnection connection = Database.Connection)
            {
                string query = "select * from plek where id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.Read())
                        {

                            return CreatePlekFromReader(reader);

                        }

                    }
                }
            }
            return null;

        }

        public List<Plek> GetPlekByEventId(int eventId)
        {
            List<Plek> Plekken = new List<Plek>();

            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT Plek.* FROM Plek INNER JOIN LOCATIE ON Plek.locatie_id = LOCATIE.ID INNER JOIN EVENT ON LOCATIE.ID = EVENT.locatie_id WHERE EVENT.ID = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", eventId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Plekken.Add(CreatePlekFromReader(reader));

                        }

                    }
                }
            }

            return Plekken;
        }

        public List<Plek> GetPlekByLocatieId(int locatieId)
        {
            List<Plek> Plekken = new List<Plek>();

            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM Plek where locatie_id = @locatie_id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@locatie_id", locatieId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Plekken.Add(CreatePlekFromReader(reader));

                        }

                    }
                }
            }

            return Plekken;
        }


        private Plek CreatePlekFromReader(SqlDataReader reader)
        {
            return new Plek(
                 Convert.ToInt32(reader["ID"]),
                 Convert.ToInt32(reader["locatie_id"]),
                 Convert.ToString(reader["Nummer"]),
                 Convert.ToInt32(reader["Capaciteit"]));
        }

        public Plek InsertPlek(Plek plek)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO PLEK (locatie_id, nummer, capaciteit)" +
                        "VALUES (@locid, @num, @cap)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@locid", plek.LocatieId);
                    command.Parameters.AddWithValue("@num", plek.ID);
                    command.Parameters.AddWithValue("@cap", plek.Capaciteit);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                    return plek;

                }

            }
        }

        public bool UpdatePlek(Plek plek)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "UPDATE PLEK SET nummer = @num, capaciteit = @cap WHERE Id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@num", plek.Nummer);
                    command.Parameters.AddWithValue("@cap", plek.Capaciteit);
                    command.Parameters.AddWithValue("@id", plek.ID);
                    command.ExecuteNonQuery();
                    try
                    {
                        if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
                        {
                            return true;
                        }
                    }
                    catch (SqlException e)
                    {

                    }

                }
            }

            return false;
        }
    }
}