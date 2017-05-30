using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class Categorie: Bijdrage
    {
        private int categorieId;
        private string naam;

        public Categorie(int categorieId, string naam, int id, int accountId, string datum, string soort) : base(id, accountId, datum, soort)
        {
            this.categorieId = categorieId;
            this.naam = naam;
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
    }
}