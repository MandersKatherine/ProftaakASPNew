using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class AccountBijdrage
    {

        private int id;
        private int accountID;
        private int bijdrageID;
        private int like;
        private int ongewenst;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int AccountID
        {
            get { return accountID; }
            set { accountID = value; }
        }
        public int BijdrageID
        {
            get { return bijdrageID; }
            set { bijdrageID = value; }
        }
        public int Like
        {
            get { return like; }
            set { like = value; }
        }
        public int Ongenwenst
        {
            get { return ongewenst; }
            set { ongewenst = value; }
        }

        public AccountBijdrage(int id, int accountID, int bijdrageID, int like, int ongewenst)
        {
            this.id = id;
            this.accountID = accountID;
            this.bijdrageID = bijdrageID;
            this.like = like;
            this.ongewenst = ongewenst;
        }

        public AccountBijdrage(int accountID, int bijdrageID, int like, int ongewenst)
        {
            this.accountID = accountID;
            this.bijdrageID = bijdrageID;
            this.like = like;
            this.ongewenst = ongewenst;
        }

    }
}