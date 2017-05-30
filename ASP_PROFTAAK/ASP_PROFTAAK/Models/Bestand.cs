using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class Bestand: Bijdrage
    {
        private int categorieId;
        private string bestandsLocatie;
        private int grootte;

        public Bestand(int categorieId, string bestandsLocatie, int grootte, int id, int accountId, string datum, string soort) : base(id, accountId, datum, soort)
        {
            this.categorieId = categorieId;
            this.bestandsLocatie = bestandsLocatie;
            this.grootte = grootte;
        }

        public int CategorieId
        {
            get
            {
                return categorieId;
            }

            set
            {
                categorieId = value;
            }
        }

        public string BestandsLocatie
        {
            get
            {
                return bestandsLocatie;
            }

            set
            {
                bestandsLocatie = value;
            }
        }

        public int Grootte
        {
            get
            {
                return grootte;
            }

            set
            {
                grootte = value;
            }
        }
    }
}