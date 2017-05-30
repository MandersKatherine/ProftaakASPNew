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

        private Plek CreatePlekFromReader(SqlDataReader reader)
        {
            return new Plek(
                 Convert.ToInt32(reader["ID"]),
                 Convert.ToString(reader["Nummer"]),
                 Convert.ToInt32(reader["Capaciteit"]));
        }

        public Plek InsertPlek(Plek plek)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO PLEK (nummer, capaciteit)" +
                        "VALUES (@num, @cap)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@num", plek.Nummer);
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