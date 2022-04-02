using EPPlusExportExcel.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPPlusExportExcel.Helper
{
    public class ExportExcelHelper
    {
        public static async Task<byte[]> GenerateExcelFile(List<Employee> employees)
        {
            var package = new ExcelPackage();
            var workSheet = package.Workbook.Worksheets.Add("Gallagher");
            // create title
            workSheet.Cells["A1:F1"].Merge = true;
            workSheet.Cells["A1"].Value = "Gallagher Family";
            workSheet.Cells["A1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells["A1"].Style.Font.Bold = true;
            // fill header
            List<string> listHeader = new List<string>()
            {
                "A2","B2","C2","D2","E2","F2"
            };
            listHeader.ForEach(c =>
            {
                workSheet.Cells[c].Style.Font.Bold = true;
                workSheet.Cells[c].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[c].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[c].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[c].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            });
            workSheet.Cells[listHeader[0]].Value = "#";
            workSheet.Cells[listHeader[1]].Value = "Id";
            workSheet.Cells[listHeader[2]].Value = "Name";
            workSheet.Cells[listHeader[3]].Value = "Age";
            workSheet.Cells[listHeader[4]].Value = "Phone";
            workSheet.Cells[listHeader[5]].Value = "Address";
            //fill data
            for(int i = 0; i < employees.Count; i++)
            {
                workSheet.Cells[i + 2, 1].Value = (i + 1).ToString();
                workSheet.Cells[i + 2, 2].Value = employees[i].Id;
                workSheet.Cells[i + 2, 3].Value = employees[i].Name;
                workSheet.Cells[i + 2, 4].Value = employees[i].Age;
                workSheet.Cells[i + 2, 5].Value = employees[i].Phone;
                workSheet.Cells[i + 2, 6].Value = employees[i].Address;
            }
            // format column width
            for(int i = 1; i < 7; i++)
            {
                workSheet.Column(i).Width = 10;
            }
            // format cell border
            for(int i = 0; i < employees.Count; i++)
            {
                for(int j = 1; j < 7; j++)
                {
                    workSheet.Cells[i + 2, j].Style.Font.Size = 10;
                    workSheet.Cells[i + 2, j].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[i + 2, j].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[i + 2, j].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[i + 2, j].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }
            }
            return await package.GetAsByteArrayAsync();
        }
    }
}
