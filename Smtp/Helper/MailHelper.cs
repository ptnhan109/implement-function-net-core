using Microsoft.Extensions.Configuration;
using Smtp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Smtp.Helper
{
    public class MailHelper
    {
        public static void SendMail(Mail mail)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            string username = config.GetValue<string>("Mail:username");
            string password = config.GetValue<string>("Mail:password");
            string host = config.GetValue<string>("Mail:host");
            int port = config.GetValue<int>("Mail:port");
            try
            {
                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Host = host;
                    smtpClient.Port = port;
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new NetworkCredential(username, password);
                    var msg = new MailMessage()
                    {
                        IsBodyHtml = true,
                        BodyEncoding = Encoding.UTF8,
                        Subject = mail.Subject,
                        From = new MailAddress(username),
                        Body = mail.Content,
                        Priority = MailPriority.Normal
                    };
                    if(mail.Attachments.Count != 0)
                    {
                        mail.Attachments.ForEach(attach =>
                        {
                            msg.Attachments.Add(new Attachment(new MemoryStream(attach.Stream), attach.ContentType));
                        });
                    }
                    msg.To.Add(mail.DestMail);
                    smtpClient.Send(msg);
                }
            }
            catch (Exception)
            {
                //TODO: Logger here;
                throw;
            }
        }
    }
}
