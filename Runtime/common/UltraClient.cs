using System;
using System.Net;
using System.Threading.Tasks;

namespace Ultraio
{
    #region Delegates
    public delegate void InitSucceededHandler(string username, string idToken);
    public delegate void InitFailedHandler(UltraError error);
    #endregion
    public class UltraClient
    {
        #region Private Data
        private bool _initialized = false;
        private UserInfo _userInfo;
        private IAuthenticationFlow _authenticationFlow;
        #endregion

        #region Properties
        public bool Initialized
        {
            get { return _initialized; }
        }

        public string Username
        {
            get { return _userInfo.upn; }
        }
        #endregion

        #region Events
        /// <summary>Event triggered when Ultra Client initialization succeeded</summary>
        public event InitSucceededHandler InitializationSucceeded;

        /// <summary>Event triggered when Ultra Client initialization failed</summary>
        public event InitFailedHandler InitializationFailed;
        #endregion

        /// <summary>Initialize Ultra Client</summary>
        /// <param name="authenticationFlow">Authentication class implementing IAuthenticationFlow (OAuthDeviceFlow is the only one for now)</param>
        /// <returns>Async completion after authentication successed or failed</returns>
        public async void Init(IAuthenticationFlow authenticationFlow)
        {
            _userInfo = null;
            _authenticationFlow = authenticationFlow;
            _authenticationFlow.AuthenticationSuccessed += OnAuthenticationSuccess;
            _authenticationFlow.AuthenticationFailed += OnAuthenticationFailure;
            _initialized = await _authenticationFlow.Authenticate();
        }

        private async void OnAuthenticationSuccess(UltraToken ultraToken)
        {
            UnregisterAuthenticationCallbacks();
            string idToken = ultraToken.id_token;
            _userInfo = await _authenticationFlow.GetUserInfo();
            InitializationSucceeded(_userInfo.upn, idToken);
        }

        private void OnAuthenticationFailure(UltraError error)
        {
            UnregisterAuthenticationCallbacks();
            InitializationFailed(error);
        }

        private void UnregisterAuthenticationCallbacks() {
            _authenticationFlow.AuthenticationSuccessed -= OnAuthenticationSuccess;
            _authenticationFlow.AuthenticationFailed -= OnAuthenticationFailure;
        }
    }
}