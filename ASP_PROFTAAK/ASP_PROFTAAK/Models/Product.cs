using System;
using System.Collections.Generic;
using System.Linq;

namespace ASP_PROFTAAK.Models
{
    public class Product
    {
        private int productId;
        private int categorieId;
        private string merk;
        private string serie;
        private string typenummer;
        private double prijs;

        public Product(int productId, int categorieId, string merk, string serie, string typenummer, double prijs)
        {
            this.ProductId = productId;
            this.CategorieId = categorieId;
            this.Merk = merk;
            this.Serie = serie;
            this.Typenummer = typenummer;
            this.Prijs = prijs;
        }

        public int ProductId
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

        public double Prijs
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