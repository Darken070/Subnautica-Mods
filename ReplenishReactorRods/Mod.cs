using SMLHelper.Patchers;
using AlexejheroYTB.Utilities;
using System.Collections.Generic;
using Harmony;
using System.Reflection;
using UnityEngine;
using AlexejheroYTB.Utilities.Extensions;
using SMLHelper;

namespace ReplenishReactorRods
{
    public static class Mod
    {
        public static TechType RRRItem = TechTypePatcher.AddTechType("ReplenishedReactorRod", "Replenished Reactor Rod", "Used to power nuclear reactors. Very unstable since it was reused");
        public static void QPatch()
        {
            Items.AddDummy
            (
                name: "RRRDUMMY",
                languageName: "Replenish Reactor Rod",
                languageTooltip: "Combine a depleted reactor rod with 3 uranium to replenish it!",
                spriteItem: TechType.DepletedReactorRod,
                fabricatorNodePath: "Resources/AdvancedMaterials/RRRDUMMY",
                ingredientItems: new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.DepletedReactorRod, 1),
                    new IngredientHelper(TechType.UraniniteCrystal, 3)
                },
                resultingItems: TechType.ReactorRod,
                prefabPath: "WorldEntities/Natural/ReactorRod"
            );

            TechDataHelper data = new TechDataHelper()
            {
                _techType = RRRItem,
                _craftAmount = 1,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.DepletedReactorRod, 1),
                    new IngredientHelper(TechType.UraniniteCrystal, 3)
                },
            };

            CraftDataPatcher.customTechData.Add(RRRItem, data);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(RRRItem, CraftTree.Type.Fabricator, "Resources/AdvancedMaterials/RRRItem"));

            Dictionary<TechType, float> charge = Values.GetValue<BaseNuclearReactor>("charge") as Dictionary<TechType, float>;
            charge.Add(RRRItem, 15000f);

            Values.SetValue<BaseNuclearReactor>("charge", charge);

            HarmonyInstance.Create("alexejheroytb.subnauticamods.replenishreactorrods").PatchAll();
        }
    }

    [HarmonyPatch(typeof(BaseNuclearReactor))]
    [HarmonyPatch("BaseNuclearReactor")]
    public static class BaseNuclearReactor_ProducePower
    {
        [HarmonyPrefix]
        public static bool Prefix(BaseNuclearReactor __instance, float __result, float requested)
        {
            string[] slotIDs = Values.GetValue<BaseNuclearReactor>("slotIDs") as string[];
            Equipment equipment = Values.GetValue(__instance, "equipment") as Equipment;
            Dictionary<TechType, float> charge = Values.GetValue<BaseNuclearReactor>("charge") as Dictionary<TechType, float>;

            GameObject prefabForTechType = CraftData.GetPrefabForTechType(TechType.DepletedReactorRod, true);
            GameObject gameObject = Object.Instantiate<GameObject>(prefabForTechType);
            Pickupable pickupable = gameObject.GetComponent<Pickupable>().Pickup(false);
            InventoryItem depletedRod = new InventoryItem(pickupable);

            float num = 0f;
            if (requested > 0f)
            {
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
                                    equipment.AddItem(slot, depletedRod, true);
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
    }
}
