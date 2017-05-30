using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public class BijdrageSQLContext : IBijdrageContext
    {
        public bool DeleteBijdrage(int id)
        {
            throw new NotImplementedException();
        }

        public List<Bijdrage> GetAllBijdrage()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool UpdateBijdrageBestand(Bestand bestand)
        {
            throw new NotImplementedException();
        }
    }
}