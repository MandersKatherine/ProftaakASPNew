using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class ReserveringViewModel
    {
        public Persoon Hoofdboeker { get; set; }
        public List<Groepslid> Groepsleden { get; set; }
        public Event Event { get; set; }
        public Polsbandje Polsbandje { get; set; }
    }
}