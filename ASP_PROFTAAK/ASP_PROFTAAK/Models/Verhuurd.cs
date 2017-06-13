using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class Verhuurd
    {
        private decimal id;
        private decimal productExemplaarId;
        private decimal groepsLidId;
        private DateTime datumIn;
        private DateTime datumUit;
        private decimal prijs;
        private decimal betaald;
        private string merk;
        private string serie;
        private string typenummer;
        private decimal totaalPrijs;
        private string catNaam;
        private string catSubNaam;

        public Verhuurd(decimal id, decimal productExemplaarId, decimal groepsLidId, DateTime datumIn, DateTime datumUit,
            decimal prijs, decimal betaald)
        {
            this.Id = id;
            this.ProductExemplaarId = productExemplaarId;
            this.GroepsLidId = groepsLidId;
            this.DatumIn = datumIn;
            this.DatumUit = datumUit;
            this.Prijs = prijs;
            this.Betaald = betaald;
        }

        public Verhuurd()
        {
            
        }

        public Verhuurd(decimal productExemplaarId, decimal groepsLidId, DateTime datumIn, DateTime datumUit, decimal prijs, decimal betaald)
        {
            this.productExemplaarId = productExemplaarId;
            this.groepsLidId = groepsLidId;
            this.datumIn = datumIn;
            this.datumUit = datumUit;
            this.prijs = prijs;
            this.betaald = betaald;
        }

        public Verhuurd(decimal id, decimal productExemplaarId, decimal groepsLidId, DateTime datumIn, DateTime datumUit, decimal prijs, decimal betaald, string merk, string serie, string typenummer, decimal totaalPrijs, string catNaam, string catSubNaam)
        {
            this.id = id;
            this.productExemplaarId = productExemplaarId;
            this.groepsLidId = groepsLidId;
            this.datumIn = datumIn;
            this.datumUit = datumUit;
            this.prijs = prijs;
            this.betaald = betaald;
            this.merk = merk;
            this.serie = serie;
            this.typenummer = typenummer;
            this.totaalPrijs = totaalPrijs;
            this.catNaam = catNaam;
            this.catSubNaam = catSubNaam;
        }

        public Verhuurd(string merk, string serie, string typenummer, decimal totaalPrijs, string catNaam, string catSubNaam)
        {
            this.merk = merk;
            this.serie = serie;
            this.typenummer = typenummer;
            this.totaalPrijs = totaalPrijs;
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

        public decimal ProductExemplaarId
        {
            get
            {
                return productExemplaarId;
            }

            set
            {
                productExemplaarId = value;
            }
        }

        public decimal GroepsLidId
        {
            get
            {
                return groepsLidId;
            }

            set
            {
                groepsLidId = value;
            }
        }

        public DateTime DatumIn
        {
            get
            {
                return datumIn;
            }

            set
            {
                datumIn = value;
            }
        }

        public DateTime DatumUit
        {
            get
            {
                return datumUit;
            }

            set
            {
                datumUit = value;
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

        public decimal Betaald
        {
            get
            {
                return betaald;
            }

            set
            {
                betaald = value;
            }
        }
    }
}