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

        public int CategorieId
        {
            get { return categorieId; }
            set { categorieId = value; }
        }

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        public Categorie(int id, Account account, DateTime datum, string soort, int categorieId, string naam, AccountBijdrage accountBijdrage) : base(id, account, datum, soort, accountBijdrage)
        {
            this.categorieId = categorieId;
            this.naam = naam;
        }

        public Categorie(Account account, DateTime datum, string soort, int categorieId, string naam, AccountBijdrage accBijdrage) : base(account, datum, soort, accBijdrage)
        {
            this.categorieId = categorieId;
            this.naam = naam;
        }


    }
}