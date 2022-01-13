﻿using HarmonyLib;
using NebulaModel.Logger;
using NebulaWorld;
using System;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;

namespace NebulaPatcher.Patches.Dynamic
{
    [HarmonyPatch(typeof(Resources))]
    public class Resources_Patch
    {
        [HarmonyPatch(typeof(Resources), "Load", typeof(string), typeof(Type))]
        [HarmonyPrefix]
        public static bool Prefix(ref string path, Type systemTypeInstance, ref Object __result)
        {
            if (path.Contains("TMP Settings"))
            {
                var asset = InGameChatAssetLoader.AssetBundle.LoadAsset<TMP_Settings>("Assets/Resources/TextMeshPro/TMP Settings.asset");
                if (asset != null)
                {
                    __result = asset;
                    Log.Debug("Successfully loaded TMP Settings");
                    return false;
                }

                Log.Warn("Failed to load TMP Settings!");
            }
            else if (path.StartsWith("TextMeshPro"))
            {
                var asset = InGameChatAssetLoader.AssetBundle.LoadAsset($"Assets/Resources/{path}");
                if (asset != null)
                {
                    __result = asset;
                    Log.Debug("Successfully loaded TMP asset");
                    return false;
                }

                Log.Warn($"Failed to load TMP asset: {path}!");
            }

            return true;
        }
    }
}