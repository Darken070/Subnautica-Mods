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
