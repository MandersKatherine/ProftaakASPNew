using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK
{
    public class Locatie
    {

        private int id;
        private string naam;
        private string straat;
        private string nummer;
        private string postcode;
        private string plaats;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Naam
        {
            get
            {
                return naam;
            }

            set
            {
                naam = value;
            }
        }

        public string Straat
        {
            get
            {
                return straat;
            }

            set
            {
                straat = value;
            }
        }

        public string Nummer
        {
            get
            {
                return nummer;
            }

            set
            {
                nummer = value;
            }
        }

        public string Postcode
        {
            get
            {
                return postcode;
            }

            set
            {
                postcode = value;
            }
        }

        public string Plaats
        {
            get
            {
                return plaats;
            }

            set
            {
                plaats = value;
            }
        }

        public Locatie(int id, string naam, string straat, string nummer, string postcode, string plaats)
        {
            this.Id = id;
            this.Naam = naam;
            this.Straat = straat;
            this.Nummer = nummer;
            this.Postcode = postcode;
            this.Plaats = plaats;
        }

        public Locatie(string naam, string straat, string nummer, string postcode, string plaats)
        {
            this.Id = 0; 
            this.Naam = naam;
            this.Straat = straat;
            this.Nummer = nummer;
            this.Postcode = postcode;
            this.Plaats = plaats;
        }

        private void addPlek()
        {

        }

    }
}