using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class CreateEventViewModel
    {
        public Event events { get; set; }
        public List<Locatie> locaties { get; set; }
    }
}