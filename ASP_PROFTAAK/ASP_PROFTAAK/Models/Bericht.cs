using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class Bericht: Bijdrage
    {
        private string titel; 
        private string inhoud;


        public Bericht(string titel, string inhoud, int id, int accountId, string datum, string soort) : base(id, accountId, datum, soort)
        {
            this.titel = titel;
            this.inhoud = inhoud;
        }

        public string Titel
        {
            get
            {
                return titel;
            }

            set
            {
                titel = value;
            }
        }

        public string Inhoud
        {
            get
            {
                return inhoud;
            }

            set
            {
                inhoud = value;
            }
        }
    }
}