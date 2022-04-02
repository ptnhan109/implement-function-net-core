using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OpenXMLSample.Helper
{
    public class FileHelper
    {
        public static async Task<string> Upload(IFormFile file)
        {
            var fileName = $"{Guid.NewGuid()}__{file.FileName}";
            string fullPath = "uploads\\" + fileName;
            using(var stream = File.Create(fullPath))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }
    }
}
