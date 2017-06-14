using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class ProductExemplaar
    {
        private decimal id;
        private decimal productId;
        private decimal volgnummer;
        private string barcode;
        private string verhuurd;
        private string merk;
        private string serie;
        private string typenummer;
        private decimal prijs;
        private string catNaam;
        private string catSubNaam;

        public ProductExemplaar()
        {
            
        }

        public ProductExemplaar(decimal id, decimal productId, decimal volgnummer, string barcode, string verhuurd)
        {
            this.Id = id;
            this.ProductId = productId;
            this.Volgnummer = volgnummer;
            this.Barcode = barcode;
            this.verhuurd = verhuurd;
        }

        public ProductExemplaar(decimal productId, decimal volgnummer, string barcode, string verhuurd)
        {
            this.ProductId = productId;
            this.Volgnummer = volgnummer;
            this.Barcode = barcode;
            this.verhuurd = verhuurd;
        }

        public ProductExemplaar(decimal id, decimal productId, decimal volgnummer, string barcode, string verhuurd, string merk, string serie, string typenummer, decimal prijs, string catNaam, string catSubNaam)
        {
            this.id = id;
            this.productId = productId;
            this.volgnummer = volgnummer;
            this.barcode = barcode;
            this.verhuurd = verhuurd;
            this.merk = merk;
            this.serie = serie;
            this.typenummer = typenummer;
            this.prijs = prijs;
            this.catNaam = catNaam;
            this.catSubNaam = catSubNaam;
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

        public decimal ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public decimal Volgnummer
        {
            get
            {
                return volgnummer;
            }

            set
            {
                volgnummer = value;
            }
        }

        public string Barcode
        {
            get
            {
                return barcode;
            }

            set
            {
                barcode = value;
            }
        }

        public string Verhuurd
        {
            get
            {
                return verhuurd;
            }

            set
            {
                verhuurd = value;
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

        public string CatNaam
        {
            get
            {
                return catNaam;
            }

            set
            {
                catNaam = value;
            }
        }

        public string CatSubNaam
        {
            get
            {
                return catSubNaam;
            }

            set
            {
                catSubNaam = value;
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

        public override string ToString()
        {
            return base.ToString();
        }
    }
}