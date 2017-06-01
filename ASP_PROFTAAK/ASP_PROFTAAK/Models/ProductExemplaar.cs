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
        private bool verhuurd;


        public ProductExemplaar()
        {
            
        }

        public ProductExemplaar(decimal id, decimal productId, decimal volgnummer, string barcode, bool verhuurd)
        {
            this.Id = id;
            this.ProductId = productId;
            this.Volgnummer = volgnummer;
            this.Barcode = barcode;
            this.Verhuurd = verhuurd;
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

        public bool Verhuurd
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

        public override string ToString()
        {
            return base.ToString();
        }
    }
}