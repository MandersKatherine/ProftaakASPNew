using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class Reactie: Bijdrage
    {
        public int berichtId { get; private set; }
        public string inhoud { get; private set; }

        public Reactie(int berichtId, string inhoud) : base(null, DateTime.Now, null, null)
        {
            this.berichtId = berichtId;
            this.inhoud = inhoud;
        }

        public Reactie(int berichtId, Account accountId, DateTime datum, string soort, AccountBijdrage accBijdrage): base(accountId, datum, soort, accBijdrage)
        {
            this.berichtId = berichtId;
            
        }

       


        
    }
}