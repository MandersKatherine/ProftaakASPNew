using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public class SpecificatieSQLContext : ISpecificatieContext
    {
        public List<Specificatie> GetAll()
        {
            List<Specificatie> Specs = new List<Specificatie>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM SPECIFICATIE ORDER BY ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Specs.Add(CreateSpecificatieFromReader(reader));
                        }
                    }
                }
            }
            return Specs;
        }

        private Specificatie CreateSpecificatieFromReader(SqlDataReader reader)
        {
            return new Specificatie(
                Convert.ToInt32(reader["ID"]),
                Convert.ToString(reader["Naam"])
                );
        }

        public void InsertSpecificatie(Specificatie specificatie)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO SPECIFICATIE (Naam)" +
                               "VALUES (@num)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@num", specificatie.Naam);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }

                }

            }
        }

        public bool DeleteSpecificatie(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "DELETE FROM SPECIFICATIE WHERE ID=@id";
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

        public bool UpdateSpecificatie(Specificatie specificatie)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "UPDATE SPECIFICATIE SET naam = @num WHERE ID = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@num", specificatie.Naam);
                    command.Parameters.AddWithValue("@id", specificatie.ID);
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