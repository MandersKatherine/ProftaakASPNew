using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class PlekSpecificatieViewModel
    {
        public List<Plek> plekken { get; set; }
        public List<List<Specificatie>> specificaties { get; set; }
    }
}