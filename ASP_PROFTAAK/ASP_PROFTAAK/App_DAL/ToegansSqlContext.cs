using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public class ToegansSqlContext : IToegangsControleContext
    {
        public List<Aanwezig> GetAllAanwezig()
        {
            //todo nog naar kijken hoe dit per event opgevraagd kan worden. 
            // testquery hiervoor in sqlmanager
            List<Aanwezig> aanwezigheidEvent = new List<Aanwezig>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "select Polsbandje.ID, polsbandje.barcode, RESERVERING_POLSBANDJE.aanwezig," +
                    " Account.voornaam, Account.tussenvoegsel, Account.achternaam, Account.telefoonnummer" +
                " from polsbandje" +
                " inner join Reservering_Polsbandje on polsbandje.ID = RESERVERING_POLSBANDJE.polsbandje_id" +
                " inner join Account on RESERVERING_POLSBANDJE.account_id = Account.ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            aanwezigheidEvent.Add(CreateAanwezigheidFromReader(reader));
                        }
                    }
                }
            }
            return aanwezigheidEvent;
        }

        public void ChangeAanwezigheid(decimal accountid)
        {
            //stored procedure die de aanwezigheid verranderd (1 als 0, 0 als 1)
            using (SqlConnection connection = Database.Connection)
            {
                using (SqlCommand cmd = new SqlCommand("AanwezigheidAanpassen", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@accountid", SqlDbType.Int).Value = (int)accountid;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool CheckBetaald(string barcode)
        {
            decimal betaald = 0;
            using (SqlConnection connection = Database.Connection)
            {
                string query = "select betaald from reservering inner join RESERVERING_POLSBANDJE" +
                    " on reservering.ID = RESERVERING_POLSBANDJE.reservering_id" +
                    " inner join polsbandje on RESERVERING_POLSBANDJE.polsbandje_id = polsbandje.ID" +
                    " where barcode = @barcode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("barcode", barcode);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            betaald = (decimal)reader["betaald"];
                        }
                    }
                }
            }
            if (betaald == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void BrengPolsbandjeTerug(string barcode)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "update polsbandje set actief = 0 where barcode = @barcode; "+ 
                        "update RESERVERING_POLSBANDJE set aanwezig = 0 from RESERVERING_POLSBANDJE"+
                        "inner join polsbandje on RESERVERING_POLSBANDJE.polsbandje_id = polsbandje.ID where barcode = @barcode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("barcode", barcode);
                    command.ExecuteNonQuery();
                }
            }
        }


        private Aanwezig CreateAanwezigheidFromReader(SqlDataReader reader)
        {
            return new Aanwezig(
                (decimal)reader["id"],
                (string)reader["barcode"],
                (decimal)reader["aanwezig"],
                (string)reader["voornaam"],
                (string)reader["tussenvoegsel"],
                (string)reader["achternaam"],
                (string)reader["telefoonnummer"]);
        }
    }
}