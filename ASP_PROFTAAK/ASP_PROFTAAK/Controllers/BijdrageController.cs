using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class BijdrageController : Controller
    {
        BijdrageRepository bijdragerepo = new BijdrageRepository(new BijdrageSQLContext());
        AccountRepository accrepo = new AccountRepository(new AccountSQLContext());
        // GET: Bijdrage
        
        public ActionResult Index()
        {
            List<Bijdrage> bijdrages = bijdragerepo.GetAllBijdrages();
            List<Account> accounts = new List<Account>();
            
            var ViewModel = new BijdragePosterViewModel
            {
                Bedrijges = bijdragerepo.GetAllBijdrages(),
                Accounts = accounts
            };
            return View(ViewModel);
        }

  
        // GET: Bijdrage/Details
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bijdrage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bijdrage/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bijdrage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bijdrage/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bijdrage/Delete/5
        public ActionResult Delete(int id)
        {
            Bijdrage bijdrage = bijdragerepo.GetByID(id);
            return View(bijdrage);
        }

        // POST: Bijdrage/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                bijdragerepo.DeleteBijdrage(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Like(int AccountID, int BijdrageID)
        {
            bijdragerepo.Like(BijdrageID, AccountID);
            return RedirectToAction("Index", "Bijdrage");
        }
    }
}
