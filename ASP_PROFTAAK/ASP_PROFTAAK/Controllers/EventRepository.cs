using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class EventRepository
    {
        private IEventContext context;

        public EventRepository(IEventContext context)
        {
            this.context = context;
        }

        public List<Event> GetAllEvents()
        {
            return context.GetAllEvents();
        }

        public Event GetByID(int id)
        {
            return context.GetById(id);
        }
    }
}