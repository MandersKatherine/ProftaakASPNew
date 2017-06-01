using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class Groepslid
    {
        private int id;
        private int reserveringId;
        private int polsbandjeId;
        private int accountId;
        private bool aanwezig;

        public Groepslid(int id, int reserveringId, int polsbandjeId, int accountId, bool aanwezig)
        {
            this.id = id;
            this.reserveringId = reserveringId;
            this.accountId = accountId;
            this.polsbandjeId = polsbandjeId;
            this.aanwezig = aanwezig;
        }

        public Groepslid(int reserveringId, int polsbandjeId, int accountId, bool aanwezig)
        {
            this.reserveringId = reserveringId;
            this.accountId = accountId;
            this.aanwezig = aanwezig;
            this.polsbandjeId = polsbandjeId;

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

        public int ReserveringId
        {
            get
            {
                return reserveringId;
            }

            set
            {
                reserveringId = value;
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

        public bool Aanwezig
        {
            get
            {
                return aanwezig;
            }

            set
            {
                aanwezig = value;
            }
        }
    }
}