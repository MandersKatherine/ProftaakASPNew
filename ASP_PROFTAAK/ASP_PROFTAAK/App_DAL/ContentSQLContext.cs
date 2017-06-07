using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public class ContentSQLContext: IContentContext
    {

        public Bestand getBestandByBijdrageId (int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM bestand where bijdrage_id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //return CreateBestandFromReader(reader);

                        }
                    }
                }
            }
            return null;
        }

        public Bericht getBerichtByBijdrageId(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM bericht where bijdrage_id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //return CreateBerichtFromReader(reader);

                        }
                    }
                }
            }
            return null;
        }

        public Categorie getCategorieByBijdrageId(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM categorie where bijdrage_id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //return CreateCategorieFromReader(reader);

                        }
                    }
                }
            }
            return null;
        }

        public Reactie getReactieByBijdrageId(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM bijdrage_bericht where bijdrage_id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //return CreateReactieFromReader(reader);

                        }
                    }
                }
            }
            return null;
        }

        public List<Mening> getMeningenByBijdrageId(int id)
        {
            List<Mening> meningen = new List<Mening>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM account_bijdrage where bijdrage_id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //meningen.Add(CreateMeningFromReader(reader));

                        }
                    }
                }
            }
            return null;
        }



        //private Bestand CreateBestandFromReader(SqlDataReader reader)
        //{
        //    return new Bestand(
        //        Convert.ToInt32(reader["bijdrage_id"]),
        //        Convert.ToInt32(reader["categorie_Id"]),
        //        Convert.ToString(reader["bestandslocatie"]),
        //        Convert.ToInt32(reader["grootte"]));
        //}

        //private Bericht CreateBerichtFromReader(SqlDataReader reader)
        //{
        //    return new Bericht(
        //        Convert.ToInt32(reader["bijdrage_id"]),
        //        Convert.ToString(reader["titel"]),
        //        Convert.ToString(reader["inhoud"]));
        //}

        //private Categorie CreateCategorieFromReader(SqlDataReader reader)
        //{
        //    return new Categorie(
        //        Convert.ToInt32(reader["bijdrage_id"]),
        //        Convert.ToInt32(reader["categorie_id"] != DBNull.Value ? Convert.ToInt32(reader["categorie_id"]) : 0),
        //        Convert.ToString(reader["naam"]));
        //}

        //private Reactie CreateReactieFromReader(SqlDataReader reader)
        //{
        //    return new Reactie(
        //        Convert.ToInt32(reader["bijdrage_id"]),
        //        Convert.ToInt32(reader["bericht_id"]));
        //}

        //private Mening CreateMeningFromReader(SqlDataReader reader)
        //{
        //    return new Mening(
        //        Convert.ToInt32(reader["ID"]),
        //        Convert.ToInt32(reader["account_id"]),
        //        Convert.ToInt32(reader["bijdrage_id"]),
        //        Convert.ToInt32(reader["like"]),
        //        Convert.ToInt32(reader["ongewenst"]));
             
        //}
    }
}

                    
           
    
