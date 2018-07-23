using Harmony;
using System.Reflection;
using UnityEngine;

namespace InfiniteOxygen
{
    public static class Main
    {
        public static void Patch()
        {
            HarmonyInstance.Create("alexejheroytb.subnauticamods.infiniteoxygen").PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(OxygenManager))]
    [HarmonyPatch("Update")]
    public static class OxygenManager_Update
    {
        [HarmonyPostfix]
        public static void Postfix(OxygenManager __instance)
        {
            __instance.AddOxygen(Time.deltaTime);
        }
    }
}
