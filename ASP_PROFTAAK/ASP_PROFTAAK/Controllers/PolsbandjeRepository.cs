using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Controllers
{
    public class PolsbandjeRepository
    {
        private readonly IPolsbandjeContext context;

        public PolsbandjeRepository(IPolsbandjeContext context)
        {
            this.context = context;
        }

        public List<Polsbandje> GetAllPolsbandjes()
        {
            return context.GetAllPolsbandjes();
        }

        public List<Polsbandje> getPolsbandjesByReserveringID(int reserveringid)
        {
            return context.getPolsbandjesByReserveringID(reserveringid);
        }

        public Polsbandje InsertPolsbandje(Polsbandje polsbandje)
        {
            return context.InsertPolsbandje(polsbandje);
        }

        public bool DeletePolsbandje(int id)
        {
            return context.DeletePolsbandje(id);
        }

        public bool UpdatePolsbandje(Polsbandje polsbandje)
        {
            return context.UpdatePolsbandje(polsbandje);
        }

        public Polsbandje GetPolsbandjeById(decimal id)
        {
            return context.GetPolsbandjeById(id);
        }

        public Polsbandje GetEventByPolsbandjeId(int id)
        {
            return context.GetEventByPolsbandjeId(id);
        }
    }
}