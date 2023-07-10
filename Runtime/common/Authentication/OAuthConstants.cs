namespace Ultraio
{
    public static class OAuthConstants
    {
        #region Paths
        public const string DevicePath = "/auth/device";
        public const string TokenPath = "/token";
        public const string UserInfoPath = "/userinfo";
        #endregion

        #region Device Flow constants
        public const string ClientId = "client_id";
        public const string Scope = "scope";
        public const string DefaultScope = "openid";
        public const string DeviceCode = "device_code";
        public const string GrantType = "grant_type";
        public const string DefaultGrantType = "urn:ietf:params:oauth:grant-type:device_code";
        #endregion 

        #region Authorization Parameters
        public const string Authorization = "Authorization";
        public const string Bearer = "Bearer";
        #endregion
    }
}