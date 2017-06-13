using ASP_PROFTAAK.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.App_DAL
{
    public class PolsbandjeSQLContext : IPolsbandjeContext
    {
        Polsbandje polsbandje;

        public List<Polsbandje> GetAllPolsbandjes()
        {
            List<Polsbandje> polsbandje = new List<Polsbandje>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM Polsbandje ORDER BY ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            polsbandje.Add(CreatePolsbandjeFromReader(reader));
                        }
                    }
                }
            }
            return polsbandje;
        }

        public List<Polsbandje> getPolsbandjesByReserveringID(int reserveringid)
        {
            List<Polsbandje> polsbandje = new List<Polsbandje>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM Polsbandje WHERE ReserveringId=@reserveringid";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@reserveringid", reserveringid);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            polsbandje.Add(CreatePolsbandjeFromReader(reader));
                        }
                    }
                }
            }
            return polsbandje;
        }

        public Polsbandje InsertPolsbandje(Polsbandje polsbandje)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO Polsbandje (Barcode, Actief)" +
                        "VALUES (@barcode, @actief)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@barcode", polsbandje.Barcode);
                    command.Parameters.AddWithValue("@actief", polsbandje.Actief);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                    return polsbandje;

                }

            }
        }

        public bool DeletePolsbandje(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "DELETE FROM Polsbandje WHERE ID=@id";
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

        public bool UpdatePolsbandje(Polsbandje polsbandje)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "UPDATE Polsbandje SET Barcode = @barcode, Actief = @actief WHERE Id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@id", polsbandje.Id);
                    command.Parameters.AddWithValue("@barcode", polsbandje.Barcode);
                    command.Parameters.AddWithValue("@actief", polsbandje.Actief);
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

        public Polsbandje GetPolsbandjeById(decimal id)
        {

            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM Polsbandje WHERE ID=@id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            polsbandje = CreatePolsbandjeFromReader(reader);
                        }
                    }
                }
            }
            return polsbandje;
        }

        public Polsbandje GetEventByPolsbandjeId(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT e.naam, e.datumstart, e.datumEinde, e.maxBezoekers, p.nummer, p.capaciteit" +
                               "FROM EVENT e " + 
                               "INNER JOIN LOCATIE l ON l.ID = e.locatie_id" +
                               "INNER JOIN PLEK p ON p.locatie_id = l.ID " +
                               "INNER JOIN PLEK_RESERVERING pr ON pr.plek_id = p.ID" +
                               "INNER JOIN RESERVERING r ON pr.reservering_id = r.ID" +
                               "INNER JOIN RESERVERING_POLSBANDJE rp ON rp.reservering_id = r.ID" +
                               "INNER JOIN POLSBANDJE po ON rp.polsbandje_id = po.ID WHERE po.ID = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            polsbandje = CreatePolsbandjeFromReader(reader);
                        }
                    }
                }
            }
            return polsbandje;
        }

        private Polsbandje CreatePolsbandjeFromReader(SqlDataReader reader)
        {
            return new Polsbandje(
                Convert.ToDecimal(reader["ID"]),
                Convert.ToString(reader["Barcode"]),
                Convert.ToDecimal(reader["Actief"]));
        }
    }
}