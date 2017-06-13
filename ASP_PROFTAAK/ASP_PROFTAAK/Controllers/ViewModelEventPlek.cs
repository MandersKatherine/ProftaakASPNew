using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class ViewModelEventPlek
    {
        public Event events { get; set; }
        public Polsbandje polsbandje { get; set; }
        public Plek plek { get; set; }
    }
}