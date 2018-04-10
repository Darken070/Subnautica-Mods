﻿using SMLHelper;
using SMLHelper.Patchers;
using System.Collections.Generic;
using UnityEngine;
using Utilites.Config;
using Logger = Utilites.Logger.Logger;
using LogType = Utilites.Logger.LogType;
using LogLevel = Utilites.Logger.LogLevel;
using System;
using Utilites.Logger;
using MoreIngots.MI;

namespace MoreIngots.MI
{
    /// <summary>
    /// Main class for loading the asset bundles
    /// </summary>
    public class LoadAssetBundles
    {
        public static AssetBundle moreingots;
        public static AssetBundle ingotsplus;
        public static AssetBundle moreingots_salt;
        public static AssetBundle ingotsplus_salt;
        /// <summary>
        /// Loads the asset bundles
        /// </summary>
        public static void Load()
        {
            try
            {
                Log.Debug("Loading asset bundles... (0/4)");
                moreingots = AssetBundle.LoadFromFile(@"./QMods/MoreIngots/Assets/moreingots.assets");
                Log.Debug("\"moreingots\" asset bundle loaded");
                Log.Debug("Loading asset bundles... (1/4)");
                ingotsplus = AssetBundle.LoadFromFile(@"./QMods/MoreIngots/Assets/yenzen-ingotsplus.assets");
                Log.Debug("\"yenzen-ingotsplus\" asset bundle loaded");
                Log.Debug("Loading asset bundles... (2/4)");
                moreingots_salt = AssetBundle.LoadFromFile(@"./QMods/MoreIngots/Assets/salt-alexejheroytb.assets");
                Log.Debug("\"salt-alexejheroytb\" asset bundle loaded");
                Log.Debug("Loading asset bundles... (3/4)");
                ingotsplus_salt = AssetBundle.LoadFromFile(@"./QMods/MoreIngots/Assets/salt-yenzen.assets");
                Log.Debug("\"salt-yenzen\" asset bundle loaded");
                Log.Debug("Loading asset bundles... (4/4)");
                Log.Debug("Asset bundles loaded");
            }
            catch (Exception e)
            {
                e.Log(LogType.Console);
            }
        }
    }
}