using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Inbetween.Models
{
    public class MailSender
    {
        public void SendMail(string fromName, string theSubject, string fromEmail, string textMessage)
        {
            MailMessage mail = new MailMessage("inbetween.musicgroup@gmail.com", "inbetween.musicgroup@gmail.com");

            mail.Subject = theSubject;

            mail.Body = textMessage + "\n" + "From: " + fromName + "\n" + "Email: " + fromEmail;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;

            smtp.Credentials = new NetworkCredential("inbetween.musicgroup@gmail.com", "MikaelBrunnberg");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}

