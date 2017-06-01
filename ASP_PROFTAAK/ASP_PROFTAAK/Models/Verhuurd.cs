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