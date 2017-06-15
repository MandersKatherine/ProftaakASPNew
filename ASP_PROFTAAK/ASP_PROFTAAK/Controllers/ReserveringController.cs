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
        AccountRepository accountrepo = new AccountRepository(new AccountSQLContext());
        GroepslidRepository groepslidrepo = new GroepslidRepository(new GroepslidSQLContext());

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

        //GET: Persoonlijke reservering
        public ActionResult Reservering()
        {
            List<Reservering> reservering = reserveringrepo.GetReserveringByAccountId(Convert.ToInt32(Session["UserId"]));

            return View(reservering);
        }

        // GET: Reservering/Details/5
        public ActionResult Details(decimal id)
        {
            newReservering = reserveringrepo.GetReserveringById(id);
            Session["isBetaald"] = newReservering.Betaald;
            newPersoon = persoonrepo.getHoofdboekerByReserveringId((decimal)newReservering.PersonId);
            plekken = plekrepo.GetPlekId(id);
            newPlek = plekrepo.GetPlekById(plekken);
            Plek plek = newPlek.First();
            newLocatie = locatierepo.GetLocatieById(plek.LocatieId);
            newEvent = eventrepo.GetEventById(newLocatie.Id);
            List<Groepslid> groepsleden = groepslidrepo.getGroepsledenByReserveringId(Convert.ToInt32(id));
            List<Account> groepPersonen = new List<Account>();
            foreach (Groepslid groepslid in groepsleden)
            {
                groepPersonen.Add(accountrepo.GetAccountById(groepslid.AccountId));
            }
            var viewmodel = new ReserveringViewModelELPRP()
            {
                events = newEvent,
                locatie = newLocatie,
                plekken = newPlek,
                reservering = newReservering,
                persoon = newPersoon,
                groepsleden = groepPersonen


            };
            return View(viewmodel);
        }

        // GET: Reservering/Create
        public ActionResult Create(int id, ReserveringMakenViewModel rmvm)
        {
            Event events = eventrepo.GetByID(id);
            List<Plek> plekken = plekrepo.GetPlekByEventId(id);

            var viewmodel = new ReserveringMakenViewModel()
            {
                events = events,
                plekken = plekken

            };


            return View(viewmodel);
        }

        // POST: Reservering/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            //variabelen om input te testen, kan weg nu

            //DateTime datumStart = Convert.ToDateTime(collection["events.DatumStart"]);
            //DateTime datumEinde = Convert.ToDateTime(collection["events.DatumEinde"]);
            //int accountId = Convert.ToInt32(Session["UserId"]);
            //int plekId = Convert.ToInt32(collection["plekId"]);
            //string voornaam = collection["voornaam"];
            //string tussenvoegsel = collection["tussenvoegsel"];
            //string achternaam = collection["achternaam"];
            //string straat = collection["straat"];
            //string huisnummer = collection["huisnummer"];
            //string woonplaats = collection["woonplaats"];
            //string banknummer = collection["banknummer"];


            // TODO: Add insert logic here

            reserveringrepo.CreateReservering(Convert.ToDateTime(collection["events.DatumStart"]), Convert.ToDateTime(collection["events.DatumEinde"]), 0, Convert.ToInt32(Session["UserId"]), 0, Convert.ToString(collection["plekId"]), collection["voornaam"], collection["tussenvoegsel"], collection["achternaam"], collection["straat"], collection["huisnummer"], collection["woonplaats"], collection["banknummer"]);
            return RedirectToAction("Reservering");



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

        //get:
        public ActionResult AddGroepslid(int id)
        {
            List<Account> accounts = accountrepo.GetAllAccountsBehalveIngelogdeAccount(Convert.ToInt32(Session["UserId"]));
            Reservering reservering = reserveringrepo.GetReserveringById(id);
            var viewmodel = new ReserveringMakenViewModel()
            {
                accounts = accounts,
                reservering = reservering

            };

            return View(viewmodel);
        }


        [HttpPost]
        public ActionResult AddGroepsLid(FormCollection collection)
        {
            string[] ids = collection["accountId"].Split(','); //geselecteerde ids ophalen van form
            foreach (string id in ids)
            {
                groepslidrepo.GeefPolsbandjeAf(Convert.ToInt32(id), Convert.ToInt32(collection["reserveringId"]));
            }
            return RedirectToAction("AddGroepsLid");
        }



        // GET: Reservering/Delete/5
        public ActionResult Delete(int id)
        {
            Reservering reservering = reserveringrepo.GetReserveringById(id);
            return View(reservering);
        }

        // POST: Reservering/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                reserveringrepo.DeleteReservering(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Betalen(FormCollection collection)
        {
            reserveringrepo.betaalReservering(Convert.ToInt32(collection["Betalen"]));
            return RedirectToAction("Index", "Reservering");
        }
    }
}
