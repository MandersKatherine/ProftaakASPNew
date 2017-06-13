using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class BijdrageRepository
    {
        private IBijdrageContext context;

        public BijdrageRepository(IBijdrageContext context)
        {
            this.context = context; 
        }

        public List<Categorie> GetAllCategories()
        {
            return context.GetAllCategories();
        }
        public List<Bericht> GetAllBerichts()
        {
            return context.GetAllBerichts();
        }

        public bool InsertBijdrage(Bijdrage bijdrage)
        {
            return context.InsertBijdrage(bijdrage);
        }

        public bool DeleteBijdrage(int ID)
        {
            return context.DeleteBijdrage(ID);
        }

        public Bijdrage GetByID(int ID)
        {
            return context.GetByID(ID); 
        }

        public bool UpdateBijdrageBericht(Bericht bericht)
        {
            return context.UpdateBijdrageBericht(bericht);
        }

        public bool UpdateBijdrageBestand(Bestand bestand)
        {
            return context.UpdateBijdrageBestand(bestand);
        }

        public List<Bijdrage> GetAllBijdrages()
        {
            return context.GetAllBijdrages();
        }

        public bool Like(int Bijdrageid, int Accountid)
        {
            return context.Like(Bijdrageid, Accountid);
        }
    }
}