using BarCode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BarCode.Helper;
using System.IO;
namespace BarCode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<JsonResult> GenerateBarCode(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return Json(false);
            }

            await BarCodeHelper.GenerateBarCode(data);

            return Json(true);
        }

        [HttpGet]
        public async Task<JsonResult> PrintBarCode()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "print-barcode-template.html");
            string content = System.IO.File.ReadAllText(path);
            var replace = new System.Text.StringBuilder();
            for(int i = 0; i < 60 ; i++)
            {
                replace.Append(@"<img src='/barcode.png' class='item' />");
            }

            content = content.Replace("{content}", replace.ToString());
            await Task.Yield();
            return Json(content);
        }
    }
}
