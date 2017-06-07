using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class ContentViewModel
    {
        public Bestand bestand { get; set; }
        public List<Bericht> berichten { get; set; }
        public Categorie categorie { get; set; }
        public List<Bijdrage> bijdrage { get; set; }
        public List<Reactie> reacties { get; set; }
        public Account account { get; set; }
        public List<Mening> mening { get; set; }


    }
}