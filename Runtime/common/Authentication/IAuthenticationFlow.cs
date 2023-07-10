using System;
using System.Net;
using System.Threading.Tasks;

namespace Ultraio
{
    public delegate void AuthenticationSuccessedHandler(UltraToken ultraToken);
    public delegate void AuthenticationFailedHandler(UltraError error);

    public interface IAuthenticationFlow
    {
        event AuthenticationSuccessedHandler AuthenticationSuccessed;
        event AuthenticationFailedHandler AuthenticationFailed;
        Task<bool> Authenticate();
        Task<UserInfo> GetUserInfo();
    }
}