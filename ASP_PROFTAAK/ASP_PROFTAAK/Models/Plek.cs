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
        public int LocatieId { get; private set; }
        public string Nummer { get; private set; }
        public int Capaciteit { get; private set; }

        public Plek(int iD, int locatieid, string nummer, int capaciteit)
        {
            this.ID = iD;
            this.LocatieId = locatieid;
            this.Nummer = nummer;
            this.Capaciteit = capaciteit;
        }

        public Plek(int locatieid, string nummer, int capaciteit) :this(-1, locatieid,nummer,capaciteit)
        {
            
        }

        public void AddSpecificatie()
        {
            
        }
    }
}