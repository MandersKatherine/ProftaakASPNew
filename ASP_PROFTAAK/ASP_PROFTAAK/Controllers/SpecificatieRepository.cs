using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class SpecificatieRepository
    {
        private ISpecificatieContext context;

        public SpecificatieRepository(ISpecificatieContext context)
        {
            this.context = context;
        }

        public List<Specificatie> GetAll()
        {
            return context.GetAll();
        }

        public bool DeletePlek(int id)
        {
            return context.DeleteSpecificatie(id);
        }

        public void InsertSpecificatie(Specificatie specificatie)
        {
            context.InsertSpecificatie(specificatie);
        }

        public bool UpdatePlek(Specificatie specificatie)
        {
            return context.UpdateSpecificatie(specificatie);
        }
    }
}