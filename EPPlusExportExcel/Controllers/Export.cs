using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EPPlusExportExcel.Helper;
using EPPlusExportExcel.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPPlusExportExcel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Export : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetExcelFiles()
        {
            byte[] data = await ExportExcelHelper.GenerateExcelFile(EmployeeRepository.EmployeeData());
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Exports", "export.xlsx");
            System.IO.File.WriteAllBytes(filePath, data);
            return Ok(filePath);
        }
    }
}
