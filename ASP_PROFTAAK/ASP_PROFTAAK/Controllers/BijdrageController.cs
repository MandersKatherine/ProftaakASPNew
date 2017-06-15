using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;
using Microsoft.Ajax.Utilities;

namespace ASP_PROFTAAK.Controllers
{
    public class BijdrageController : Controller
    {
        BijdrageRepository bijdragerepo = new BijdrageRepository(new BijdrageSQLContext());
        AccountRepository accrepo = new AccountRepository(new AccountSQLContext());

       
        // GET: Bijdrage

        public ActionResult Index()
        {
           /* ViewModel.Bedrijges = bijdragerepo.GetAllBijdrages();
            ViewModel.Categories = bijdragerepo.GetAllCategories();
            List<Account> accounts = new List<Account>();*/
            
            var ViewModel = new BijdragePosterViewModel
            {
                Bedrijges = bijdragerepo.GetAllBijdrages(),
                Categories = bijdragerepo.GetAllCategories()
            };
            return View(ViewModel);
        }

        public ActionResult AddBijdrage(string Titel,string Inhoud, string soort, string bestandslocatie, string catNaam)
        {
                int accid = (int)Session["UserID"];
                bijdragerepo.InsertBijdrage(accid, soort, Titel, Inhoud, 9, bestandslocatie, catNaam);
                return RedirectToAction("Index");
         }

        public ActionResult AddCategorie()
        {
            var ViewModel = new BijdragePosterViewModel
            {
                Categories = bijdragerepo.GetAllCategories()
            };
            return View(ViewModel);
        }

        public ActionResult AddBericht()
        {
            var ViewModel = new BijdragePosterViewModel
            {
                Categories = bijdragerepo.GetAllCategories()
            };
            return View(ViewModel);
        }
        public ActionResult AddBestand()
        {
            var ViewModel = new BijdragePosterViewModel
            {
                Categories = bijdragerepo.GetAllCategories()
            };
            return View(ViewModel);
        }
        public ActionResult VerwijderBijdrage(int id)
        {
            bijdragerepo.DeleteBijdrage(id);
            return RedirectToAction("Index");
        }
        public ActionResult LoadBerichtenByPostId(int id)
        {
              
            try
            {
                //Account account = (Account)(Session["user"]);
                //accrepo.GetById(account.Id);
                //List<Bericht> berichtenList = repository.LoadBerichtenByPostId(id);
                //System.Threading.Thread.Sleep(2500);
                BijdragePosterViewModel bvm = new BijdragePosterViewModel() { Reacties = bijdragerepo.GetAllReactiesByBijdrageID(id)};
                if (bvm.Reacties.Count == 0)
                {
                    return PartialView("NoComments");
                }
                else
                {
                    return PartialView("Comments",bvm);

                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [HttpPost]
        public ActionResult AddReactie(int postid,string tekst)
        {
            try
            {
                int accid = (int) Session["UserID"];
                if (tekst.IsNullOrWhiteSpace())
                {
                    return PartialView("MisluktRea");
                }
                    bijdragerepo.AddReactie(tekst, accid, postid);
                    return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return PartialView("MisluktRea");
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

        public ActionResult Report(int AccountID, int BijdrageID)
        {
            bijdragerepo.Report(BijdrageID, AccountID);
            return RedirectToAction("Index");
        }

        public ActionResult Reports()
        {
            List<Bijdrage> bijdrages = bijdragerepo.GetAllReports();
            return View(bijdrages);
        }
    }
}
