using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class ReserveringMakenViewModel
    {
        public DateTime datumStart { get; set; }
        public DateTime datumEinde { get; set; }
	    public int betaald { get; set; }
        public int accountId { get; set; }
        public int aanwezig { get; set; }
        public int plekId { get; set; }
        public string voornaam { get; set; }
        public string tussenvoegsel { get; set; }
        public string achternaam { get; set; }
        public string straat { get; set; }
        public string huisnummer { get; set; }
        public string woonplaats { get; set; }
        public string banknummer { get; set; }
        public List<Event> events { get; set; }
        public List<Plek> plekken { get; set; }
        public List<Specificatie> specificaties { get; set; }
    }
}