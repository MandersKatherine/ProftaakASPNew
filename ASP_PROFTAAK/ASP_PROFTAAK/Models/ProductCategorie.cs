using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class ProductCategorie
    {
        private int id;
        private int productCatId;
        private string naam;

        public ProductCategorie(int id, int productCatId, string naam)
        {
            this.Id = id;
            this.ProductCatId = productCatId;
            this.Naam = naam;
        }

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

        public int ProductCatId
        {
            get
            {
                return productCatId;
            }

            set
            {
                productCatId = value;
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