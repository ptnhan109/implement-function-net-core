using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using MicrosoftTeam.Common;
using MicrosoftTeam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MicrosoftTeam.Services
{
    public interface IOnlineMeetingService
    {
        Task<string> CreateOnlineMeetingService(OnlineMeetingModel model);
    }
    public class OnlineMeetingService : IOnlineMeetingService
    {
        private readonly IConfiguration _config;

        public OnlineMeetingService(IConfiguration config)
        {
            this._config = config;
        }
        public async Task<string> CreateOnlineMeetingService(OnlineMeetingModel model)
        {
            model.TimeStart = DateTime.Now;
            model.TimeEnd = DateTime.Now.AddHours(8);
            OnlineMeeting meeting = new OnlineMeeting()
            {
                StartDateTime = model.TimeStart,
                EndDateTime = model.TimeEnd,
                Subject = model.Subject
            };
            var service = await GetGraphService(model.authenCode);
            OnlineMeeting result = await service.Me.OnlineMeetings.Request().AddAsync(meeting);
            return result.JoinWebUrl;
        }
        private async Task<GraphServiceClient> GetGraphService(string codeAuthencation)
        {
            string clientId = _config.GetSection(AppSettingKey.ClientId).Value;
            string secret = _config.GetSection(AppSettingKey.SecretKey).Value;
            string tanent = _config.GetSection(AppSettingKey.TanentId).Value;
            string authenUrl = _config.GetSection(AppSettingKey.AuthenUrl).Value;
            string redirectUrl = _config.GetSection(AppSettingKey.RedirectUrl).Value;
            string authority = String.Format("{0}{1}", authenUrl, tanent);
            string[] scopes = new string[] { "https://graph.microsoft.com/.default" };
            IConfidentialClientApplication app = ConfidentialClientApplicationBuilder
                .Create(clientId)
                .WithRedirectUri(redirectUrl)
                .WithClientSecret(secret)
                .WithAuthority(authority)
                .Build();
            AuthorizationCodeProvider auth = new AuthorizationCodeProvider(app, scopes);
            var authenResult = await app.AcquireTokenByAuthorizationCode(scopes, codeAuthencation).ExecuteAsync();
            GraphServiceClient service = new GraphServiceClient(new DelegateAuthenticationProvider(
                async (request) =>
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authenResult.AccessToken);
                    await Task.Yield();
                }
                ));
            return service;
        }
    }
}
