using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class ReserveringController : Controller
    {
        ReserveringRepository reserveringrepo = new ReserveringRepository(new ReserveringSQLContext());
        PlekRepository plekrepo = new PlekRepository(new PlekSQLContext());
        LocatieRepository locatierepo = new LocatieRepository(new LocatieSQLContext());
        EventRepository eventrepo = new EventRepository(new EventSQLContext());
        PersoonRepository persoonrepo = new PersoonRepository(new PersoonSQLContext());

        private Reservering newReservering;
        private List<Plek> newPlek = new List<Plek>();
        private Locatie newLocatie;
        private Event newEvent;
        private Persoon newPersoon;
        private List<Decimal> plekken = new List<Decimal>();
        // GET: Reservering                                               
        public ActionResult Index()
        {
            List<Reservering> reserveringen = reserveringrepo.GetAllReserveringen();
            return View(reserveringen);
        }
        
        // GET: Reservering/Details/5
        public ActionResult Details(decimal id)
        {
            newReservering = reserveringrepo.GetReserveringById(id);
            newPersoon = persoonrepo.getHoofdboekerByReserveringId((decimal)newReservering.PersonId);
            plekken = plekrepo.GetPlekId(id);     
            newPlek = plekrepo.GetPlekById(plekken);
            Plek plek = newPlek.First();
            newLocatie = locatierepo.GetLocatieById(plek.LocatieId);
            newEvent = eventrepo.GetEventById(newLocatie.Id);

            var viewmodel = new ReserveringViewModelELPRP()
            {
                events = newEvent,
                locatie = newLocatie,
                plekken = newPlek,
                reservering = newReservering,
                persoon = newPersoon

            };
                return View(viewmodel);
        }

        // GET: Reservering/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservering/Create
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

        // GET: Reservering/Edit/5
        public ActionResult Edit(decimal id)
        {
            return View();
        }

        // POST: Reservering/Edit/5
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

        // GET: Reservering/Delete/5
        public ActionResult Delete(decimal id)
        {
            return View();
        }

        // POST: Reservering/Delete/5
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
