using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class Account
    {
        private int id;
        private string gebruikersnaam;
        private string email;
        private string activatiehash;
        private string wachtwoord;
        private string voornaam;
        private string achternaam;
        private int telefoonnr;
        private int geactiveerd;


        public int Id { get { return id; } set { id = value; } }
        public string Gebruikersnaam { get { return gebruikersnaam; } set { gebruikersnaam = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Activatiehash { get { return activatiehash; } set { activatiehash = value; } }
        public string Wachtwoord { get { return wachtwoord; } set { wachtwoord = value; } }
        public string Voornaam { get { return voornaam; } set { voornaam = value; } }
        public string Achternaam { get { return achternaam; } set { achternaam = value; } }
        public int Telefoonnr { get { return telefoonnr; } set { telefoonnr = value; } }
        public int Geactiveerd { get { return geactiveerd; } set { geactiveerd = value; } }

        public Account(int id, string voornaam, string tussenvoegsel, string achternaam, int telefoonnummer, string gebruikersnaam, string wachtwoord, string email, string activatiehash, int geactiveerd)
        {
            this.id = id;
            this.gebruikersnaam = gebruikersnaam;
            this.email = email;
            this.activatiehash = activatiehash;
            this.wachtwoord = wachtwoord;
            this.voornaam = voornaam;
            this.achternaam = achternaam;
            this.telefoonnr = telefoonnummer;
            this.geactiveerd = geactiveerd;
        }

        public Account(string voornaam, string tussenvoegsel, string achternaam, int telefoonnummer, string gebruikersnaam, string wachtwoord, string email, string activatiehash, int geactiveerd)
            : this(-1, voornaam, tussenvoegsel, achternaam, telefoonnummer, gebruikersnaam, wachtwoord, email, activatiehash, geactiveerd)
        {

        }


        //public Like(Bijdrage bijdrage)
        //{
        //    return bijdrage;
        //}

        //public Reageer(Bijdrage bijdrage)
        //{
        //    return bijdrage;
        //}

        //public Rapporteer(Bijdrage bijdrage)
        //{
        //    return bijdrage;
        //}

        public void maakBijdrage()
        {

        }


        public override string ToString()
        {
            return Gebruikersnaam + " ";
        }
    }
}