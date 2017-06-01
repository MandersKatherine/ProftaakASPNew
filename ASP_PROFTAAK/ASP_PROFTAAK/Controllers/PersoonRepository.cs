using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class PersoonRepository
    {
        private IPersoonContext context;

        public PersoonRepository(IPersoonContext context)
        {
            this.context = context;
        }

        public List<Persoon> GetAllPersonen()
        {
            return context.GetAllPersonen();
        }

        public Persoon InsertPersoon(Persoon persoon)
        {
            return context.InsertPersoon(persoon);
        }

        public bool UpdatePersoon(Persoon persoon)
        {
            return context.UpdatePersoon(persoon);
        }

        public bool DeletePersoon(decimal id)
        {
            return context.DeletePersoon(id);
        }

        public Persoon getHoofdboekerByReserveringId(decimal id)
        {
            return context.getHoofdboekerByReserveringId(id);
        }
    }
}