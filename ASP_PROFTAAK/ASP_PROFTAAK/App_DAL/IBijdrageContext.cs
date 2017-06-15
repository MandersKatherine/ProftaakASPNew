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
        bool InsertBijdrage(int Accountid, string soort, string titel, string inhoud, int catId, string bestandloc, string catNaam);

        bool DeleteBijdrage(int id);

        bool UpdateBijdrageBericht(Bericht bericht);
        bool UpdateBijdrageBestand(Bestand bestand);
        List<Bijdrage> GetAllBijdrages();
        List<Categorie> GetAllCategories();
        bool Like(int BijdrageID, int AccountID);
        List<Reactie> GetAllReactiesByBijdrageID(int id);
        bool Report(int BijdrageID, int AccountID);
        bool AddReactie(string Tekst, int accountId, int postId);
        List<Bijdrage> GetAllReports();
        List<Like1> GetAllLikes();
    }
}