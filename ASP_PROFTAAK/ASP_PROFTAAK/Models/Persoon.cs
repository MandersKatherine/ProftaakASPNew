using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class Persoon
    {
        private int id;
        private string voornaam;
        private string tussenvoegsel;
        private string achternaam;
        private string straat;
        private string huisnr;
        private string woonplaats;
        private string banknr;

        public int Id { get { return id; } set { id = value; } }
        public string Voornaam { get { return voornaam; } set { voornaam = value; } }
        public string Tussenvoegsel { get { return tussenvoegsel; } set { tussenvoegsel = value; } }
        public string Achternaam { get { return achternaam; } set { achternaam = value; } }
        public string Straat { get { return straat; } set { straat = value; } }
        public string Huisnr { get { return huisnr; } set { huisnr = value; } }
        public string Woonplaats { get { return woonplaats; } set { woonplaats = value; } }
        public string Banknr { get { return banknr; } set { banknr = value; } }

        public Persoon (int id, string voornaam, string tussenvoegsel, string achternaam, string straat, string huisnr, string woonplaats, string banknr)
        {
            this.id = id;
            this.voornaam = voornaam;
            this.tussenvoegsel = tussenvoegsel;
            this.achternaam = achternaam;
            this.straat = straat;
            this.huisnr = huisnr;
            this.woonplaats = woonplaats;
            this.banknr = banknr;
        }

        public Persoon(string voornaam, string tussenvoegsel, string achternaam, string straat, string huisnr, string woonplaats, string banknr) : this (-1, voornaam, tussenvoegsel, achternaam, straat, huisnr, woonplaats, banknr)
        {

        }

        public override string ToString()
        {
            return Voornaam + " " + Tussenvoegsel + " " + Achternaam + " " + Straat + " " + Huisnr + " " + Woonplaats + " " + Banknr;
        }

    }
}