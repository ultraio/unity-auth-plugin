using UnityEngine;
using UnityEditor;

namespace Ultraio.Plugin
{
    public class UltraConfigurationEditor : EditorWindow
    {
        [MenuItem("Ultra/Settings")]
        public static void ShowWindow()
        {
            var configuration = Resources.Load<PluginConfigurationTemplate>(PluginConfigurationConstants.AssetFile);
            if (configuration == null)
            {
                configuration = CreateInstance<PluginConfigurationTemplate>();
                if (!AssetDatabase.IsValidFolder($"{PluginConfigurationConstants.AssetsFolder}/{PluginConfigurationConstants.ResourcesFolder}"))
                {
                    AssetDatabase.CreateFolder(PluginConfigurationConstants.AssetsFolder, PluginConfigurationConstants.ResourcesFolder);
                }
                AssetDatabase.CreateAsset(configuration, $"{PluginConfigurationConstants.AssetPath}.asset");
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
            AssetDatabase.OpenAsset(configuration);
        }
    }
}