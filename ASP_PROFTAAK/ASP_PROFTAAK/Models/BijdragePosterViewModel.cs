using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector.QuickPulse;

namespace ASP_PROFTAAK.Models
{
    public class BijdragePosterViewModel
    {
        public List<Bijdrage> Bedrijges { get; set; }
        //public List<Account>  Accounts { get; set; }
        public List<Categorie> Categories { get; set; }

        public List<Reactie> Reacties { get; set; }
    }
}