using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class ToeganRepository
    {
        private IToegangsControleContext context;

        public ToeganRepository(IToegangsControleContext context)
        {
            this.context = context;
        }

        public List<Aanwezig> GetAllAanwezig(int eventid)
        {
            return context.GetAllAanwezig(eventid);
        }

        public void ChangeAanwezigheid(int eventid, string barcode)
        {
            context.ChangeAanwezigheid(eventid, barcode);
        }

        public bool CheckBetaald(string barcode)
        {
            return context.CheckBetaald(barcode);
        }

        public void BrengPolsbandjeTerug(string barcode)
        {
            context.BrengPolsbandjeTerug(barcode);
        }
    }
}