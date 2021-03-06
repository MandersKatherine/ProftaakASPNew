﻿using ASP_PROFTAAK.App_DAL;
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
        AccountRepository accountrepo = new AccountRepository(new AccountSQLContext());

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {

            if (Request.Form["login"] != null)
            {
                Account loggedInUser = new Account(email, password);
                int ID = accountrepo.GetaccountId(loggedInUser.Email);

                if (loginrepo.Login(email, password) == true && accountrepo.CheckActivationStatus(ID) == true)
                {
                    Session["Email"] = loggedInUser.Email;
                    Session["UserId"] = ID;
                    Session["UserName"] = accountrepo.GetAccountById(ID).Gebruikersnaam;
                    return RedirectToAction("Index", "Home");

                }
                else if (loginrepo.Login(email, password) == true && accountrepo.CheckActivationStatus(ID) == false)
                {
                    TempData["NotActivated"] = "NotActivated";
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    TempData["Login"] = "Wrong login";
                    return RedirectToAction("Index", "Login");
                }

            }
            if (Request.Form["activate"] != null)
            {

                return RedirectToAction("Activate", "Account");

            }
            return RedirectToAction("Index");
        }

        // GET: Login
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }


    }
}
