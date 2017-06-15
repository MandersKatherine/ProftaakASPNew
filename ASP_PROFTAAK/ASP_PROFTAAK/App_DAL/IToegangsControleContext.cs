using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public interface IToegangsControleContext
    {
        List<Aanwezig> GetAllAanwezig(int eventid);
        void ChangeAanwezigheid(int eventid, string barcode);
        bool CheckBetaald(string barcode);
        void BrengPolsbandjeTerug(string barcode);
    }
}