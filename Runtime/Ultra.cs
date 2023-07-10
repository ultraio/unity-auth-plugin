namespace Ultraio
{
    public static class Ultra
    {
        #region Private Fields
        private static bool _useBrowser = false;
        #endregion
        #region Properties

        /// <summary>
        /// Ultra layer holding user information and using Ultra authentication strategy
        /// </summary>
        public static UltraClient Client
        {
            get; private set;
        }

        /// <summary>
        /// True if the Ultra SDK is initialized
        /// </summary>
        public static bool Initialized
        {
            get { return Client.Initialized; }
        }

        /// <summary>
        /// Use the browser to authenticate instead of the Ultra Client
        /// </summary>
        public static bool UseBrowser
        { 
            get { return _useBrowser; }
            set { _useBrowser = value; }
        }

        /// <summary>
        /// True if the game was launched from the Ultra desktop application
        /// </summary>
        public static bool LaunchedFromUltraClient
        {
            get { return LaunchConfiguration.LaunchedFromUltraClient; }
        }
        #endregion

        static Ultra()
        {
            Client = new UltraClient();
        }

        /// <summary>
        /// Initialize the Ultra client and authenticate the player based on the Unity Ultra Settings window
        /// </summary>
        /// <param name="successCallback">Init success callback</param>
        /// <param name="failureCallback">Init failure callback</param>
        public static void Init(InitSucceededHandler successCallback = null, InitFailedHandler failureCallback = null)
        {
            Init(PluginConfiguration.AuthenticationUrl,
                PluginConfiguration.ClientId,
                PluginConfiguration.ApplicationProtocol,
                successCallback,
                failureCallback);
        }

        /// <summary>
        /// Initialize Ultra client and authenticate the player with programmatic configuration (not using the Unity Ultra setting window)
        /// </summary>
        /// <param name="authUrl">The authentication server URL (OIDC compliant supporting the device grant flow)</param>
        /// <param name="clientId">Client id of the application</param>
        /// <param name="applicationProtocol">The deeplink protocol used to communicate with the desktop application (use ultra for production)</param>
        /// <param name="successCallback">Init success callback</param>
        /// <param name="failureCallback">Init failure callback</param>
        public static void Init(string authUrl, string clientId, string applicationProtocol, InitSucceededHandler successCallback = null, InitFailedHandler failureCallback = null)
        {
            var authenticationFlow = new OAuthDeviceFlow(authUrl, clientId, applicationProtocol, UseBrowser);
            if (successCallback != null)
            {
                Client.InitializationSucceeded += successCallback;
            }
            if (failureCallback != null)
            {
                Client.InitializationFailed += failureCallback;
            }
            Client.Init(authenticationFlow);
        }
    }
}