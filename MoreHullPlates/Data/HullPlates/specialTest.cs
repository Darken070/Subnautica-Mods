using SMLHelper;
using SMLHelper.Patchers;
using UnityEngine;

namespace MoreHullPlates.HullPlates
{
    public partial class Load
    {
        private static GameObject specialGameObject()
        {
            return Prefab.Special(specialTT, "HullAlexejheroYTBSpecial", texture);
        }
        private static TechType specialTT = TechTypePatcher.AddTechType("HullAlexejheroYTBSpecial", "Special Hull Plate test", "Modder. Creator of MoreIngots and MoreHullPlates (Item added by MoreHullPlates)");
        //private static Texture2D texture = AssetBundle.LoadFromFile($@"./QMods/MoreHullPlates/Assets/alexejheroytb.assets").LoadAsset<UnityEngine.Sprite>("AlexejheroYTB").texture;
        public static void specialTest()
        {
            CraftDataPatcher.customBuildables.Add(specialTT);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Miscellaneous, TechCategory.MiscHullplates, specialTT);
            CustomPrefabHandler.customPrefabs.Add(new CustomPrefab("HullAlexejheroYTBSpecial", "Submarine/Build/HullAlexejheroYTBSpecial", specialTT, specialGameObject));
            CustomSpriteHandler.customSprites.Add(new CustomSprite(specialTT, Sprite.Get));
            CraftDataPatcher.customTechData.Add(specialTT, TechData.Get);
        }
    }
}
