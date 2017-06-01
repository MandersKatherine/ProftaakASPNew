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
        public Bijdrage GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public bool InsertBijdrage(Bijdrage bijdrage)
        {
            throw new NotImplementedException();
        }

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

        public bool UpdateBijdrageBericht(Bericht bericht)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBijdrageBestand(Bestand bestand)
        {
            throw new NotImplementedException();
        }

        public List<Bericht> GetAllBerichts()
        {
            List<Bericht> berichtcollection = new List<Bericht>();
            using (SqlConnection connectie = Database.Connection)
            {
                SqlCommand cmd =
                    new SqlCommand("select * from bericht \r\ninner join BIJDRAGE a on a.ID = BERICHT.bijdrage_id",
                        connectie);
                cmd.ExecuteNonQuery();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //berichtcollectCreateBerichtCollectieFromReaderion.Add((reader));
                    }
                }
            }
            return berichtcollection;
        }

       


        public List<Bijdrage> GetAllBijdrages()
        {
            List<Bijdrage> bijdrageList = new List<Bijdrage>();

            using (SqlConnection connection = Database.Connection)
            {
                string query =
                    "SELECT * FROM BIJDRAGE b " +
                    "LEFT JOIN CATEGORIE c on b.ID = c.bijdrage_id " +
                    "LEFT JOIN BESTAND be on b.ID = be.bijdrage_id " +
                    "LEFT JOIN BERICHT br on b.ID = br.bijdrage_id " +
                    "LEFT JOIN ACCOUNT a on b.account_id = a.ID " +
                    "LEFT JOIN ACCOUNT_BIJDRAGE ab on b.ID = ab.bijdrage_id";



                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Bijdrage bijdrage = CreateBijdrageFromReader(reader);
                            bijdrageList.Add(bijdrage);
                        }
                    }
                }
            }
            return bijdrageList;
        }

        private Bijdrage CreateBijdrageFromReader(SqlDataReader reader)
        {
            if (reader["soort"].ToString() == "bestand")
            {
                {
                    return new Bestand(
                        Convert.ToInt32(reader["ID"]),
                        Convert.ToInt32(reader["account_id"]),
                        Convert.ToDateTime(reader["datum"]),
                        Convert.ToString(reader["soort"]),
                        Convert.ToInt32(reader["categorie_id"] != DBNull.Value ? Convert.ToInt32(reader["categorie_id"]) : 0),
                        Convert.ToString(reader["bestandslocatie"] != DBNull.Value ? Convert.ToString(reader["bestandslocatie"]) : ""),
                        Convert.ToInt32(reader["grootte"] != DBNull.Value ? Convert.ToInt32(reader["grootte"]) : 0)
                    );
                }
            }

            if (reader["soort"].ToString() == "categorie")
            {
                return new Categorie(
                    Convert.ToInt32(reader["ID"]),
                    Convert.ToInt32(reader["account_id"]),
                    Convert.ToDateTime(reader["datum"]),
                    Convert.ToString(reader["soort"]),
                    Convert.ToInt32(reader["categorie_id"] != DBNull.Value ? Convert.ToInt32(reader["categorie_id"]) : 0),
                    Convert.ToString(reader["naam"])
                );
            }
            
            if (reader["soort"].ToString() == "bericht")
            {
                {
                    return new Bericht(
                        Convert.ToInt32(reader["ID"]),
                        Convert.ToInt32(reader["account_id"]),
                        Convert.ToDateTime(reader["datum"]),
                        Convert.ToString(reader["soort"]),
                        Convert.ToString(reader["titel"]),
                        Convert.ToString(reader["inhoud"])
                    );
                }
            }
            else
            {
                return null;
            }
        }


    }
}



//        case "categorie":
//            return new Categorie(
//                Convert.ToInt32(reader["Id"]),
//                Convert.ToString(reader["ImageName"]),
//                Convert.ToString(reader["ImageLink"]));

//        case 2:
//            return new Video(
//                Convert.ToInt32(reader["Id"]),
//                Convert.ToString(reader["VideoName"]),
//                Convert.ToString(reader["VideoLink"]));
//    }
//}

//public bool InsertBijdrage(Bijdrage bijdrage)
//{
//        //    using (SqlConnection connection = Database.Connection)
//        //    {

//        //        using (SqlCommand command = new SqlCommand("NieuweBijdrage", connection))
//        //        {
//        //            command.CommandType = System.Data.CommandType.StoredProcedure;
//        //            command.Parameters.AddWithValue("@account_ID", bijdrage.AccountId);
//        //            command.Parameters.AddWithValue("@soort", "bestand");//dit moet nog worden gefixt
//        //            command.Parameters.AddWithValue("@titel", (bijdrage as Bericht).Titel);
//        //            command.Parameters.AddWithValue("@inhoud", (bijdrage as Bericht).Inhoud);
//        //            command.Parameters.AddWithValue("@categorie_id", (bijdrage as Categorie).CategorieId);
//        //            command.Parameters.AddWithValue("@bestandslocatie", (bijdrage as Bestand).BestandsLocatie);
//        //            command.Parameters.AddWithValue("@grootte", (bijdrage as Bestand).Grootte);
//        //            command.Parameters.AddWithValue("@categorie_id", (bijdrage as Categorie).Naam);

//        //            try
//        //            {
//        //                command.ExecuteNonQuery();
//        //                return true;
//        //            }
//        //            catch (SqlException e)
//        //            {

//        //            }
//        //            return false;
//        //        }
//        //    }
//        //}


//public bool UpdateBijdrageBericht(Bericht bericht)
//        {
//            //using (SqlConnection connection = Database.Connection)
//            //{
//            //    using (SqlCommand command =
//            //        new SqlCommand("update bericht set titel = @Titel, inhoud = @Inhoud where bijdrage_id = @ID;",
//            //            connection))
//            //    {
//            //        command.Parameters.AddWithValue("@ID", bericht.AccountId);
//            //        command.Parameters.AddWithValue("@Titel", bericht.Titel);
//            //        command.Parameters.AddWithValue("@Inhoud", bericht.Inhoud);

//            //        try
//            //        {
//            //            command.ExecuteNonQuery();
//            //            return true;
//            //        }
//            //        catch (SqlException e)
//            //        {

//            //        }
//            //        return false;
//            //    }
//            //}
//            return true;
//        }

//        public bool UpdateBijdrageBestand(Bestand bestand)
//        {
//            using (SqlConnection connection = Database.Connection)
//            {
//                using (SqlCommand command =
//                    new SqlCommand("update bestand set categorie_id = @catid, bestandslocatie = @bestandslocatie, grootte = @grootte where bijdrage_id = @id; ",
//                        connection))
//                {
//                    command.Parameters.AddWithValue("@catid", bestand.CategorieId);
//                    command.Parameters.AddWithValue("@bestandslocatie", bestand.BestandsLocatie);
//                    command.Parameters.AddWithValue("@grootte", bestand.Grootte);

//                    try
//                    {
//                        command.ExecuteNonQuery();
//                        return true;
//                    }
//                    catch (SqlException e)
//                    {

//                    }
//                    return false;
//                }
//            }
//        }

//        public Bijdrage GetByID(int ID)
//        {
//            using (SqlConnection connection = Database.Connection)
//            {
//                string query = "select * from bijdrage where BIJDRAGE.ID = @ID;";
//                using (SqlCommand command = new SqlCommand(query, connection))
//                {
//                    command.Parameters.AddWithValue("@ID", ID);
//                    using (SqlDataReader reader = command.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            return CreateBijdrageFromReader(reader);
//                        }
//                    }
//                }
//            }
//            return null;
//        }
//    }
//}