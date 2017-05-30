using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class EventController : Controller
    {
        EventRepository eventrepo = new EventRepository(new EventSQLContext());
        LocatieRepository locrepo = new LocatieRepository(new LocatieSQLContext());
        PlekRepository plekrepo = new PlekRepository(new PlekSQLContext());
        SpecificatieRepository specrepo = new SpecificatieRepository(new SpecificatieSQLContext());
        // GET: Event
        public ActionResult Index()
        {
            List<Event> events = eventrepo.GetAllEvents();
            return View(events);
        }

        //GET: EventView
       /* public ActionResult EventView()
        {
            List<Event> events = eventrepo.GetAllEvents();
            List<Locatie> locaties = locrepo.GetAllLocations();
            List<Plek> plekken = plekrepo.GetAll();
            List<Specificatie> specs = specrepo.GetAll();

            var viewModel = new EventViewModel
            {
                locatie = locaties,
                event1 = events,
                plek = plekken,
                spec = specs
            };
            return View(viewModel);
        }*/

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
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

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            Event eventdetails = eventrepo.GetByID(id);
            Locatie locatiedetails = locrepo.GetByEvent(eventdetails);
            var viewModel = new EventViewModel
            {
                locatie = locatiedetails,
                event1 = eventdetails,
                //plek = plekken,
                //spec = specs
            };
            return View(viewModel);
            
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            //Event updateEvent = new Event(Convert.ToInt32(collection["locatieid"]),collection[""]);
            return View();
            
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Event/Delete/5
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
