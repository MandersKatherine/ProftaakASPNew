using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_PROFTAAK.Controllers
{
    public class PersoonController : Controller
    {
        // GET: Persoon
        public ActionResult Index()
        {
            return View();
        }

        // GET: Persoon/Details/5
        public ActionResult Details(decimal id)
        {
            return View();
        }

        // GET: Persoon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persoon/Create
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

        // GET: Persoon/Edit/5
        public ActionResult Edit(decimal id)
        {
            return View();
        }

        // POST: Persoon/Edit/5
        [HttpPost]
        public ActionResult Edit(decimal id, FormCollection collection)
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

        // GET: Persoon/Delete/5
        public ActionResult Delete(decimal id)
        {
            return View();
        }

        // POST: Persoon/Delete/5
        [HttpPost]
        public ActionResult Delete(decimal id, FormCollection collection)
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
