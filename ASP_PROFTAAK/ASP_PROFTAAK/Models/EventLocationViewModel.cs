using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class EventLocationViewModel
    {
        public List<Event> events { get; set; }
        public List<Locatie> locaties { get; set; }
        public Event Event { get; set; }
        public Locatie locatie { get; set; }
    
    }
}