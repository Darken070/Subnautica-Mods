using SMLHelper;
using SMLHelper.Patchers;
using UnityEngine;

namespace MoreHullPlates.HullPlates
{
    public partial class Load
    {
        private static GameObject cougarprefab()
        {
            return Prefab.Get(cougaritem, "HullCougarific", cougartexture);
        }

        private static TechType cougaritem = TechTypePatcher.AddTechType("HullCougarific", "Cougarific Hull Plate", "Subnautica content creator. Makes mod reviews and modded playthroughs");

        private static Texture2D cougartexture = 
            AssetBundle.LoadFromFile($@"./QMods/MoreHullPlates/Assets/cougarific.assets").
            LoadAsset<UnityEngine.Sprite>("Cougarific").texture;

        public static void Cougarific()
        {
            CraftDataPatcher.customBuildables.Add(cougaritem);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Miscellaneous, TechCategory.MiscHullplates, cougaritem);
            CustomPrefabHandler.customPrefabs.Add(new CustomPrefab("HullCougarific", "Submarine/Build/HullCougarific", cougaritem, cougarprefab));
            CustomSpriteHandler.customSprites.Add(new CustomSprite(cougaritem, Sprite.Get));
            CraftDataPatcher.customTechData.Add(cougaritem, TechData.Get);
        }
    }
}
