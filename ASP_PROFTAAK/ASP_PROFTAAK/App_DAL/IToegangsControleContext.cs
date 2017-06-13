using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public interface IToegangsControleContext
    {
        List<Aanwezig> GetAllAanwezig();
        void ChangeAanwezigheid(decimal accountid);
        bool CheckBetaald(string barcode);
        void BrengPolsbandjeTerug(string barcode);
    }
}