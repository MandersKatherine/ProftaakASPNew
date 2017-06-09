using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class Reactie: Bijdrage
    {
        
        private int berichtId;

        public Reactie(int berichtId, Account accountId, DateTime datum, string soort, AccountBijdrage accBijdrage): base(accountId, datum, soort, accBijdrage)
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