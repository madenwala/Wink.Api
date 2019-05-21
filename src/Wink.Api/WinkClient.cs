using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Wink.Api.Extensions;
using Wink.Api.Models;

namespace Wink.Api
{
    public sealed class WinkClient : BaseClientApi
    {
        #region Variables

        private const string BASE_URL = "https://api.wink.com";
        public static string CLIENT_ID = string.Empty;
        public static string CLIENT_SECRET = string.Empty;
        public static string REDIRECT_URL = string.Empty;
        public UserAuthentication UserAuthentication { get; set; }

        #endregion

        #region Constructors

        public WinkClient() : base(BASE_URL)
        {
        }

        #endregion

        #region Methods

        #region Private

        private void SetHeaders()
        {
            if (this.UserAuthentication == null)
                throw new UnauthorizedAccessException("User is not authenticated!");

            this.Client.DefaultRequestHeaders.Clear();
            this.Client.DefaultRequestHeaders.Accept.Clear();
            this.Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string AUTHORIZATION = "authorization";
            if (!string.IsNullOrEmpty(this.UserAuthentication?.access_token))
                this.Client.DefaultRequestHeaders.Add(AUTHORIZATION, $"{this.UserAuthentication.token_type} {this.UserAuthentication.access_token}");
            else if (this.Client.DefaultRequestHeaders.Contains(AUTHORIZATION))
                this.Client.DefaultRequestHeaders.Remove(AUTHORIZATION);
        }

        #endregion

        #region Authentication

        public async Task<UserAuthentication> AuthenticateAsync(IAuthProvider authProvider, CancellationToken ct, string state = null, string response_type = "code")
        {
            if (this.UserAuthentication != null)
            {
                try
                {
                    this.UserAuthentication = await this.RefreshTokenAsync(ct);
                    if (this.UserAuthentication != null)
                        return this.UserAuthentication;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Reauthentication through AuthenticateAsync failed: " + ex.ToString());
                }
            }

            var uri = this.CreateRequestUri($"/oauth2/authorize?response_type={response_type}&client_id={CLIENT_ID}&redirect_uri={REDIRECT_URL}&state={state}");
            var authorizationCode = await authProvider.AuthenticateAsync(uri, REDIRECT_URL, ct);
            if (authorizationCode != null)
                this.UserAuthentication = await this.GetAccessTokenAsync(authorizationCode, ct);
            else
                this.UserAuthentication = null;

            return this.UserAuthentication;
        }

        private async Task<UserAuthentication> GetAccessTokenAsync(string authorizationCode, CancellationToken ct)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("client_secret", CLIENT_SECRET);
            dic.Add("grant_type", "authorization_code");
            dic.Add("code", authorizationCode);
            var json = JsonConvert.SerializeObject(dic);
            var content = new StringContent(json);

            this.Client.DefaultRequestHeaders.Clear();
            this.UserAuthentication = await this.PostAsync<UserAuthentication>("/oauth2/token" + dic.ToQueryString(), ct);
            return this.UserAuthentication;
        }

        public async Task<UserAuthentication> RefreshTokenAsync(CancellationToken ct)
        {
            string url = $"/oauth2/token?client_id={CLIENT_ID}&client_secret={CLIENT_SECRET}&grant_type=refresh_token&refresh_token={this.UserAuthentication.refresh_token}";
            this.UserAuthentication = await this.PostAsync<UserAuthentication>(url, ct);
            return this.UserAuthentication;
        }

        #endregion
        
        #region Device

        public Task<Response<WinkModelList<BaseDevice>>> GetDevices(CancellationToken ct)
        {
            var url = "/users/me/wink_devices";
            // TODO for each device, convert to its model type
            return this.GetAsync<Response<WinkModelList<BaseDevice>>>(url, ct);
        }

        public Task<T> GetDevice<T>(BaseDevice device, CancellationToken ct)
        {
            var url = $"/{device.object_type}/{device.object_id}";
            return this.GetAsync<T>(url, ct);
        }

        #endregion

        #region Sharing

        public Task<Response<WinkModelList<User>>> GetDeviceSharedUsers(BaseDevice device, CancellationToken ct)
        {
            var url = $"/{device.object_type}/{device.object_id}/users";
            return this.GetAsync<Response<WinkModelList<User>>>(url, ct);
        }

        public Task<Response<WinkModelList<User>>> ShareDevice(BaseDevice device, User user, CancellationToken ct)
        {
            var url = $"/{device.object_type}/{device.object_id}/users";
            var content = new StringContent(JsonConvert.SerializeObject(user.email));
            return this.PostAsync<Response<WinkModelList<User>>>(url, ct, content);
        }

        public Task<Response<WinkModelList<User>>> UnshareDevice(BaseDevice device, User user, CancellationToken ct)
        {
            var url = $"/{device.object_type}/{device.object_id}/users/{user.email}";
            return this.DeleteAsync<Response<WinkModelList<User>>>(url, ct);
        }

        #endregion

        #region Member
        #endregion

        #region Group
        #endregion

        #region Scene
        #endregion

        #region Robot
        #endregion

        #region User
        #endregion

        #endregion
    }
}