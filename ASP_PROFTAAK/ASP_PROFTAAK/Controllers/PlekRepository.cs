using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class PlekRepository
    {
        private IPlekContext context;

        public PlekRepository(IPlekContext context)
        {
            this.context = context;
        }

        public List<Plek> GetAll()
        {
            return context.GetAll();
        }

        public bool DeletePlek(int id)
        {
            return context.DeletePlek(id);
        }

        

        public bool UpdatePlek(Plek plek)
        {
            return context.UpdatePlek(plek);
        }
        public List<Decimal> GetPlekId(decimal id)
        {
            return context.GetPlekId(id);
        }
        public List<Plek> GetPlekById(List<decimal> id)
        {
            return context.GetPlekById(id);
        }

        public List<Plek> GetPlekByEventId(int eventId)
        {
            return context.GetPlekByEventId(eventId);
        }

        public Plek InsertPlek(Plek plek)
        {
            return context.InsertPlek(plek);
        }

        public List<Plek> GetPlekByLocatieId(int locatieId)
        {
            return context.GetPlekByLocatieId(locatieId);
        }

        public Plek GetPlekById(int id)
        {
            return context.GetPlekById(id);
        }



}
}