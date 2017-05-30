using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class Specificatie
    {
        public int ID { get; private set; }
        public string Naam { get; private set; }

        public Specificatie(int iD, string naam)
        {
            ID = iD;
            Naam = naam;
        }

        public Specificatie(string naam)
        {
            ID = -1;
            Naam = naam;
        }
    }
}