using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_PROFTAAK.Controllers
{
    public class PlekController : Controller
    {
        // GET: Plek
        public ActionResult Index()
        {
            return View();
        }

        // GET: Plek/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Plek/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plek/Create
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

        // GET: Plek/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Plek/Edit/5
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

        // GET: Plek/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Plek/Delete/5
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
