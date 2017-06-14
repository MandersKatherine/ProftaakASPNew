using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class ProductCategorie
    {
        private decimal id;
        private decimal productCatId;
        private string naam;

        public ProductCategorie(decimal id, decimal productCatId, string naam)
        {
            this.Id = id;
            this.ProductCatId = productCatId;
            this.Naam = naam;
        }

        public ProductCategorie(decimal id, string naam)
        {
            this.Id = id;
            this.Naam = naam;
        }

        public ProductCategorie(decimal id)
        {
            this.id = id; 
        }

        public ProductCategorie(string naam, decimal productCatId)
        {
            this.ProductCatId = productCatId;
            this.Naam = naam;
        }

        public ProductCategorie(string naam)
        {
            this.Naam = naam;
        }

        public ProductCategorie()
        {
            
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

        public decimal ProductCatId
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