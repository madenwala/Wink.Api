using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;
using Wink.Api.Extensions;

namespace Wink.Api.Uwp
{
    public sealed class AuthProvider : IAuthProvider
    {
        public async Task<string> AuthenticateAsync(Uri authenticationUri, string callbackUrl, CancellationToken ct)
        {
            var result = await WebAuthenticationBroker.AuthenticateAsync(
                       WebAuthenticationOptions.None,
                       authenticationUri,
                       new Uri(callbackUrl));

            if (result.ResponseStatus == WebAuthenticationStatus.Success)
                return new Uri(result.ResponseData.ToString()).GetQueryParameter("code");
            else if (result.ResponseStatus == WebAuthenticationStatus.ErrorHttp)
                Debug.WriteLine("HTTP Error returned by AuthenticateAsync() : " + result.ResponseErrorDetail.ToString());

            return null;
        }
    }
}