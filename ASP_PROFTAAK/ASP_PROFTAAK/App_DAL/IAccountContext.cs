using ASP_PROFTAAK.Models;
using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_PROFTAAK.App_DAL
{
    public interface IAccountContext
    {
        List<Account> GetAllAccounts();

        Account InsertAccount(Account account);

        bool DeleteAccount(int id);

        bool UpdateAccount(int id, Account account);
        bool Login(string email, string password);
        Account GetAccountById(int id);
        List<Account> GetAllAccountsBehalveIngelogdeAccount(int loggedInAccountId);
        bool CheckHash(int ID, string hash);
        bool ActivateAccount(int ID);
        bool GetActivationStatus(int ID);
        int GetaccountId(string username);

    }
}
