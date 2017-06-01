using System;
using System.Collections.Generic;
using System.Linq;

namespace ASP_PROFTAAK.Models
{
    public class Product
    {
        private decimal productId;
        private decimal categorieId;
        private string merk;
        private string serie;
        private string typenummer;
        private decimal prijs;

        public Product(decimal productId, decimal categorieId, string merk, string serie, string typenummer, decimal prijs)
        {
            this.ProductId = productId;
            this.CategorieId = categorieId;
            this.Merk = merk;
            this.Serie = serie;
            this.Typenummer = typenummer;
            this.Prijs = prijs;
        }

        public Product()
        {
            
        }

        public decimal ProductId
        {
            get
            {
                return productId;
            }

            set
            {
                productId = value;
            }
        }

        public decimal CategorieId
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

        public string Merk
        {
            get
            {
                return merk;
            }

            set
            {
                merk = value;
            }
        }

        public string Serie
        {
            get
            {
                return serie;
            }

            set
            {
                serie = value;
            }
        }

        public string Typenummer
        {
            get
            {
                return typenummer;
            }

            set
            {
                typenummer = value;
            }
        }

        public decimal Prijs
        {
            get
            {
                return prijs;
            }

            set
            {
                prijs = value;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}