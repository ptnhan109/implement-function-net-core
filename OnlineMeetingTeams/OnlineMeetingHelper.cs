using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMeetingTeams
{
    public class OnlineMeetingHelper
    {
        public static async Task OnlineMeetingModel CreateOnlineMeeting(OnlineMeetingModel request, string AuthorizationCode)
        {
            string clientId = "a48bbd5a-13b1-4990-b00e-844e7d9d68e3";
            string clientKey = "8iY1COU52f__QCY0~x06GH_s2~uHk9YaF6";
            string redirectUrl = "https://localhost:2000";
            string authority = "https://login.microsoftonline.com/b0ee4cb6-0b05-4002-89c5-e29eb13f1330";
            string [] scopes = new string[] { "https://graph.micosoft.com/.default" };
            IConfidentialClientApplication app = ConfidentialClientApplicationBuilder
                .Create(clientId)
                .WithRedirectUri(redirectUrl)
                .WithClientSecret(clientKey)
                .WithAuthority(authority)
                .Build();
            AuthorizationCodeProvider auth = new AuthorizationCodeProvider(app,scopes);
            var authResult = await app.AcquireTokenByAuthorizationCode(scopes, AuthorizationCode).ExecuteAsync();
        }
    }
    public class OnlineMeetingModel
    {
        public string Subject { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
    }
}
