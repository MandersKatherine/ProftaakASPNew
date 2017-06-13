using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class Aanwezig
    {
        private decimal id;
        private string barcode;
        private decimal aanwezigopEvent;
        private string voornaam;
        private string tussenvoegsel;
        private string achternaam;
        private int telefoonNummer;

        public Aanwezig(decimal id, string barcode, decimal aanwezigopEvent, string voornaam, string tussenvoegsel, string achternaam, int telefoonNummer)
        {
            Id = id;
            Barcode = barcode;
            AanwezigopEvent = aanwezigopEvent;
            Voornaam = voornaam;
            Tussenvoegsel = tussenvoegsel;
            Achternaam = achternaam;
            TelefoonNummer = telefoonNummer;
        }

        public decimal Id
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

        public string Barcode
        {
            get
            {
                return barcode;
            }

            set
            {
                barcode = value;
            }
        }

        public decimal AanwezigopEvent
        {
            get
            {
                return aanwezigopEvent;
            }

            set
            {
                aanwezigopEvent = value;
            }
        }

        public string Voornaam
        {
            get
            {
                return voornaam;
            }

            set
            {
                voornaam = value;
            }
        }

        public string Tussenvoegsel
        {
            get
            {
                return tussenvoegsel;
            }

            set
            {
                tussenvoegsel = value;
            }
        }

        public string Achternaam
        {
            get
            {
                return achternaam;
            }

            set
            {
                achternaam = value;
            }
        }

        public int TelefoonNummer
        {
            get
            {
                return telefoonNummer;
            }

            set
            {
                telefoonNummer = value;
            }
        }

        public override string ToString()
        {
            return voornaam + telefoonNummer;
        }
    }
}