using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASP_PROFTAAK.App_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP_PROFTAAK.Controllers;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAKTests
{
    [TestClass]
    public class AccountSQLContextTests
    {
        AccountRepository repository = new AccountRepository(new AccountSQLContextTest());

        [TestMethod()]
        public void AccountListTest()
        {
            List<Account> accountlist = repository.GetAllAccounts();
            Account account = new Account(5, "Hicham", "vd", "Laaboudi", 0654533, "Heikum", "1234",
               "dhrlaaboudi@gmail.com", "23fsafd34", 1);
            accountlist.Add(account);
            Account[] accountlijst = accountlist.ToArray();
            Assert.AreEqual(5, accountlijst[0].Id);
        }



        private class AccountSQLContextTest : IAccountContext
        {
            private List<Account> accounts;

            public AccountSQLContextTest()
            {
                accounts = new List<Account>()
                {
                    new Account(5, "Hicham", "vd", "Laaboudi", 0654533, "Heikum", "1234", "dhrlaaboudi@gmail.com", "23fsafd34", 1),
                    new Account(5, "Sandertje", "vd", "Enden", 065443533, "Sanderboy", "1234", "Sanderr@gmail.com", "23wefsafd34", 0),
                    new Account(3, "Davey", "vd", "Bogaard", 0654654533, "Davekiller1", "1234", "Daveboy@gmail.com", "23fsqweafd34", 1)
                };
            }

            public List<Account> GetAllAccounts()
            {
                return accounts; 
            }

            public Account InsertAccount(Account account)
            {
                throw new NotImplementedException();
            }

            public bool DeleteAccount(int id)
            {
                throw new NotImplementedException();
            }

            public bool UpdateAccount(int id, Account account)
            {
                throw new NotImplementedException();
            }

            public bool Login(string email, string password)
            {
                throw new NotImplementedException();
            }

            public Account GetAccountById(int id)
            {
                throw new NotImplementedException();
            }

            public List<Account> GetAllAccountsBehalveIngelogdeAccount(int loggedInAccountId)
            {
                throw new NotImplementedException();
            }

            public bool CheckHash(int ID, string hash)
            {
                throw new NotImplementedException();
            }

            public bool ActivateAccount(int ID)
            {
                throw new NotImplementedException();
            }

            public bool GetActivationStatus(int ID)
            {
                throw new NotImplementedException();
            }

            public int GetaccountId(string username)
            {
                throw new NotImplementedException();
            }
        }
    }
}
