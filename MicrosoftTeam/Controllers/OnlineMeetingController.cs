using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MicrosoftTeam.Models;
using MicrosoftTeam.Services;

namespace MicrosoftTeam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineMeetingController : ControllerBase
    {
        private readonly IOnlineMeetingService _service;

        public OnlineMeetingController(IOnlineMeetingService service)
        {
            this._service = service;
        }
        [HttpGet]
        public async Task<IActionResult> CreateOnlineMeeting([FromQuery] string subject,string authenCode)
        {
            var result = await _service.CreateOnlineMeetingService(new OnlineMeetingModel()
            {
                authenCode = authenCode,
                Subject = "Test online meeting"
            });
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOnlineMeeting([FromBody] OnlineMeetingModel request)
        {
            var result = await _service.CreateOnlineMeetingService(request);
            return Ok(result);
        }
        
    }
}
