using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public abstract class Bijdrage : IEnumerable
    {
        private int id;
        private Account Account;
        private DateTime datum;
        private string soort;
        private AccountBijdrage accountBijdrage;
        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        
        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }

        public string Soort
        {
            get { return soort; }
            set { soort = value; }
        }

        public AccountBijdrage AccountBijdrage
        {
            get
            {
                return accountBijdrage;
            }

            set
            {
                accountBijdrage = value;
            }
        }

        public Account Account1
        {
            get
            {
                return Account;
            }

            set
            {
                Account = value;
            }
        }

        public Bijdrage(int id, Account accountId, DateTime datum, string soort, AccountBijdrage accountBijdrage)
        {
            this.id = id;
            this.Account = accountId;
            this.datum = datum;
            this.soort = soort;
            this.AccountBijdrage = accountBijdrage;
        }

        public Bijdrage(Account accountId, DateTime datum, string soort, AccountBijdrage accountBijdrage)
        {
            this.Account = accountId;
            this.datum = datum;
            this.soort = soort;
            this.AccountBijdrage = accountBijdrage;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}