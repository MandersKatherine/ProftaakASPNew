using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Controllers
{
    public class LoginRepository
    {

        private readonly IAccountContext IAccountContext;

        public LoginRepository(IAccountContext accountContext)
        {
            IAccountContext = accountContext;
        }

        public Account Login(string email, string password)
        {
            return IAccountContext.Login(email, password);
        }


    }
}