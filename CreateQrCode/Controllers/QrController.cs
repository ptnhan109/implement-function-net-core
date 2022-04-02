using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreateQrCode.QrCodeHelper;
using CreateQrCode.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreateQrCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QrController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GenerateQrCode()
        {
            await Task.Yield();
            return Ok("");
        }
        [HttpPost]
        public async Task<IActionResult> GenerateQrCode([FromBody] CreateQrRequest request)
        {
            string url = QrCodeGenerate.GenerateQrCode(request.Content, request.Name);
            await Task.Yield();
            return Ok(url);
        }
    }
}
