using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class Polsbandje
    {
        private decimal id;
        private string barcode;
        private decimal actief;

        public Polsbandje(decimal id, string barcode, decimal actief)
        {
            this.id = id;
            this.barcode = barcode;
            this.actief = actief;
        }

        public Polsbandje(string barcode, decimal actief)
        {
            this.barcode = barcode;
            this.actief = actief;
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

        public decimal Actief
        {
            get
            {
                return actief;
            }

            set
            {
                actief = value;
            }
        }
    }
}