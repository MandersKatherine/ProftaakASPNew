using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_PROFTAAK.Controllers
{
    public class ProductExemplaarController : Controller
    {

        productex
        // GET: ProductExemplaar
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductExemplaar/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductExemplaar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductExemplaar/Create
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

        // GET: ProductExemplaar/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductExemplaar/Edit/5
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

        // GET: ProductExemplaar/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductExemplaar/Delete/5
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
