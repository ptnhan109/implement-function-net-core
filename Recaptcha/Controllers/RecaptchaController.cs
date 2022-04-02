using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Recaptcha.Helper;
using Recaptcha.Models;
using Recaptcha.Options;

namespace Recaptcha.Controllers
{
    public class RecaptchaController : Controller
    {
        private readonly RecaptchaOption _option;
        private readonly RecaptchaHelper _helper;

        public RecaptchaController(IOptions<RecaptchaOption> option)
        {
            _option = option.Value;
            _helper = new RecaptchaHelper(option);
        }

        public IActionResult Index()
        {
            var model = new CaptchaViewModel()
            {
                SiteKey = _option.SiteKey
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Register(CaptchaViewModel model)
        {
            string captchaResponse = Request.Form["g-recaptcha-response"].ToString();
            var validate = _helper.ValidateCaptcha(captchaResponse);
            if (!validate.Success)
            {
                model.Error = "Finish captcha";
                return RedirectToAction("Index", model);
            }
            model.Error = "Registered.";

            return RedirectToAction("Index");
        }
    }
}
