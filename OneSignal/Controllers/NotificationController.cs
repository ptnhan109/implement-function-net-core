using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OneSignal.Helper;
using OneSignal.Models;

namespace OneSignal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public NotificationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody]CreateNotificationModel request)
        {
            Guid appId = Guid.Parse(_configuration.GetSection(AppSettingKey.OneSignalAppId).Value);
            string restKey = _configuration.GetSection(AppSettingKey.OneSignalRestKey).Value;
            string result =  await OneSignalPushNotificationHelper.OneSignalPushNotification(request, appId, restKey);
            return Ok(result);
        }
        [HttpPost("displayed")]
        public async Task<IActionResult> CatchNotificationDisplayed([FromBody] NotificationDislayedRequest request)
        {
            return Ok(await OneSignalPushNotificationHelper.WebhooksDisplayed(request));
        }
    }
}
