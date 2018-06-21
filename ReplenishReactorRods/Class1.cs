using SMLHelper.Patchers;
using AlexejheroYTB.Utilities;
using System.Collections.Generic;
//using Harmony;
using System.Reflection;
using UnityEngine;

namespace ReplenishReactorRods
{
    public static class QPatch
    {
        //public static TechType RReactorRod = TechTypePatcher.AddTechType("ReplenishedReactorRod", "Replenished Reactor Rod", "Used to power nuclear reactors. Very unstable since it is reused");
        public static void Patch()
        {
            Items.AddDummy
            (
                name: "RReactorRodDUMMY",
                languageName: "Replenish Reactor Rod",
                languageTooltip: "Combine a depleted reactor rod with 3 uranium to replenish it!",
                spriteItem: TechType.DepletedReactorRod,
                fabricatorNodePath: "Resources/AdvancedMaterials/RReactorRod",
                ingredientItems: new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.DepletedReactorRod, 1),
                    new IngredientHelper(TechType.Uranium, 3)
                },
                resultingItems: TechType.ReactorRod,
                prefabPath: "WorldEntities/Natural/ReactorRod"
            );

            //HarmonyInstance Harmony = HarmonyInstance.Create("com.alexejheroytb.subnauticamods.replenishreactorrods");
            //Harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    /*[HarmonyPatch(typeof(BaseNuclearReactor))]
    [HarmonyPatch("ProducePower")]
    class BaseNuclearReactor_ProducePower_Patch
    {
        [HarmonyPrefix]
        static bool Prefix(BaseNuclearReactor __instance, float __result, float requested)
        {
            float num = 0f;
            if (requested > 0f)
            {
                object slotIDsField = typeof(BaseNuclearReactor).GetField("slotIDs", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(__instance);
                object equipmentField = typeof(BaseNuclearReactor).GetField("equipment", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(__instance);
                object chargeField = typeof(BaseNuclearReactor).GetField("charge", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(__instance);

                string[] slotIDs = slotIDsField as string[];
                Equipment equipment = equipmentField as Equipment;
                Dictionary<TechType, float> charge = chargeField as Dictionary<TechType, float>;

                __instance._toConsume += requested;
                num = requested;
                int num2 = 0;
                for (int i = 0; i < slotIDs.Length; i++)
                {
                    string slot = slotIDs[i];
                    InventoryItem itemInSlot = equipment.GetItemInSlot(slot);
                    if (itemInSlot != null)
                    {
                        Pickupable item = itemInSlot.item;
                        if (item != null)
                        {
                            TechType techType = item.GetTechType();
                            if (charge.TryGetValue(techType, out float num3))
                            {
                                if (__instance._toConsume < num3)
                                {
                                    num2++;
                                }
                                else
                                {
                                    __instance._toConsume -= num3;
                                    InventoryItem inventoryItem = equipment.RemoveItem(slot, true, false);
                                    Object.Destroy(inventoryItem.item.gameObject);
                                    if (techType == TechType.ReactorRod)
                                    {
                                        MethodInfo SpawnDepletedRod = typeof(BaseNuclearReactor).GetMethod("SpawnDepletedRod", BindingFlags.NonPublic | BindingFlags.Instance);
                                        SpawnDepletedRod.Invoke(__instance, null);
                                        equipment.AddItem(slot, SpawnDepletedRod.Invoke(__instance, null) as InventoryItem, true);
                                    }
                                    if (techType == QPatch.RReactorRod)
                                    {
                                        GameObject prefabForTechType = CraftData.GetPrefabForTechType(TechType.DepletedReactorRod, true);
                                        GameObject gameObject = Object.Instantiate(prefabForTechType);
                                        Pickupable pickupable = gameObject.GetComponent<Pickupable>().Pickup(false);
                                        equipment.AddItem(slot, new InventoryItem(pickupable), true);
                                    }
                                }
                            }
                        }
                    }
                }
                if (num2 == 0)
                {
                    num -= __instance._toConsume;
                    __instance._toConsume = 0f;
                }
            }
            __result = num;
            return false;
        }
    }*/
}
