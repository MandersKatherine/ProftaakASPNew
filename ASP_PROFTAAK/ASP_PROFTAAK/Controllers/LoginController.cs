using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_PROFTAAK.Controllers
{
    public class LoginController : Controller
    {
        LoginRepository loginrepo = new LoginRepository(new AccountSQLContext());

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            try
            {
                Account loggedInUser = loginrepo.Login(email, password);
                Session["Email"] = loggedInUser.Email;
                Session["UserId"] = loggedInUser.Id;
                return RedirectToAction("Index", "Home");


            }
            catch (Exception)
            {
                return View("Index");
            }

        }

        // GET: Login
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Product");
        }


    }
}
