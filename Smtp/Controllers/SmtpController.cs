using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smtp.Helper;
using Smtp.Models;

namespace Smtp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmtpController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendMail([FromForm] Mail request)
        {
            List<MailAttachment> attachments = new List<MailAttachment>();
            var files = Request.Form.Files;
            if(files.Count > 0)
            {
                files.ToList().ForEach(c =>
                {
                    attachments.Add(new MailAttachment()
                    {
                        ContentType = Path.GetFileName(c.FileName),
                        Stream = (new BinaryReader(c.OpenReadStream())).ReadBytes((int)c.Length)
                    });
                });
            }
            Mail mail = new Mail()
            {
                Attachments = attachments,
                Content = request.Content,
                DestMail = request.DestMail,
                Subject = request.Subject
            };
            MailHelper.SendMail(mail);
            return Ok();
        }
    }
}
