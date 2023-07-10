using UnityEngine;

namespace Ultraio
{
    public class PluginConfigurationTemplate : ScriptableObject
    {
        [Tooltip("Url of the Ultra OIDC Server")]
        public string authenticationUrl = PluginConfigurationConstants.DefaultAuthUrl;
        [Tooltip("Ultra OIDC Client Id")]
        public string clientId;
        [Tooltip("Application Protocol")]
        public string applicationProtocol = PluginConfigurationConstants.DefaultApplicationProtocol;
    }
}