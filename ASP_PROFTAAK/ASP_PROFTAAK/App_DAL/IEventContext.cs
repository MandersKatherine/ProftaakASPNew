﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public interface IEventContext
    {
        List<Event> GetAllEvents();

        Event GetById(int id);

        Event InsertEvent(Event events);

        bool UpdateEvent(Event events);
        Event GetEventById(int id);
    }
}