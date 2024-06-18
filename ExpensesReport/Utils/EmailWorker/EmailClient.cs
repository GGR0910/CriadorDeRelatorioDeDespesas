using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace ExpensesReport.Utils.EmailWorker
{
    internal class EmailClient
    {
        private string SenderEmail { get; set; } = "ggr0910@hotmail.com";
        private string SenderPassword { get; set; } = "gogoll90";
        private string RecipientEmail { get; set; }
        private string Subject { get; set; }
        private string Body { get; set; }

        public SmtpClient Smtp { get; set; } = new SmtpClient("\tsmtp-mail.outlook.com", 587); 

        public EmailClient(string recipientEmail, string subject, string body)
        {
            Smtp.Credentials = new NetworkCredential(SenderEmail, SenderPassword);
            Smtp.EnableSsl = true; 
            RecipientEmail = recipientEmail;
            Subject = subject;
            Body = body;
        }

        public void SendEmail()
        {
            MailMessage mail = new MailMessage(SenderEmail, RecipientEmail, Subject, Body);
            mail.IsBodyHtml = true;
            Smtp.Send(mail);
        }
       
    }
}
