using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class Bijdrage
    {
        private int id;
        private int accountId;
        private string datum;
        private string soort;

        public Bijdrage(int id, int accountId, string datum, string soort)
        {
            this.id = id;
            this.accountId = accountId;
            this.datum = datum;
            this.soort = soort;
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

        public int AccountId
        {
            get
            {
                return accountId;
            }

            set
            {
                accountId = value;
            }
        }

        public string Datum
        {
            get
            {
                return datum;
            }

            set
            {
                datum = value;
            }
        }

        public string Soort
        {
            get
            {
                return soort;
            }

            set
            {
                soort = value;
            }
        }

        public override string ToString()
        {
            return base.ToString(); 
        }
    }
}