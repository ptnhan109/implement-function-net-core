using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recaptcha.Models
{
    public class CaptchaViewModel
    {
        public string SiteKey { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Error { get; set; }
    }
}
