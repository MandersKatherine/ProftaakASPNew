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