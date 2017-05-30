using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class ProductExemplaar : Product
    {
        private int id;
        private int volgnummer;
        private string barcode;
        private bool verhuurd;


        public ProductExemplaar(int productId, int categorieId, string merk, string serie, string typenummer, double prijs, int id, int volgnummer, string barcode, bool verhuurd) : base(productId, categorieId, merk, serie, typenummer, prijs)
        {
            this.Id = id;
            this.Volgnummer = volgnummer;
            this.Barcode = barcode;
            this.Verhuurd = verhuurd;
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

        public int Volgnummer
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