using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ASP_PROFTAAK.Email
{
    public class Emailserver
    {
        private static readonly string username = "eventmanagerict@gmail.com";
        private static readonly string password = "loler123";



        public static SmtpClient Client
        {
            get
            {
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(username, password);
                return client;
            }
        }
    }
}