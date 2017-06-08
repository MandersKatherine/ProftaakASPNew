using ASP_PROFTAAK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.App_DAL;

namespace ASP_PROFTAAK.Controllers
{
    public class AccountRepository
    {
        private IAccountContext context;

        public AccountRepository(IAccountContext context)
        {
            this.context = context;
        }

        public List<Account> GetAllAccounts()
        {
            return context.GetAllAccounts();
        }

        public Account InsertAccount(Account account)
        {
            return context.InsertAccount(account);
        }

        public bool UpdateAccount(int id, Account account)
        {
            return context.UpdateAccount(id, account);
        }

        public bool DeleteAccount(int id)
        {
            return context.DeleteAccount(id);
        }
        public Account GetAccountById(int id)
        {
            return context.GetAccountById(id);
        }

        public List<Account> GetAllAccountsBehalveIngelogdeAccount(int loggedInAccountId)
        {
            return context.GetAllAccountsBehalveIngelogdeAccount(loggedInAccountId);
        }



    }
}