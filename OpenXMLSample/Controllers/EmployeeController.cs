using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenXMLSample.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OpenXMLSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> ImportEmployee()
        {
            var files = Request.Form.Files;
            if (!files.Any())
            {
                return BadRequest();
            }
            // upload file
            var file = files.FirstOrDefault();
            string fileName = await Helper.FileHelper.Upload(file);

            // readfile
            string path = Path.Combine(Directory.GetCurrentDirectory(), "uploads", fileName);
            var word = WordprocessingDocument.Open(path, true);
            var paragraphs = word.MainDocumentPart.Document.Body.Descendants<Paragraph>().ToList();
            var employee = new Employee()
            {
                Address = paragraphs[EmployeeIndex.Address].InnerText.GetEmployeeProp(),
                CellPhone = paragraphs[EmployeeIndex.CellPhone].InnerText.GetEmployeeProp(),
                DayOfBirth = DateTime.Parse(paragraphs[EmployeeIndex.DayOfBirth].InnerText.GetEmployeeProp()),
                Email = paragraphs[EmployeeIndex.Email].InnerText.GetEmployeeProp(),
                HomePhone = paragraphs[EmployeeIndex.HomePhone].InnerText.GetEmployeeProp(),
                Intro = paragraphs[EmployeeIndex.Intro].InnerText,
                Name = paragraphs[EmployeeIndex.Name].InnerText.GetEmployeeProp()
            };

            var tables = word.MainDocumentPart.RootElement.Descendants<Table>().ToList();
            var rows = tables[0].Elements<TableRow>().ToList();
            rows.RemoveAt(0);
            var exps = new List<WorkExperience>();
            foreach(var row in rows)
            {
                var cells = row.Descendants<TableCell>().ToList();
                var exp = new WorkExperience()
                {
                    Company = cells[1].InnerText,
                    Start = DateTime.ParseExact(cells[2].InnerText.Split("–")[0].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    End = DateTime.ParseExact(cells[2].InnerText.Split("–")[1].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Role = cells[3].InnerText
                };
                exps.Add(exp);
            }

            employee.WorkExperiences = exps;
            return Ok(employee);
        }
        
        [HttpPost("export")]
        public async Task<IActionResult> ExportEmployee()
        {
            var emp = new Employee()
            {
                Address = "Address",
                CellPhone = "0123456789",
                DayOfBirth = DateTime.Now.AddYears(-20),
                Email = "philip@gallagher.com",
                HomePhone = "0987654321",
                Intro = "Intro",
                Name = "Name"
            };
            var path = Path.Combine(Directory.GetCurrentDirectory(), "templates", "templates.docx");
            byte[] files;
            using (var word = WordprocessingDocument.Open(path, true))
            {
                var name = word.MainDocumentPart.RootElement.Descendants<Text>().FirstOrDefault(c => c.Text.Contains("{FullName}"));
                if (name != null)
                {
                    word.MainDocumentPart.RootElement.Descendants<Text>().FirstOrDefault(c => c.Text.Contains("{FullName}")).Text = emp.Name;
                }

                word.MainDocumentPart.RootElement.Descendants<Text>().FirstOrDefault(c => c.Text.Contains("{Address}")).Text = emp.Address;

                word.MainDocumentPart.RootElement.Descendants<Text>().FirstOrDefault(c => c.Text.Contains("{Email}")).Text = emp.Email;

                word.MainDocumentPart.RootElement.Descendants<Text>().FirstOrDefault(c => c.Text.Contains("{HomePhone}")).Text = emp.HomePhone;

                word.MainDocumentPart.RootElement.Descendants<Text>().FirstOrDefault(c => c.Text.Contains("{CellPhone}")).Text = emp.CellPhone;

                string exportName = $"Export_{Guid.NewGuid()}.docx";
                string newPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads", exportName);

                word.SaveAs(newPath);
                files = System.IO.File.ReadAllBytes(newPath);
            }

             

            return File(
                fileContents: files,
                contentType: "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                fileDownloadName: "tem.docx"
                );

        }
    }
}
