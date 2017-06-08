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

        public Locatie GetbyEvent(Event ev)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM LOCATIE WHERE ID = (SELECT locatie_id FROM EVENT WHERE ID = @id)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@id", ev.Id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Locatie loc = CreateLocatieFromReader(reader);
                            return loc;
                        }
                    }
                }

            }
            return null;
        }
        public Locatie GetLocatieById(int id)
        {
            Locatie locatie;
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM LOCATIE WHERE ID = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            locatie = CreateLocatieFromReader(reader);
                            return locatie;
                        }
                    }
                }

            }
            return null;
        }



        public Locatie InsertLocatie(Locatie locatie)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO Locatie (naam, straat, nr, postcode, plaats)" +
                        "VALUES (@naam, @straat, @nummer, @postcode, @plaats)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (Convert.ToString(locatie.Naam) == "")
                    {
                        command.Parameters.AddWithValue("@naam", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@naam", locatie.Naam);
                    }

                    if (Convert.ToString(locatie.Straat) == "")
                    {
                        command.Parameters.AddWithValue("@straat", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@straat", locatie.Straat);
                    }
                    if (Convert.ToString(locatie.Nummer) == "")
                    {
                        command.Parameters.AddWithValue("@nummer", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@nummer", locatie.Nummer);
                    }
                    if (Convert.ToString(locatie.Postcode) == "")
                    {
                        command.Parameters.AddWithValue("@postcode", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@postcode", locatie.Postcode);
                    }
                    if (Convert.ToString(locatie.Plaats) == "")
                    {
                        command.Parameters.AddWithValue("@plaats", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@plaats", locatie.Plaats);
                    }
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
                string query = "UPDATE Locatie SET naam = @naam, straat = @straat, nr = @nummer, postcode = @postcode, plaats = @plaats WHERE Id = @id";
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



        public int GetLocatieId()
        {
            int locatieId;
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT TOP 1 ID FROM Locatie ORDER BY ID DESC";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    locatieId = Convert.ToInt32(command.ExecuteScalar());
                    return locatieId;
                }
            }
        }



        private Locatie CreateLocatieFromReader(SqlDataReader reader)
        {
            return new Locatie(
                Convert.ToInt32(reader["ID"]),
                Convert.ToString(reader["Naam"]),
                Convert.ToString(reader["Straat"] != DBNull.Value ? Convert.ToString(reader["Straat"]) : ""),
                Convert.ToString(reader["nr"] != DBNull.Value ? Convert.ToString(reader["nr"]) : ""),
                Convert.ToString(reader["Postcode"] != DBNull.Value ? Convert.ToString(reader["Postcode"]) : ""),
                Convert.ToString(reader["Plaats"] != DBNull.Value ? Convert.ToString(reader["Plaats"]) : ""));
        }

        //private Locatie CreateLocatieFromReader(SqlDataReader reader)
        //{
        //    if (Convert.ToString(reader["Straat"]) != null && Convert.ToString(reader["nr"]) != null && Convert.ToString(reader["Postcode"]) != null && Convert.ToString(reader["Plaats"]) != null)
        //    {
        //        return new Locatie(
        //         Convert.ToInt32(reader["ID"]),
        //         Convert.ToString(reader["Naam"]),
        //         Convert.ToString(reader["Straat"]),
        //         Convert.ToString(reader["nr"]),
        //         Convert.ToString(reader["Postcode"]),
        //         Convert.ToString(reader["Plaats"]));
        //    }
        //    else if (Convert.ToString(reader["Straat"]) != null && Convert.ToString(reader["nr"]) != null &&
        //             Convert.ToString(reader["Postcode"]) != null)
        //    {
        //        return new Locatie(
        //            Convert.ToInt32(reader["ID"]),
        //            Convert.ToString(reader["Naam"]),
        //            Convert.ToString(reader["Straat"]),
        //            Convert.ToString(reader["nr"]),
        //            Convert.ToString(reader["Postcode"]),
        //            "Geen Plaats");
        //    }
        //    else if (Convert.ToString(reader["Straat"]) != null && Convert.ToString(reader["nr"]) != null)
        //    {
        //        return new Locatie(
        //            Convert.ToInt32(reader["ID"]),
        //            Convert.ToString(reader["Naam"]),
        //            Convert.ToString(reader["Straat"]),
        //            Convert.ToString(reader["nr"]),
        //            "Geen Postcode",
        //            "Geen Plaats");
        //    }
        //    else if (Convert.ToString(reader["Straat"]) != null)
        //    {
        //        return new Locatie(
        //            Convert.ToInt32(reader["ID"]),
        //            Convert.ToString(reader["Naam"]),
        //            Convert.ToString(reader["Straat"]),
        //            "Geen Nummer",
        //            "Geen Postcode",
        //            "Geen Plaats");
        //    }
        //    else if (Convert.ToString(reader["Straat"]) != null && Convert.ToString(reader["nr"]) != null &&
        //             Convert.ToString(reader["Plaats"]) != null)
        //    {
        //        return new Locatie(
        //            Convert.ToInt32(reader["ID"]),
        //            Convert.ToString(reader["Naam"]),
        //            Convert.ToString(reader["Straat"]),
        //            Convert.ToString(reader["nr"]),
        //            "Geen Postcode",
        //            Convert.ToString(reader["Plaats"]));
        //    }
        //    else if (Convert.ToString(reader["Straat"]) != null && 
        //             Convert.ToString(reader["Plaats"]) != null)
        //    {
        //        return new Locatie(
        //            Convert.ToInt32(reader["ID"]),
        //            Convert.ToString(reader["Naam"]),
        //            Convert.ToString(reader["Straat"]),
        //            "Geen Nummer",
        //            "Geen Postcode",
        //            Convert.ToString(reader["Plaats"]));
        //    }
        //    else if (Convert.ToString(reader["Plaats"]) != null)
        //    {
        //        return new Locatie(
        //            Convert.ToInt32(reader["ID"]),
        //            Convert.ToString(reader["Naam"]),
        //            "Geen Straat",
        //            "Geen Nummer",
        //            "Geen Postcode",
        //            Convert.ToString(reader["Plaats"]));
        //    }
        //    else if (Convert.ToString(reader["Straat"]) != null && 
        //             Convert.ToString(reader["Postcode"]) != null)
        //    {
        //        return new Locatie(
        //            Convert.ToInt32(reader["ID"]),
        //            Convert.ToString(reader["Naam"]),
        //            Convert.ToString(reader["Straat"]),
        //            "Geen Nummer",
        //            Convert.ToString(reader["Postcode"]),
        //            "Geen Plaats");
        //    }
        //    else if (Convert.ToString(reader["nr"]) != null &&
        //             Convert.ToString(reader["Plaats"]) != null)
        //    {
        //        return new Locatie(
        //            Convert.ToInt32(reader["ID"]),
        //            Convert.ToString(reader["Naam"]),
        //            "Geen Straat",
        //            Convert.ToString(reader["nr"]),
        //            "Geen Postcode",
        //            Convert.ToString(reader["Plaats"]));
        //    }
        //    else if (Convert.ToString(reader["Straat"]) != null && Convert.ToString(reader["Postcode"]) != null &&
        //             Convert.ToString(reader["Plaats"]) != null)
        //    {
        //        return new Locatie(
        //            Convert.ToInt32(reader["ID"]),
        //            Convert.ToString(reader["Naam"]),
        //            Convert.ToString(reader["Straat"]),
        //            "Geen Nummer",
        //            Convert.ToString(reader["Postcode"]),
        //            Convert.ToString(reader["Plaats"]));
        //    }
        //    else if (Convert.ToString(reader["Straat"]) != null  &&
        //             Convert.ToString(reader["Plaats"]) != null)
        //    {
        //        return new Locatie(
        //            Convert.ToInt32(reader["ID"]),
        //            Convert.ToString(reader["Naam"]),
        //            Convert.ToString(reader["Straat"]),
        //            "Geen Nummer",
        //            "Geen Postcode",
        //            Convert.ToString(reader["Plaats"]));
        //    }
        //    else if (Convert.ToString(reader["Straat"]) != null &&
        //             Convert.ToString(reader["Plaats"]) != null)
        //    {
        //        return new Locatie(
        //            Convert.ToInt32(reader["ID"]),
        //            Convert.ToString(reader["Naam"]),
        //            Convert.ToString(reader["Straat"]),
        //            "Geen Nummer",
        //            "Geen Postcode",
        //            Convert.ToString(reader["Plaats"]));
        //    }
        //    else if (Convert.ToString(reader["Straat"]) != null && Convert.ToString(reader["nr"]) != null &&
        //             Convert.ToString(reader["Plaats"]) != null)
        //    {
        //        return new Locatie(
        //            Convert.ToInt32(reader["ID"]),
        //            Convert.ToString(reader["Naam"]),
        //            "Geen Straat",
        //            Convert.ToString(reader["nr"]),
        //            Convert.ToString(reader["Postcode"]),
        //            Convert.ToString(reader["Plaats"]));
        //    }
        //    else if (Convert.ToString(reader["Straat"]) != null &&
        //             Convert.ToString(reader["Plaats"]) != null)
        //    {
        //        return new Locatie(
        //            Convert.ToInt32(reader["ID"]),
        //            Convert.ToString(reader["Naam"]),
        //            "Geen Straat",
        //            "Geen Nummer",
        //            Convert.ToString(reader["Postcode"]),
        //            Convert.ToString(reader["Plaats"]));
        //    }
        //    else return new Locatie(
        //            Convert.ToInt32(reader["ID"]),
        //            Convert.ToString(reader["Naam"]),
        //            "Geen Straat",
        //            "Geen Nummer",
        //            "Geen Postcode",
        //            "Geen Plaats");
                
        //}

    }
}