using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class Verhuurd
    {
        private int id;
        private int productExemplaarId;
        private int groepsLidId;
        private DateTime datumIn;
        private DateTime datumUit;
        private double prijs;
        private bool betaald;

        public Verhuurd(int id, int productExemplaarId, int groepsLidId, DateTime datumIn, DateTime datumUit,
            double prijs, bool betaald)
        {
            this.Id = id;
            this.ProductExemplaarId = productExemplaarId;
            this.GroepsLidId = groepsLidId;
            this.DatumIn = datumIn;
            this.DatumUit = datumUit;
            this.Prijs = prijs;
            this.Betaald = betaald;
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

        public int ProductExemplaarId
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

        public int GroepsLidId
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

        public bool Betaald
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