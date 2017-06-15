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
            List<Locatie> locaties = new List<Locatie>();
            foreach (Event item in events)
            {
                locaties.Add(locrepo.GetByEvent(item));
            }
            var viewmodel = new EventLocationViewModel()
            {
                events = events,
                locaties = locaties
            };
            return View(viewmodel);
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
            Event events = eventrepo.GetByID(id);
            //Locatie locatie1 = locrepo.GetByEvent(events);
            var Viewmodel = new EventViewModel()
            {
                event1 = events,
                //locatie = locatie1
            };
            if (events != null)
            {
                return View(Viewmodel);
            }
            else return HttpNotFound();
        }


        public ActionResult Locaties()
        {
            List<Locatie> locaties = locrepo.GetAllLocations();
            return View(locaties);
        }


        // GET: Event/Create
        public ActionResult Create()
        {
            Event events = new Event();
            List<Locatie> locaties = locrepo.GetAllLocations();
            List<SelectListItem> locatieItems = new List<SelectListItem>();

            foreach (Locatie locatie in locaties)
            {
                locatieItems.Add(new SelectListItem { Text = locatie.Naam, Value = Convert.ToString(locatie.Id) });
            }


            ViewBag.category = locatieItems;
            ViewData["locatie"] = new SelectList(locrepo.GetAllLocations(), "Id", "Naam");

            return View(events);

        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) //validation fixen, de requireds in de event model werken niet
        {

            // TODO: Add insert logic here
            ViewData["locatie"] = new SelectList(locrepo.GetAllLocations(), "Id", "Naam");// nog een keer lijst aanroepen anders vind de view de viewdata niet

            string locatie = Request.Form["locatie"].ToString();

            if (string.IsNullOrEmpty(locatie))
            {
                Event events = new Event(0, collection["Naam"], Convert.ToDateTime(collection["DatumStart"]), Convert.ToDateTime(collection["DatumEinde"]), Convert.ToInt32(collection["MaxBezoekers"]));
                if (ModelState.IsValid)
                {
                    eventrepo.InsertEvent(events);
                    return RedirectToAction("Index");

                }
            }
            else
            {
                int locatieId = Convert.ToInt32(locatie);
                Event events = new Event(locatieId, collection["Naam"], Convert.ToDateTime(collection["DatumStart"]), Convert.ToDateTime(collection["DatumEinde"]), Convert.ToInt32(collection["MaxBezoekers"]));
                if (ModelState.IsValid)
                {
                    eventrepo.InsertEvent(events);
                    return RedirectToAction("Index");

                }
            }





            return View();





        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            Event events = eventrepo.GetByID(id);
            if (events != null)
            {
                return View(events);
            }
            else return HttpNotFound();

        }



        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Event events = new Event(Convert.ToInt32(collection["locatie_id"]), collection["Naam"], Convert.ToDateTime(collection["datumStart"]), Convert.ToDateTime(collection["datumEinde"]), Convert.ToInt32(collection["maxBezoekers"]));
            try
            {
                // TODO: Add update logic here

                eventrepo.UpdateEvent(id, events);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditLocatie(int id)
        {
            Locatie locaties = locrepo.GetLocatieById(id);
            if (locaties != null)
            {
                return View(locaties);
            }
            else return HttpNotFound();
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            Event events = eventrepo.GetByID((id));
            return View(events);
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                eventrepo.DeleteEvent((id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Get locatie
        public ActionResult AddLocation()
        {

            return View();
        }

        [HttpPost]
        //post AddLocatie with plekken
        public ActionResult AddLocation(FormCollection collection)
        {
            Locatie locatie = new Locatie(collection["locatie.Naam"], collection["locatie.Straat"], collection["locatie.Nummer"], collection["locatie.Postcode"], collection["locatie.Plaats"]);
            int plekAmount = Convert.ToInt32(collection["plekAmount"]);
            locrepo.InsertLocatie(locatie);

            int lastInsertedLocationId = locrepo.GetLocatieId();


            for (int i = 1; i <= plekAmount; i++)//voor het ingegeven aantal plekken genereren
            {
                int x = 1;//huisnummers
                Plek plek = new Plek(lastInsertedLocationId, Convert.ToString(x), 0);
                plekrepo.InsertPlek(plek);
                x++;
            }

            return RedirectToAction("Locaties");
        }

        //get
        public ActionResult EditPlekken(int id)
        {

            if (id != 0)
            {
                List<Plek> plekken = plekrepo.GetPlekByLocatieId(id);
                return View(plekken);
            }
            else
            {
                int lastInsertedLocationId = locrepo.GetLocatieId();
                List<Plek> plekken = plekrepo.GetPlekByLocatieId(lastInsertedLocationId);
                return View(plekken);
            }

        }

        [HttpPost]
        public ActionResult EditPlekken(List<Plek> plekken)
        {
            foreach (Plek nieuwePlek in plekken)
            {
                Plek plek = plekrepo.GetPlekById(nieuwePlek.ID);
                plek.ID = nieuwePlek.ID;
                plek.LocatieId = nieuwePlek.LocatieId;
                plek.Nummer = nieuwePlek.Nummer;
                plek.Capaciteit = nieuwePlek.Capaciteit;
                plekrepo.UpdatePlek(plek);
            }

            return RedirectToAction("Index");
        }


    }
}
