using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public class PersoonSQLContext : IPersoonContext
    {
        public List<Persoon> GetAllPersonen()
        {
            List<Persoon> personen = new List<Persoon>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM PERSOON ORDER BY ID";

                //commit
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            personen.Add(CreatePersoonFromReader(reader));
                        }
                    }
                }
            }
            return personen;
        }

        public Persoon getHoofdboekerByReserveringId(decimal id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "select * from Persoon inner join reservering on persoon.id = reservering.persoon_id where reservering.id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return CreatePersoonFromReader(reader);

                        }
                    }
                }
            }
            return null;
        }

        public Persoon InsertPersoon(Persoon persoon)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO PERSOON (Voornaam, Tussenvoegsel, Achternaam, Straat, Huisnr, Woonplaats, Banknr)" +
                    "VALUES (@voornaam, @tussenvoegsel, @achternaam, @straat, @huisnr, @woonplaats, @banknr)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@voornaam", persoon.Voornaam);
                    command.Parameters.AddWithValue("@tussenvoegsel", persoon.Tussenvoegsel);
                    command.Parameters.AddWithValue("@achternaam", persoon.Achternaam);
                    command.Parameters.AddWithValue("@straat", persoon.Straat);
                    command.Parameters.AddWithValue("@huisnr", persoon.Huisnr);
                    command.Parameters.AddWithValue("@woonplaats", persoon.Woonplaats);
                    command.Parameters.AddWithValue("@banknr", persoon.Banknr);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                }
                return persoon;
            }
        }

        public bool UpdatePersoon(Persoon persoon)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "UPDATE PERSOON" +
                    " SET Voornaam=@voornaam, Tussenvoegsel=@tussenvoegsel, Achternaam=@achternaam, Straat=@straat, Huisnr=@huisnr, Woonplaats=@woonplaats, Banknr=@banknr" +
                    " WHERE ID=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", persoon.Id);
                    command.Parameters.AddWithValue("@voornaam", persoon.Voornaam);
                    command.Parameters.AddWithValue("@tussenvoegsel", persoon.Tussenvoegsel);
                    command.Parameters.AddWithValue("@achternaam", persoon.Achternaam);
                    command.Parameters.AddWithValue("@straat", persoon.Straat);
                    command.Parameters.AddWithValue("@huisnr", persoon.Huisnr);
                    command.Parameters.AddWithValue("@woonplaats", persoon.Woonplaats);
                    command.Parameters.AddWithValue("@banknr", persoon.Banknr);
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

        public bool DeletePersoon(decimal id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "DELETE FROM PERSOON WHERE ID=@id";
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

        private Persoon CreatePersoonFromReader(SqlDataReader reader)
        {
            return new Persoon(
                 Convert.ToInt32(reader["ID"]),
                 Convert.ToString(reader["Voornaam"]),
                 Convert.ToString(reader["Tussenvoegsel"]),
                 Convert.ToString(reader["Achternaam"]),
                 Convert.ToString(reader["Straat"]),
                 Convert.ToString(reader["Huisnr"]),
                 Convert.ToString(reader["Woonplaats"]),
                 Convert.ToString(reader["Banknr"]));
        }

    }
}