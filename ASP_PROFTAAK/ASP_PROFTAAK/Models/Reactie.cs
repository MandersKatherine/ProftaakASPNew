using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class Reactie: Bijdrage
    {
        
        private int berichtId;

        public Reactie(int BijdrageId, int berichtId, int accountId, DateTime datum, string soort): base(BijdrageId, accountId, datum, soort)
        {
            this.berichtId = berichtId;
        }

        public int BerichtId
        {
            get
            {
                return berichtId;
            }

            set
            {
                berichtId = value;
            }
        }


        
    }
}