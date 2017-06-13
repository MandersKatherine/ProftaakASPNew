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
        private Account account;
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

        public List<Account> GetAllAccountsBehalveIngelogdeAccount(int loggedInAccountId)
        {
            List<Account> accounts = new List<Account>();
            using (SqlConnection connection = Database.Connection)
            {

                string query = "SELECT * FROM Account where id not like @loggedInAccountId ORDER BY ID";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("loggedInAccountId", loggedInAccountId);

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
        public Account GetAccountById(int id)
        {
            
            using (SqlConnection connection = Database.Connection)
            {

                string query = "SELECT * FROM Account WHERE ID = @id";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            account = CreateAccountFromReader(reader);
                            return account;
                        }
                    }
                }
            }
            return account;
        }
        public bool Login(string email, string password)
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
                                //Account account = CreateAccountFromReader(reader);
                                return true;
                            }
                        }
                        

                    
                }

            }
            return false;
        }


        public bool GetActivationStatus(int ID)
        {
            using (SqlConnection connectie = Database.Connection)
            {
                SqlCommand cmd1 = new SqlCommand(@"select geactiveerd from Account where ID = @id;",
                    connectie);
                cmd1.Parameters.AddWithValue("@id", ID);
                int status = Convert.ToInt32(cmd1.ExecuteScalar());
                if (status == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //activeerd account door geactiveerd op een te zetten
        public bool ActivateAccount(int ID)
        {
            using (SqlConnection connectie = Database.Connection)
            {
                SqlCommand cmd1 =
                    new SqlCommand(
                        @"update Account set geactiveerd = 1 where ID = @id;",
                        connectie);
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = connectie;
                cmd1.Parameters.AddWithValue("@id", ID);
                cmd1.ExecuteNonQuery();
                return true;
            }
        }

        public bool CheckHash(int ID, string hash)
        {
            using (SqlConnection connectie = Database.Connection)
            {
                SqlCommand cmd1 = new SqlCommand(@"select activatiehash from Account where ID = @id;",
                    connectie);
                cmd1.Parameters.AddWithValue("@id", ID);
                string foundhash = (string)cmd1.ExecuteScalar();
                if (foundhash == hash)
                {
                    ActivateAccount(ID);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public int GetaccountId(string email)
        {
            int accountID;
            using (SqlConnection connectie = Database.Connection)
            {
                SqlCommand cmd1 = new SqlCommand(@"SELECT ID FROM Account WHERE email=@email;",
                    connectie);
                cmd1.Parameters.AddWithValue("@email", email);
                accountID = Convert.ToInt32(cmd1.ExecuteScalar());
                return accountID;
            }
        }


        public Account InsertAccount(Account account)
        {
            using (SqlConnection connection = Database.Connection)
            {

                string query = "INSERT INTO Account (gebruikersnaam, email, activatiehash, wachtwoord, voornaam, tussenvoegsel, achternaam, telefoonnummer, geactiveerd)" +
               
                        "VALUES (@gebruikersnaam, @email, @activatiehash, @wachtwoord, @voornaam, @tussenvoegsel, @achternaam, @telefoonnr, @geactiveerd)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@gebruikersnaam", account.Gebruikersnaam);
                    command.Parameters.AddWithValue("@tussenvoegsel", account.Tussenvoegsel);
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
                        throw;
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

        public bool UpdateAccount(int id, Account account)
        {
            using (SqlConnection connection = Database.Connection)
            {


                string query = "UPDATE ACCOUNT SET Gebruikersnaam = @gebruikersnaam, Email = @email, Wachtwoord = @wachtwoord, Voornaam = @voornaam, Tussenvoegsel = @tussenvoegsel, Achternaam = @achternaam, Telefoonnummer = @telefoonnummer WHERE Id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@gebruikersnaam", account.Gebruikersnaam);
                    command.Parameters.AddWithValue("@email", account.Email);
                    command.Parameters.AddWithValue("@wachtwoord", account.Wachtwoord);
                    command.Parameters.AddWithValue("@voornaam", account.Voornaam);
                    command.Parameters.AddWithValue("@tussenvoegsel", account.Tussenvoegsel);
                    command.Parameters.AddWithValue("@achternaam", account.Achternaam);
                    command.Parameters.AddWithValue("@telefoonnr", account.Telefoonnr);
                    command.Parameters.AddWithValue("@id", id);
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


        public bool UpdatePersonalAccount(int id, Account account)
        {
            using (SqlConnection connection = Database.Connection)
            {


                string query = "UPDATE ACCOUNT SET Gebruikersnaam = @gebruikersnaam, Email = @email, Wachtwoord = @wachtwoord, Voornaam = @voornaam, Tussenvoegsel = @tussenvoegsel, Achternaam = @achternaam, Telefoonnummer = @telefoonnummer WHERE Id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@gebruikersnaam", account.Gebruikersnaam);
                    command.Parameters.AddWithValue("@email", account.Email);
                    command.Parameters.AddWithValue("@wachtwoord", account.Wachtwoord);
                    command.Parameters.AddWithValue("@voornaam", account.Voornaam);
                    command.Parameters.AddWithValue("@tussenvoegsel", account.Tussenvoegsel);
                    command.Parameters.AddWithValue("@achternaam", account.Achternaam);
                    command.Parameters.AddWithValue("@telefoonnr", account.Telefoonnr);
                    command.Parameters.AddWithValue("@id", id);
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
            if (Convert.ToString(reader["Voornaam"]) != null && Convert.ToString(reader["Tussenvoegsel"]) != null && Convert.ToString(reader["Achternaam"]) != null)
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
            else if (Convert.ToString(reader["Voornaam"]) != null && Convert.ToString(reader["Tussenvoegsel"]) != null)
            {
                return new Account(
                     Convert.ToInt32(reader["ID"]),
                     Convert.ToString(reader["Voornaam"]),
                     Convert.ToString(reader["Tussenvoegsel"]),
                     "No Last name",
                     Convert.ToInt32(reader["Telefoonnummer"]),
                     Convert.ToString(reader["Gebruikersnaam"]),
                     Convert.ToString(reader["Wachtwoord"]),
                     Convert.ToString(reader["Email"]),
                     Convert.ToString(reader["Activatiehash"]),
                     Convert.ToInt32(reader["Geactiveerd"]));
            }
            else if (Convert.ToString(reader["Voornaam"]) != null && Convert.ToString(reader["Wachtwoord"]) != null)
            {
                return new Account(
                     Convert.ToInt32(reader["ID"]),
                     Convert.ToString(reader["Voornaam"]),
                     "No Insertion",
                     Convert.ToString(reader["Wachtwoord"]),
                     Convert.ToInt32(reader["Telefoonnummer"]),
                     Convert.ToString(reader["Gebruikersnaam"]),
                     Convert.ToString(reader["Wachtwoord"]),
                     Convert.ToString(reader["Email"]),
                     Convert.ToString(reader["Activatiehash"]),
                     Convert.ToInt32(reader["Geactiveerd"]));
            }
            else if (Convert.ToString(reader["Tussenvoegsel"]) != null && Convert.ToString(reader["Wachtwoord"]) != null)
            {
                return new Account(
                     Convert.ToInt32(reader["ID"]),
                     "No First Name",
                     Convert.ToString(reader["Tussenvoegsel"]),
                     Convert.ToString(reader["Wachtwoord"]),
                     Convert.ToInt32(reader["Telefoonnummer"]),
                     Convert.ToString(reader["Gebruikersnaam"]),
                     Convert.ToString(reader["Wachtwoord"]),
                     Convert.ToString(reader["Email"]),
                     Convert.ToString(reader["Activatiehash"]),
                     Convert.ToInt32(reader["Geactiveerd"]));
            }
            else if (Convert.ToString(reader["Voornaam"]) != null)
            {
                return new Account(
                     Convert.ToInt32(reader["ID"]),
                     Convert.ToString(reader["Voornaam"]),
                     "No Insertion",
                     "No Last Name",
                     Convert.ToInt32(reader["Telefoonnummer"]),
                     Convert.ToString(reader["Gebruikersnaam"]),
                     Convert.ToString(reader["Wachtwoord"]),
                     Convert.ToString(reader["Email"]),
                     Convert.ToString(reader["Activatiehash"]),
                     Convert.ToInt32(reader["Geactiveerd"]));
            }
            else if (Convert.ToString(reader["Tussenvoegsel"]) != null)
            {
                return new Account(
                     Convert.ToInt32(reader["ID"]),
                     "No First Name",
                     Convert.ToString(reader["Tussenvoegsel"]),
                     "No Last Name",
                     Convert.ToInt32(reader["Telefoonnummer"]),
                     Convert.ToString(reader["Gebruikersnaam"]),
                     Convert.ToString(reader["Wachtwoord"]),
                     Convert.ToString(reader["Email"]),
                     Convert.ToString(reader["Activatiehash"]),
                     Convert.ToInt32(reader["Geactiveerd"]));
            }
            else if (Convert.ToString(reader["Wachtwoord"]) != null)
            {
                return new Account(
                     Convert.ToInt32(reader["ID"]),
                     "No Insertion",
                     "No Last Name",
                     Convert.ToString(reader["Achternaam"]),
                     Convert.ToInt32(reader["Telefoonnummer"]),
                     Convert.ToString(reader["Gebruikersnaam"]),
                     Convert.ToString(reader["Wachtwoord"]),
                     Convert.ToString(reader["Email"]),
                     Convert.ToString(reader["Activatiehash"]),
                     Convert.ToInt32(reader["Geactiveerd"]));
            
            }
            else return new Account(
                     Convert.ToInt32(reader["ID"]),
                     "No First Name",
                     "No Insertion",
                     "No Last Name",
                     Convert.ToInt32(reader["Telefoonnummer"]),
                     Convert.ToString(reader["Gebruikersnaam"]),
                     Convert.ToString(reader["Wachtwoord"]),
                     Convert.ToString(reader["Email"]),
                     Convert.ToString(reader["Activatiehash"]),
                     Convert.ToInt32(reader["Geactiveerd"]));

        }
    }
}
