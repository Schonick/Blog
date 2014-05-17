using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net.Mail;

namespace SportClub.Models
{
    public class Email
    {
        public void Send(Contact contact)
        {
            try
            {
                MailMessage mailMsg = new MailMessage();

                mailMsg.Subject = contact.Subject;
                mailMsg.Body = contact.Message;

                mailMsg.To.Add(new MailAddress(
                    ConfigurationManager.AppSettings["webMasterMail"],
                    "Domagoj Salopek"
                ));

                mailMsg.From = new MailAddress(contact.Mail, contact.Name);

                SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["smtpServer"], 25);

                smtpClient.Credentials = new System.Net.NetworkCredential(
                    ConfigurationManager.AppSettings["smtpUser"],
                    ConfigurationManager.AppSettings["smtpPassword"]);

                smtpClient.Send(mailMsg);
            }
            catch (Exception )
            {

                throw;
            }
        }
    }
}