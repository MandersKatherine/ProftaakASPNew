using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class Reservering
    {
        private decimal id;
        private decimal personId;
        private DateTime datumstart;
        private DateTime datumeinde;
        private bool betaald;

        public decimal Id { get { return id; } set { id = value; } }
        public decimal PersonId { get { return personId; } set { personId = value; } }
        public DateTime DatumStart { get { return datumstart; } set { datumstart = value; } }
        public DateTime DatumEinde { get { return datumeinde; } set { datumeinde = value; } }
        public bool Betaald { get { return betaald; } set { betaald = value; } }

        public Reservering(decimal id, decimal personId, DateTime datumstart, DateTime datumeinde, bool betaald)
        {
            this.id = id;
            this.personId = personId;
            this.datumstart = datumstart;
            this.datumeinde = datumeinde;
            this.betaald = betaald;
        }

        public Reservering(decimal personId, DateTime datumstart, DateTime datumeinde, bool betaald) : this(-1, personId, datumstart, datumeinde, betaald)
        {

        }

        //public maakHoofdBoeker(Groepslid groepslid)
        //{
        //    return groepslid;
        //}

        public void reserveer()
        {

        }

        public void addGroepslid()
        {

        }

        public void betaal()
        {

        }

        public void addPlek()
        {

        }

        public override string ToString()
        {
            return DatumStart + " " + DatumEinde + " " + Betaald;
        }
    }
}