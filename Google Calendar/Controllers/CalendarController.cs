using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google_Calendar.Helper;
using Google_Calendar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Google_Calendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateGoogleCalendar([FromBody] GoogleCalendar request)
        {
            return Ok(await GoogleCalendarHelper.CreateGoogleCalendar(request));
        }
    }
}
