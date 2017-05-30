using ASP_PROFTAAK.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.App_DAL
{
    public class AccountSQLContext : IAccountContext
    {
        public List<Account> GetAllAccounts()
        {
            List<Account> accounts = new List<Account>();
            using (SqlConnection connection = Database.Connection)
            {

                string query = "SELECT * FROM Account ORDER BY ID";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accounts.Add(CreateAccountFromReader(reader));
                        }
                    }
                }
            }
            return accounts;
        }
        public Account Login(string email, string password)
        {
            SqlConnection connection = Database.Connection;
            ConnectionState conState = connection.State;
            if (conState == ConnectionState.Open)
            {
                string query = "SELECT * FROM [ACCOUNT] WHERE email=@email and wachtwoord=@pass";
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@pass", password);
                    cmd.ExecuteScalar();
                    
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Account account = CreateAccountFromReader(reader);
                                return account;
                            }
                        }
                        

                    
                }

            }

            return null;



        }




        public Account InsertAccount(Account account)
        {
            using (SqlConnection connection = Database.Connection)
            {

                string query = "INSERT INTO Account (Gebruikersnaam, Email, Activatiehash, Wachtwoord, Voornaam, Achternaam, Telefoonnr, Geactiveerd)" +
               
                        "VALUES (@gebruikersnaam, @email, @activatiehash, @wachtwoord, @voornaam, @achternaam, @telefoonnr, @geactiveerd)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@gebruikersnaam", account.Gebruikersnaam);
                    command.Parameters.AddWithValue("@email", account.Email);
                    command.Parameters.AddWithValue("@activatiehash", account.Activatiehash);
                    command.Parameters.AddWithValue("@wachtwoord", account.Wachtwoord);
                    command.Parameters.AddWithValue("@voornaam", account.Voornaam);
                    command.Parameters.AddWithValue("@achternaam", account.Achternaam);
                    command.Parameters.AddWithValue("@telefoonnr", account.Telefoonnr);
                    command.Parameters.AddWithValue("@geactiveerd", account.Geactiveerd);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                    return account;

                }

            }
        }

        public bool DeleteAccount(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {

                string query = "DELETE FROM Account WHERE ID=@id";

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

        public bool UpdateAccount(Account account)
        {
            using (SqlConnection connection = Database.Connection)
            {

                string query = "UPDATE Account SET Gebruikersnaam = @gebruikersnaam, Email = @email, Activatiehash = @activatiehash, Wachtwoord = @wachtwoord, Voornaam = @voornaam, Achternaam = @achternaam, Telefoonnr = @telefoonnr, Geactiveerd = @geactiveerd WHERE Id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@gebruikersnaam", account.Gebruikersnaam);
                    command.Parameters.AddWithValue("@email", account.Email);
                    command.Parameters.AddWithValue("@activatiehash", account.Activatiehash);
                    command.Parameters.AddWithValue("@wachtwoord", account.Wachtwoord);
                    command.Parameters.AddWithValue("@voornaam", account.Voornaam);
                    command.Parameters.AddWithValue("@achternaam", account.Achternaam);
                    command.Parameters.AddWithValue("@telefoonnr", account.Telefoonnr);
                    command.Parameters.AddWithValue("@geactiveerd", account.Geactiveerd);
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

        private Account CreateAccountFromReader(SqlDataReader reader)
        {
            return new Account(
                 Convert.ToInt32(reader["ID"]),
                 Convert.ToString(reader["Voornaam"]),
                 Convert.ToString(reader["Tussenvoegsel"]),
                 Convert.ToString(reader["Achternaam"]),
                 Convert.ToInt32(reader["Telefoonnummer"]),
                 Convert.ToString(reader["Gebruikersnaam"]),
                 Convert.ToString(reader["Wachtwoord"]),
                 Convert.ToString(reader["Email"]),
                 Convert.ToString(reader["Activatiehash"]),
                 Convert.ToInt32(reader["Geactiveerd"]));
        }
    }
}
