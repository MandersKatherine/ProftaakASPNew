using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class VerhuurController : Controller
    {
        // GET: Verhuur
        VerhuurRepository vr = new VerhuurRepository(new VerhuurSqlContext());
        public ActionResult Index()
        {
            List<Verhuurd> verhuurd = vr.GetAllVerhuurd();
            return View(verhuurd);
        }

        // GET: Verhuur/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Verhuur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Verhuur/Create
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

        // GET: Verhuur/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Verhuur/Edit/5
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

        // GET: Verhuur/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Verhuur/Delete/5
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
