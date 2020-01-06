using HW10.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HW10.Services
{
    public class EmailSenderService
    {
        public Task SendAsync(EmailMessageDTO emailMessage)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.mail.ru");

            mail.From = new MailAddress("ealdor_vd@mail.ru");
            mail.To.Add(emailMessage.To);
            mail.Subject = emailMessage.Title;
            mail.Body = emailMessage.Text;

            smtpServer.Port = 465;
            smtpServer.Credentials = new System.Net.NetworkCredential("ealdor_vd@mail.ru", "radle689391");
            smtpServer.EnableSsl = true;

            smtpServer.SendMailAsync(mail);

            return Task.CompletedTask;
        }
    }
}
