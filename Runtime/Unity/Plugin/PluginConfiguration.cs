using UnityEngine;

namespace Ultraio
{
    public static class PluginConfiguration
    {
        private static PluginConfigurationTemplate configuration;

        public static string AuthenticationUrl
        {
            get { return configuration.authenticationUrl; }
        }

        public static string ClientId
        {
            get { return configuration.clientId; }
        }
        public static string ApplicationProtocol
        {
            get { return configuration.applicationProtocol; }
        }

        static PluginConfiguration()
        {
            configuration = Resources.Load<PluginConfigurationTemplate>(PluginConfigurationConstants.AssetFile);
            if (configuration == null)
            {
                Debug.LogError($"{PluginConfigurationConstants.AssetFile} could not be found. Open Ultra/Settings to generate the configuration file.");
            }
        }
    }
}