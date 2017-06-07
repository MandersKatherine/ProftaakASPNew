using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using ASP_PROFTAAK.Properties;

namespace ASP_PROFTAAK.Email
{
    public static class EmailLogic
    {
        public static bool SendEmail(Models.Email email)
        {
            using (SmtpClient client = Emailserver.Client)
            {
                try
                {
                    MailMessage mm = new MailMessage("info@Eventmanager.com", email.Ontvanger, email.Onderwerp, email.Inhoud);
                    mm.IsBodyHtml = true;
                    mm.BodyEncoding = UTF8Encoding.UTF8;
                    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                    client.Send(mm);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
        // De emailtemplate.html file path moet gegeven worden, zet dit naar eigen PC of DEBUG 
        public static bool SendEmailNew(Models.Email email, string activatiehash, string voornaam)
        {
            string emailaangepast = System.IO.File.ReadAllText(HttpRuntime.AppDomainAppPath + "/Email/emailtemplate.html");
            //veranderd de info in de template
            emailaangepast = emailaangepast.Replace("#activatiehash#", activatiehash);
            emailaangepast = emailaangepast.Replace("#voornaam#", voornaam);
            using (SmtpClient client = Emailserver.Client)
            {
                try
                {
                    MailMessage mm = new MailMessage("info@Eventmanager.com", email.Ontvanger, email.Onderwerp, emailaangepast);
                    mm.IsBodyHtml = true;
                    mm.BodyEncoding = UTF8Encoding.UTF8;
                    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                    client.Send(mm);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

    }
}