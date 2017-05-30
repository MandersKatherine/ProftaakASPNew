using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class Plek
    {
        //private Specificatie Spec;
        public int ID { get; private set; }
        public string Nummer { get; private set; }
        public int Capaciteit { get; private set; }

        public Plek(int iD, string nummer, int capaciteit)
        {
            ID = iD;
            Nummer = nummer;
            Capaciteit = capaciteit;
        }

        public Plek(string nummer, int capaciteit)
        {
            ID = -1;
            Nummer = nummer;
            Capaciteit = capaciteit;
        }

        public void AddSpecificatie()
        {
            
        }
    }
}