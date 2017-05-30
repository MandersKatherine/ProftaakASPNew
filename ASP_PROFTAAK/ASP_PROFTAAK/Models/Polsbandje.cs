using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class Polsbandje
    {
        private int id;
        private int barcode;
        private bool actief;

        public Polsbandje(int id, int barcode, bool actief)
        {
            this.id = id;
            this.barcode = barcode;
            this.actief = actief;
        }

        public Polsbandje(int barcode, bool actief)
        {
            this.barcode = barcode;
            this.actief = actief;
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

        public int Barcode
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

        public bool Actief
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