using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Utilites.Logger;
using static MoreHullPlates.FormatEx;

namespace MoreHullPlates
{
    public class PatchHarmony
    {
        public static void HarmonyPatch()
        {
            try
            {
                var harmony = HarmonyInstance.Create("alexejheroytb.morehullplates");
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception e)
            {
                Logger.Error("MoreIngots patch failed", LogType.Console);
                Logger.Error(FormatException(e), LogType.Console);
            }

        }
    }
}
