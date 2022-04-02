using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smtp.Models
{
    public class Mail
    {
        public string Subject { get; set; }
        public string DestMail { get; set; }
        public string Content { get; set; }
        public List<MailAttachment> Attachments { get; set; }
    }
    public class MailAttachment
    {
        public byte[] Stream { get; set; }
        public string ContentType { get; set; }
    }
}
