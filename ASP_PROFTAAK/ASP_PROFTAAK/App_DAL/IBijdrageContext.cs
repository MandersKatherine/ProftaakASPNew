using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public interface IBijdrageContext
    {

        List<Bericht> GetAllBerichts();

        Bijdrage GetByID(int ID);
        bool InsertBijdrage(Bijdrage bijdrage);

        bool DeleteBijdrage(int id);

        bool UpdateBijdrageBericht(Bericht bericht);
        bool UpdateBijdrageBestand(Bestand bestand);
        List<Bijdrage> GetAllBijdrages();
        List<Categorie> GetAllCategories();
        bool Like(int BijdrageID, int AccountID);

    }
}