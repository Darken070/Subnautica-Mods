using System;
using Utilites.Config;
using Utilites.Logger;
using SMLHelper.Patchers;

namespace CustomItemSizes
{
    public class QPatch
    {
        public static readonly ConfigFile Config = new ConfigFile("config");

        public static void Patch()
        {
            try
            {
                Config.Load();
                foreach (TechType techType in Enum.GetValues(typeof(TechType)))
                {
                    var name = techType.ToString();
                    var x = CraftData.GetItemSize(techType).x;
                    var y = CraftData.GetItemSize(techType).y;
                    var configChanged =
                      Config.TryGet(ref x, name, "X")
                    | Config.TryGet(ref y, name, "Y");
                    if (configChanged)
                        Config.Save();
                    if (x < 1)
                    {
                        Logger.Warning("[" + name + "] X can't be less than 1. It was set to the default value");
                        x = CraftData.GetItemSize(techType).x;
                    }
                    if (x > 6)
                    {
                        Logger.Warning("[" + name + "] X can't be greater than 1. It was set to the default value");
                        x = CraftData.GetItemSize(techType).x;
                    }
                    if (y < 1)
                    {
                        Logger.Warning("[" + name + "] Y can't be less than 1. It was set to the default value");
                        y = CraftData.GetItemSize(techType).x;
                    }
                    if (y > 8)
                    {
                        Logger.Warning("[" + name + "] Y can't be greater than 8. It was set to the default value");
                        y = CraftData.GetItemSize(techType).x;
                    }
                    CraftDataPatcher.customItemSizes[techType] = new Vector2int(x, y);
                }
            }
            catch (Exception e)
            {
                e.Log(LogType.Console);
            }
        }
    }
}
