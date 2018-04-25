using Harmony;
using SMLHelper;
using SMLHelper.Patchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using Utilites.Logger;
using Logger = Utilites.Logger.Logger;
using LogType = Utilites.Logger.LogType;
using static MoreHullPlates.Log;

namespace MoreHullPlates
{
    public class QPatch
    {
        public static TechType tt;
        public static TechDataHelper td;

        public static GameObject Main()
        {
            var prefab = Resources.Load<GameObject>("Submarine/Build/HullPlate01");
            var obj = UnityEngine.Object.Instantiate(prefab);

            var constructable = obj.GetComponent<Constructable>();
            var techTag = obj.GetComponent<TechTag>();
            var prefabIdentifier = obj.GetComponent<PrefabIdentifier>();
            var largeWorldEntity = obj.AddComponent<LargeWorldEntity>();

            constructable.techType = tt;
            constructable.allowedInBase = true;
            constructable.allowedInSub = true;
            constructable.allowedOutside = false;
            constructable.allowedOnCeiling = false;
            constructable.allowedOnConstructables = false;
            constructable.allowedOnGround = false;
            constructable.allowedOnWall = true;
           
            techTag.type = tt;

            prefabIdentifier.ClassId = "testhull";

            largeWorldEntity.cellLevel = LargeWorldEntity.CellLevel.Global;

            return obj;
        }
        public static void Patch()
        {
            try
            {
                Logger.ClearCustomLog();
                tt = TechTypePatcher.AddTechType("testhull", "Test hull", "Test hull");
                CraftDataPatcher.customBuildables.Add(tt);
                CraftDataPatcher.AddToCustomGroup(TechGroup.Miscellaneous, TechCategory.MiscHullplates, tt);
                CustomPrefabHandler.customPrefabs.Add(new CustomPrefab("testhull", "Submarine/Build/MHItest", tt, Main));
                var sprite = SpriteManager.Get(TechType.SpecialHullPlate);
                CustomSpriteHandler.customSprites.Add(new CustomSprite(tt, sprite));
                var techData = new TechDataHelper
                {
                    _craftAmount = 1,
                    _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.Titanium, 2)
                }
                };
                CraftDataPatcher.customTechData.Add(tt, techData);
            }
            catch (Exception e)
            {
                Log.e(e);
            }
        }
    }

}
