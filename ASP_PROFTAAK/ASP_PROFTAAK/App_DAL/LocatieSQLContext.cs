using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ASP_PROFTAAK.Models;
using ASP_PROFTAAK.App_DAL;

namespace ASP_PROFTAAK
{
    public class LocatieSQLContext : ILocatieContext
    {
        public List<Locatie> GetAllLocations()
        {
            List<Locatie> locaties = new List<Locatie>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM Locatie ORDER BY ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            locaties.Add(CreateLocatieFromReader(reader));
                        }
                    }
                }
            }
            return locaties;
        }


        public Locatie InsertLocatie(Locatie locatie)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO Locatie (naam, straat, nummer, postcode, plaats)" +
                        "VALUES (@naam, @straat, @nummer, @postcode, @plaats)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@naam", locatie.Naam);
                    command.Parameters.AddWithValue("@straat", locatie.Straat);
                    command.Parameters.AddWithValue("@nummer", locatie.Nummer);
                    command.Parameters.AddWithValue("@postcode", locatie.Postcode);
                    command.Parameters.AddWithValue("@plaats", locatie.Plaats);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        throw; 
                    }
                    return locatie;

                }

            }
        }

        public bool DeleteLocatie(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "DELETE FROM Locatie WHERE ID=@id";
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

        public bool UpdateLocatie(Locatie locatie)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "UPDATE Locatie SET naam = @naam, straat = @straat, nummer = @nummer, postcode = @postcode, plaats = @plaats WHERE Id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@naam", locatie.Naam);
                    command.Parameters.AddWithValue("@straat", locatie.Straat);
                    command.Parameters.AddWithValue("@nummer", locatie.Nummer);
                    command.Parameters.AddWithValue("@postcode", locatie.Postcode);
                    command.Parameters.AddWithValue("@plaats", locatie.Plaats);
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
                        throw; 
                    }

                }
            }

            return false;
        }




        private Locatie CreateLocatieFromReader(SqlDataReader reader)
        {
            return new Locatie(
                 Convert.ToInt32(reader["ID"]),
                 Convert.ToString(reader["Naam"]),
                 Convert.ToString(reader["Straat"]),
                 Convert.ToString(reader["nummer"]),
                 Convert.ToString(reader["Postcode"]),
                 Convert.ToString(reader["Plaats"]));
        }

    }
}