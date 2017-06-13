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

        public string Titel
        {
            get { return titel; }
            set { titel = value; }
        }

        public string Inhoud
        {
            get { return inhoud; }
            set { inhoud = value; }
        }

        public Bericht(int id, Account account, AccountBijdrage accountBijdrage, DateTime datum, string soort, string titel, string inhoud) : base(id, account, datum, soort, accountBijdrage)
        {
            this.titel = titel;
            this.inhoud = inhoud;
        }

        public Bericht(Account account, DateTime datum, string soort, string titel, string inhoud, AccountBijdrage accountBijdrage) : base(account, datum, soort, accountBijdrage)
        {
            this.titel = titel;
            this.inhoud = inhoud;
        }
    }
}