using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_PROFTAAK.Models
{
    public class Like1
    {
        public Like1(int bijdrage_id, int i)
        {
            this.bijdrage_id = bijdrage_id;
            likes = i;
            bestaat = true;
        }

        public int bijdrage_id { get; private set; }
        public int likes { get; private set; }
        public bool bestaat { get; set; }
    }
}