using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGrease.Css;

namespace ASP_PROFTAAK.Email
{
    public static class GenerateMail
    {

        public static string MakeMail(string activatiehash, string naam)
        {
            string email = System.IO.File.ReadAllText("~/Email/emailtemplate.html");
            email = email.Replace("#activatiehash#", activatiehash);
            email = email.Replace("#voornaam#", naam);
            return email; 
        }
    }
}