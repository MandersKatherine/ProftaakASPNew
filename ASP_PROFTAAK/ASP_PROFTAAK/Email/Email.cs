using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class Email
    {
        public Email(string onderwerp, string ontvanger)
        {
            _onderwerp = onderwerp;
            _ontvanger = ontvanger;
        }

        public Email(string onderwerp, string inhoud, string ontvanger)
        {
            _onderwerp = onderwerp;
            _inhoud = inhoud;
            _ontvanger = ontvanger;
        }

        private string _onderwerp;
        private string _ontvanger;
        private string _inhoud;

        public string Onderwerp
        {
            get { return _onderwerp; }
            set { _onderwerp = value; }
        }

        public string Inhoud
        {
            get { return _inhoud; }
            set { _inhoud = value; }
        }

        public string Ontvanger
        {
            get { return _ontvanger; }
            set { _ontvanger = value; }
        }





    }
}