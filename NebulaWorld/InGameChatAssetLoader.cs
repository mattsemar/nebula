using NebulaModel.Logger;
using NebulaWorld.MonoBehaviours.Local;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace NebulaWorld
{
    public static class InGameChatAssetLoader
    {
        private static ChatManager chatManager;
        private static AssetBundle _assetBundle;

        public static AssetBundle AssetBundle
        {
            get
            {
                if (_assetBundle == null)
                {
                    var pluginfolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    if (pluginfolder == null)
                    {
                        Log.Warn($"plugin folder is null, unable to load chat");
                        return null;
                    }

                    var fullAssetPath = Path.Combine(pluginfolder, "Assets", "nebulabundle");
                    _assetBundle = AssetBundle.LoadFromFile(fullAssetPath);
                }

                return _assetBundle;
            }
        }
    }
}