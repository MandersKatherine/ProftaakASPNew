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
            List<Categorie> categories = bijdragerepo.GetAllCategories();
            /*List<Account> accounts = new List<Account>();*/
            
            var ViewModel = new BijdragePosterViewModel
            {
                Bedrijges = bijdragerepo.GetAllBijdrages(),
                Categories = categories
            };
            return View(ViewModel);
        }
        //Is het slim om hier door de modal alle mogelijke variabele door te laten sturen en dan door middel van if'jes het juiste pad te kiezen
        public ActionResult AddBijdrage(string Titel,string Inhoud)
        {
            try
            {
                //bijdragerepo.InsertBijdrage();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
            
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
