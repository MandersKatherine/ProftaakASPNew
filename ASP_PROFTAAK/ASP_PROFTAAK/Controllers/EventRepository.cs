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

        public Event InsertEvent(Event events)
        {
            return context.InsertEvent(events);
        }

        public bool UpdateEvent(int id, Event events)
        {
            return context.UpdateEvent(id, events);
        }
        public Event GetEventById(int id)
        {
            return context.GetEventById(id);
        }

        public bool DeleteEvent(int id)
        {
            return context.DeleteEvent(id);
        }

        public bool DeleteLocatie(int id)
        {
            return context.DeleteLocatie(id);
        }

    }
}