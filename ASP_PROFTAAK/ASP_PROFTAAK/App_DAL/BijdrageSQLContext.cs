using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public class BijdrageSQLContext : IBijdrageContext
    {
        public bool DeleteBijdrage(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                //hier wordt een stored procedure genaamd deletebijdrage aangeroepen, EXEC DeleteBijdrage @ID = id
                using (SqlCommand command = new SqlCommand("DeleteBijdrage", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);
                    try
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException e)
                    {
                    }
                    return false;
                }
            }
        }

        public List<Bericht> GetAllBerichts()
        {
            List<Bericht> berichtcollection = new List<Bericht>();
            using (SqlConnection connectie = Database.Connection)
            {
                SqlCommand cmd = new SqlCommand("select * from bericht \r\ninner join BIJDRAGE a on a.ID = BERICHT.bijdrage_id", connectie);
                cmd.ExecuteNonQuery();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        berichtcollection.Add(CreateBerichtCollectieFromReader(reader));
                    }
                }
            }
            return berichtcollection; 
        }

        private Bericht CreateBerichtCollectieFromReader(SqlDataReader reader)
        {
            return  new Bericht(
                Convert.ToString(reader["titel"]),
                Convert.ToString(reader["inhoud"]),
                Convert.ToInt32(reader["bijdrage_id"]),
                Convert.ToInt32(reader["account_id"]),
                Convert.ToString(reader["datum"]),
                Convert.ToString(reader["soort"]));
        }

        private Bijdrage CreateBijdrageFromReader(SqlDataReader reader)
        {
            return new Bijdrage(
                Convert.ToInt32(reader["ID"]),
                Convert.ToInt32(reader["account_id"]),
                Convert.ToString(reader["datum"]),
                Convert.ToString(reader["soort"]));
        }

        public bool InsertBijdrage(Bijdrage bijdrage)
        {
            using (SqlConnection connection = Database.Connection)
            {

                using (SqlCommand command = new SqlCommand("NieuweBijdrage", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@account_ID", bijdrage.AccountId);
                    command.Parameters.AddWithValue("@soort", "bestand");//dit moet nog worden gefixt
                    command.Parameters.AddWithValue("@titel", (bijdrage as Bericht).Titel);
                    command.Parameters.AddWithValue("@inhoud", (bijdrage as Bericht).Inhoud);
                    command.Parameters.AddWithValue("@categorie_id", (bijdrage as Categorie).CategorieId);
                    command.Parameters.AddWithValue("@bestandslocatie", (bijdrage as Bestand).BestandsLocatie);
                    command.Parameters.AddWithValue("@grootte", (bijdrage as Bestand).Grootte);
                    command.Parameters.AddWithValue("@categorie_id", (bijdrage as Categorie).Naam);
                    
                    try
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException e)
                    {

                    }
                    return false;
                }
            }
        }


        public bool UpdateBijdrageBericht(Bericht bericht)
        {
            using (SqlConnection connection = Database.Connection)
            {
                using (SqlCommand command =
                    new SqlCommand("update bericht set titel = @Titel, inhoud = @Inhoud where bijdrage_id = @ID;",
                        connection))
                {
                    command.Parameters.AddWithValue("@ID", bericht.AccountId);
                    command.Parameters.AddWithValue("@Titel", bericht.Titel);
                    command.Parameters.AddWithValue("@Inhoud", bericht.Inhoud);

                    try
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException e)
                    {

                    }
                    return false;
                }
            }
        }

        public bool UpdateBijdrageBestand(Bestand bestand)
        {
            using (SqlConnection connection = Database.Connection)
            {
                using (SqlCommand command =
                    new SqlCommand("update bestand set categorie_id = @catid, bestandslocatie = @bestandslocatie, grootte = @grootte where bijdrage_id = @id; ",
                        connection))
                {
                    command.Parameters.AddWithValue("@catid", bestand.CategorieId);
                    command.Parameters.AddWithValue("@bestandslocatie", bestand.BestandsLocatie);
                    command.Parameters.AddWithValue("@grootte", bestand.Grootte);

                    try
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException e)
                    {

                    }
                    return false;
                }
            }
        }

        public Bijdrage GetByID(int ID)
        {
            Bijdrage bd = new Bijdrage();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "select * from bijdrage where BIJDRAGE.ID = @ID;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bd = CreateBijdrageFromReader(reader);
                        }
                    }
                }
            }
            return bd;
        }
    }
}