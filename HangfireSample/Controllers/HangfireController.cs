using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HangfireSample.JobHelper;
namespace HangfireSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangfireController : ControllerBase
    {
        [HttpGet]
        public IActionResult TestConsole()
        {
            System.Diagnostics.Debug.Write("test");
            return Ok();
        }
        [HttpGet("enqueue")]
        public IActionResult EnqueueJob()
        {
            JobHelper.JobHelper job = new JobHelper.JobHelper();
            job.Enqueue();
            return Ok();
        }
        [HttpGet("schedule")]
        public IActionResult ScheduleJob()
        {
            JobHelper.JobHelper job = new JobHelper.JobHelper();
            job.Schedule();
            return Ok();
        }
    }
}
