using SMLHelper;
using SMLHelper.Patchers;
using System.Collections.Generic;
using UnityEngine;
using Utilites.Config;
using Logger = Utilites.Logger.Logger;
using LogType = Utilites.Logger.LogType;
using LogLevel = Utilites.Logger.LogLevel;
using System;
using Utilites.Logger;

namespace CustomItemSizes
{
    public class QPatch
    {
        public static void Patch()
        {
            Load();
        }
        public static void Load()
        {
            foreach (TechType tt in Enum.GetValues(typeof(TechType)))
            {
            }
        }
    }
}
