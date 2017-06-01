using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public class EventSQLContext:IEventContext
    {
        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM EVENT ORDER BY ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            events.Add(CreateEventFromReader(reader));
                        }
                    }
                }
            }
            return events;
        }

        public Event GetById(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM EVENT WHERE ID = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Event eventdetails = CreateEventFromReader(reader);
                            return eventdetails;
                        }
                    }
                }

            }
            return null;
        }
        public Event GetEventById(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM EVENT WHERE locatie_id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Event eventdetails = CreateEventFromReader(reader);
                            return eventdetails;
                        }
                    }
                }

            }
            return null;
        }

        public Event InsertEvent(Event events)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO Event (Locatie_id, naam, datumStart, datumEinde, maxBezoekers)" +
                    " VALUES (@locatie_id, @naam, @datumstart, @datumeinde, @maxbezoekers)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@locatie_id", events.Locatie_id);
                    command.Parameters.AddWithValue("@naam", events.Naam);
                    command.Parameters.AddWithValue("@datumstart", events.DatumStart);
                    command.Parameters.AddWithValue("@datumeinde", events.DatumEinde);
                    command.Parameters.AddWithValue("@maxbezoekers", events.MaxBezoekers);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        // Unexpected error: rethrow to let the caller handle it
                        return null;
                    }
                }
                return events;
            }
        }

        public bool UpdateEvent(int id, Event events)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "UPDATE Event" +
                    " SET Naam=@naam, datumStart=@datumstart, datumEinde=@datumeinde, maxBezoekers=@maxbezoekers" +
                    " WHERE ID=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("naam", events.Naam);
                    command.Parameters.AddWithValue("datumstart", events.DatumStart);
                    command.Parameters.AddWithValue("datumeinde", events.DatumEinde);
                    command.Parameters.AddWithValue("maxbezoekers", events.MaxBezoekers);
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
        public bool DeleteEvent(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "DELETE FROM Event" +
                               " WHERE ID=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }

                }
            }

            return false;
        }

        private Event CreateEventFromReader(SqlDataReader reader)
        {
            return new Event(
                 Convert.ToInt32(reader["ID"]),
                 Convert.ToInt32(reader["locatie_id"]),
                 Convert.ToString(reader["naam"]),
                 Convert.ToDateTime(reader["datumstart"]),
                 Convert.ToDateTime(reader["datumEinde"]),
                 Convert.ToInt32(reader["maxBezoekers"]));
          

            
    }
    }
}