using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class Bestand: Bijdrage
    {

        private int categorieId;
        private string bestandlocatie;
        private int grootte;

        public int CategorieId
        {
            get { return categorieId; }
            set { categorieId = value; }
        }

        public string Bestandlocatie
        {
            get { return bestandlocatie; }
            set { bestandlocatie = value; }
        }

        public int Grootte
        {
            get { return grootte; }
            set { grootte = value; }
        }

        public Bestand(DateTime datum, string soort, int categorieId, string bestandlocatie, int grootte, Account account, AccountBijdrage accBijdrage) : base(account, datum, soort, accBijdrage)
        {
            this.categorieId = categorieId;
            this.bestandlocatie = bestandlocatie;
            this.grootte = grootte;
        }

        public Bestand(int id, Account account, DateTime datum, string soort, int categorieId, string bestandlocatie, int grootte, AccountBijdrage accBijdrage) : base(id, account, datum, soort, accBijdrage)
        {
            this.categorieId = categorieId;
            this.bestandlocatie = bestandlocatie;
            this.grootte = grootte;
        }

    }
}