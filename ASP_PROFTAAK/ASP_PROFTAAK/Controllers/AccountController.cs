using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_PROFTAAK.ActivatieHash;
using ASP_PROFTAAK.Email;

namespace ASP_PROFTAAK.Controllers
{
    public class AccountController : Controller
    {
        AccountRepository accountrepo = new AccountRepository(new AccountSQLContext());
        // GET: Account
        public ActionResult Index()
        {
            List<Account> account = new List<Account>();
            account = accountrepo.GetAllAccounts();
            return View(account);
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            Account account = accountrepo.GetAccountById(id);
            return View(account);
        }

        // GET: Account/Create
        // Account creëren voor activatiehash en mail
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Account account = new Account(collection["Voornaam"], collection["Tussenvoegsel"], collection["Achternaam"], Convert.ToInt32(collection["Telefoonnummer"]), collection["Gebruikersnaam"], collection["Wachtwoord"], collection["Email"], MD5.CreateMD5(collection["Email"]), 0);
            try
            {
                // TODO: Add insert logic here
                accountrepo.InsertAccount(account);
                Models.Email mail = new Models.Email("Activeer uw account", "inhoud", "dhrlaaboudi@gmail.com");
                //EmailLogic.SendEmail(mail);
                EmailLogic.SendEmailNew(mail, account.Activatiehash, account.Voornaam);

                return RedirectToAction("Create", "Account");
            }
            catch
            {
                throw;
                //return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Account account = new Account(collection["Voornaam"], collection["Tussenvoegsel"], collection["Achternaam"], Convert.ToInt32(collection["Telefoonnummer"]), collection["Gebruikersnaam"], collection["Wachtwoord"], collection["Email"]);
            try
            {
                // TODO: Add update logic here
                accountrepo.UpdateAccount(id, account);
                return RedirectToAction("Details","Account");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                accountrepo.DeleteAccount(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
