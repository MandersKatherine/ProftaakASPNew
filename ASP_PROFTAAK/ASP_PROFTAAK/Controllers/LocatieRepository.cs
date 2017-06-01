using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK
{
    public class LocatieRepository
    {
        private ILocatieContext context; 
        public LocatieRepository(ILocatieContext context)
        {
            this.context = context; 
        }

        public Locatie GetByEvent(Event eEvent)
        {
            return context.GetbyEvent(eEvent);
        }

        public List<Locatie> GetAllLocations()
        {
            return context.GetAllLocations(); 
        }

        public Locatie InsertLocatie(Locatie locatie)
        {
            return context.InsertLocatie(locatie);
        }

        public bool DeleteLocatie(int id)
        {
            return context.DeleteLocatie(id); 
        }

        public bool UpdateLocatie(Locatie locatie)
        {
            return context.UpdateLocatie(locatie); 
        }
        public Locatie GetLocatieById(int id)
        {
            return context.GetLocatieById(id);
        }
    }
}