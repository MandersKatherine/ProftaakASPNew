﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using ASP_PROFTAAK.Controllers;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public class BijdrageSQLContext : IBijdrageContext
    {
        public Bijdrage GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public bool InsertBijdrage(int Accountid, string soort, string titel, string inhoud, int catId, string bestandloc, string catNaam)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "EXEC NieuweBijdrage @account_id = @accid, @soort = @soort1, @titel = @titel1, @inhoud = @inhoud1, @categorie_id = @catId, @bestandlocatie = @bestandloc, @grootte = @grootte1, @naam = @naam1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@accid", Accountid);
                    command.Parameters.AddWithValue("@soort1", soort);
                    command.Parameters.AddWithValue("@titel1", titel);
                    command.Parameters.AddWithValue("@inhoud1", inhoud);
                    command.Parameters.AddWithValue("@catId", catId);
                    command.Parameters.AddWithValue("@bestandloc", bestandloc);
                    command.Parameters.AddWithValue("@grootte1", 10);
                    command.Parameters.AddWithValue("@naam1", catNaam);
                    command.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public bool DeleteBijdrage(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "DELETE FROM BIJDRAGE WHERE ID = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    return true;
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

        public List<Categorie> GetAllCategories()
        {
            List<Categorie> catList = new List<Categorie>();
            using (SqlConnection connectie = Database.Connection)
            {
                string query = "select bijdrage_id, categorie_id ,naam from CATEGORIE";
                using (SqlCommand command = new SqlCommand(query, connectie))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Categorie bijdrage = CreateCategorieromReader(reader);
                            catList.Add(bijdrage);
                        }
                    }
                }
            }
            return catList;
        }

        private Categorie CreateCategorieromReader(SqlDataReader reader)
        {
            return new Categorie(
                Convert.ToInt32(reader["bijdrage_id"]),
                Convert.ToInt32(reader["categorie_id"] != DBNull.Value ? Convert.ToInt32(reader["categorie_id"]) : 0),
                Convert.ToString(reader["naam"])
                );
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
                    "LEFT JOIN ACCOUNT a on b.account_id = a.ID WHERE br.reactie = 0 OR be.reactie = 0 OR c.reactie = 0";
                    //"LEFT JOIN ACCOUNT_BIJDRAGE ab on b.ID = ab.bijdrage_id";



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

        public bool Like(int Bijdrageid, int Accountid)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "EXEC VotingSystem @BijdrageID = @bijdrid, @AccountID = @accid";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@bijdrid", Bijdrageid);
                    command.Parameters.AddWithValue("@accid", Accountid);
                    command.ExecuteNonQuery();
                    return true;
                }
            }
        }
        public bool Report(int Bijdrageid, int Accountid)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "EXEC ReportSys @BijdrageID = @bijdrid, @AccountID = @accid";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@bijdrid", Bijdrageid);
                    command.Parameters.AddWithValue("@accid", Accountid);
                    command.ExecuteNonQuery();
                    return true;
                }
            }
        }
        public List<Reactie> GetAllReactiesByBijdrageID(int id)
        {
            List<Reactie> reactieList = new List<Reactie>();
            using (SqlConnection connectie = Database.Connection)
            {
                string query = "SELECT bericht_id, inhoud FROM BIJDRAGE INNER JOIN BIJDRAGE_BERICHT ON BIJDRAGE.ID = BIJDRAGE_BERICHT.bijdrage_id INNER JOIN BERICHT ON BIJDRAGE_BERICHT.bericht_id = BERICHT.bijdrage_id WHERE BIJDRAGE.ID = @id ;";
                using (SqlCommand command = new SqlCommand(query, connectie))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Reactie reactie = CreateReactieromReader(reader);
                            reactieList.Add(reactie);
                        }
                    }
                }
            }
            return reactieList;
        }

        public bool AddReactie(string Tekst, int accountId, int postId)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "EXEC AddReactie @Titel = @Titel1, @Inhoud = @Tekst, @Datum = @Date, @Soort = 'bericht', @AccID = @accid, @ReactiePostID = @postID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Titel1", "ReactieOp" + Convert.ToString(postId));
                    command.Parameters.AddWithValue("@Tekst", Tekst);
                    command.Parameters.AddWithValue("@Date", DateTime.Now);
                    command.Parameters.AddWithValue("@accid", accountId);
                    command.Parameters.AddWithValue("@postID", postId);
                    command.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public List<Bijdrage> GetAllReports()
        {
            List<Bijdrage> bijdrageList = new List<Bijdrage>();

            using (SqlConnection connection = Database.Connection)
            {
                string query =
                    "SELECT * FROM BIJDRAGE b " +
                    "LEFT JOIN CATEGORIE c on b.ID = c.bijdrage_id " +
                    "LEFT JOIN BESTAND be on b.ID = be.bijdrage_id " +
                    "LEFT JOIN BERICHT br on b.ID = br.bijdrage_id " +
                    "LEFT JOIN ACCOUNT a on b.account_id = a.ID LEFT JOIN ACCOUNT_BIJDRAGE ab on b.ID = ab.bijdrage_id WHERE ab.ongewenst = 1";
                //"";



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
        public List<Like1> GetAllLikes()
        {
            List<Like1> likeList = new List<Like1>();

            using (SqlConnection connection = Database.Connection)
            {
                string query =
                    "SELECT bijdrage_id, SUM([like]) AS Likes FROM ACCOUNT_BIJDRAGE GROUP BY bijdrage_id";
                //"";



                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Like1 like = CreateLikeFromReader(reader);
                            likeList.Add(like);
                        }
                    }
                }
            }
            return likeList;
        }

        private Like1 CreateLikeFromReader(SqlDataReader reader)
        {
            return new Like1(
                Convert.ToInt32(reader["bijdrage_id"]),
                Convert.ToInt32(reader["Likes"])
            );
        }
        private Reactie CreateReactieromReader(SqlDataReader reader)
        {
            return new Reactie(
                Convert.ToInt32(reader["bericht_id"]),
                Convert.ToString(reader["inhoud"])
            );
        }

        private Bijdrage CreateBijdrageFromReader(SqlDataReader reader)
        {
            AccountRepository accRepo = new AccountRepository(new AccountSQLContext());
            if (reader["soort"].ToString() == "bestand")
            {
              {  Account account = accRepo.GetAccountById(Convert.ToInt32(reader["account_id"]));
                AccountBijdrage accBijdrage;
                try
                {
                    accBijdrage = new AccountBijdrage(Convert.ToInt32(reader["account_id"]),Convert.ToInt32(reader["bijdrage_id"]),Convert.ToInt32(reader["like"]), Convert.ToInt32(reader["ongewenst"]));
                }
                catch (Exception e)
                {
                    accBijdrage = new AccountBijdrage(0,0,0,0,0);
                }
                
                    return new Bestand(
                        Convert.ToInt32(reader["ID"]),
                        account,
                        Convert.ToDateTime(reader["datum"]),
                        Convert.ToString(reader["soort"]),
                        Convert.ToInt32(reader["categorie_id"] != DBNull.Value ? Convert.ToInt32(reader["categorie_id"]) : 0),
                        Convert.ToString(reader["bestandslocatie"] != DBNull.Value ? Convert.ToString(reader["bestandslocatie"]) : ""),
                        Convert.ToInt32(reader["grootte"] != DBNull.Value ? Convert.ToInt32(reader["grootte"]) : 0),
                        accBijdrage
                    );
                }
            }

            if (reader["soort"].ToString() == "categorie")
            {
                {
                    Account account = accRepo.GetAccountById(Convert.ToInt32(reader["account_id"]));
                    AccountBijdrage accBijdrage;
                    try
                    {
                        accBijdrage = new AccountBijdrage(Convert.ToInt32(reader["account_id"]),
                            Convert.ToInt32(reader["bijdrage_id"]), Convert.ToInt32(reader["like"]),
                            Convert.ToInt32(reader["ongewenst"]));
                    }
                    catch (Exception e)
                    {
                        accBijdrage = new AccountBijdrage(0, 0, 0, 0, 0);
                    }
                    return new Categorie(
                        Convert.ToInt32(reader["ID"]),
                        account,
                        Convert.ToDateTime(reader["datum"]),
                        Convert.ToString(reader["soort"]),
                        Convert.ToInt32(reader["categorie_id"] != DBNull.Value
                            ? Convert.ToInt32(reader["categorie_id"])
                            : 0),
                        Convert.ToString(reader["naam"]),
                        accBijdrage
                    );
                }
            }
            
            
            if (reader["soort"].ToString() == "bericht")
            {
               { Account account = accRepo.GetAccountById(Convert.ToInt32(reader["account_id"]));
                AccountBijdrage accBijdrage;
                try
                {
                    accBijdrage = new AccountBijdrage(Convert.ToInt32(reader["account_id"]), Convert.ToInt32(reader["bijdrage_id"]), Convert.ToInt32(reader["like"]), Convert.ToInt32(reader["ongewenst"]));
                }
                catch (Exception e)
                {
                    accBijdrage = new AccountBijdrage(0, 0, 0, 0, 0);
                }
                
                    return new Bericht(
                        Convert.ToInt32(reader["ID"]),
                        account,
                        accBijdrage,
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