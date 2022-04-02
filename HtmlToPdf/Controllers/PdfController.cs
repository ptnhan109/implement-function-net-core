using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using HtmlToPdf.Helper;
using HtmlToPdf.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HtmlToPdf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly IConverter _convert;

        public PdfController(IConverter convert)
        {
            _convert = convert;
        }
        [HttpGet]
        public async Task<IActionResult> GeneratePdf()
        {
            string fileName = "Persons.pdf";
            var glb = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Landscape,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings()
                {
                    Bottom = 20,
                    Left = 20,
                    Right = 20,
                    Top = 30
                },
                DocumentTitle = "Persons",
                Out = Path.Combine(Directory.GetCurrentDirectory(), "Exports", fileName)
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = PersonHelper.ToHtmlFile(Person.GetData()),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = null }
            };
            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = glb,
                Objects = { objectSettings}
            };
            _convert.Convert(pdf);
            string result = $"Files{fileName}";
            await Task.Yield();
            return Ok(result);
        }
    }
}
