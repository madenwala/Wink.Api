using System;
using System.Threading;
using System.Threading.Tasks;

namespace Wink.Api
{
    public interface IAuthProvider
    {
        Task<string> AuthenticateAsync(Uri authenticationUri, string callbackUrl, CancellationToken ct);
    }
}