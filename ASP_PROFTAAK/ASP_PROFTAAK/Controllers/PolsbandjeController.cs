using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_PROFTAAK.Controllers
{
    public class PolsbandjeController : Controller
    {
        PolsbandjeRepository polsrepo = new PolsbandjeRepository(new PolsbandjeSQLContext());
        EventRepository eventrepo = new EventRepository(new EventSQLContext());
        PlekRepository plekrepo = new PlekRepository(new PlekSQLContext());

        private List<Plek> newPlek = new List<Plek>();
        private Event newEvent;
        private List<Decimal> plekken = new List<Decimal>();

        // GET: Polsbandje
        public ActionResult Index()
        {
            List<Polsbandje> polsbandje = polsrepo.GetAllPolsbandjes();
            return View(polsbandje);
        }

        // GET: Polsbandje/Details/5
        public ActionResult Details(int id)
        {
            Polsbandje polsbandje = polsrepo.GetEventByPolsbandjeId(id);
            if (polsbandje != null)
            {
                return View(polsbandje);
            }
            else return HttpNotFound();


        }

        // GET: Polsbandje/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Polsbandje/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Polsbandje polsbandje = new Polsbandje(collection["Barcode"], Convert.ToDecimal(collection["Actief"]));
                polsrepo.InsertPolsbandje(polsbandje);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Polsbandje/Edit/5
        public ActionResult Edit(int id)
        {
            Polsbandje polsbandje = polsrepo.GetPolsbandjeById(id);
            if (polsbandje != null)
            {
                return View(polsbandje);
            }
            else return HttpNotFound();
        }

        // POST: Polsbandje/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Polsbandje polsbandje = new Polsbandje(collection["Barcode"], Convert.ToDecimal(collection["Actief"]));
            try
            {
                // TODO: Add update logic here

                polsrepo.UpdatePolsbandje(polsbandje);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Polsbandje/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Polsbandje/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                polsrepo.DeletePolsbandje(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
