using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class ToegangController : Controller
    {
        ToeganRepository tr = new ToeganRepository(new ToegansSqlContext());
        // GET: Toegang
        public ActionResult Index()
        {
            List<Aanwezig> aanwezigen = tr.GetAllAanwezig();
           
            return View(aanwezigen);
        }

        // GET: Toegang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Toegang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Toegang/Create
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

        // GET: Toegang/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Toegang/Edit/5
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

        // GET: Toegang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Toegang/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
