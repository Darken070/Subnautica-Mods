using SMLHelper;
using SMLHelper.Patchers;
using UnityEngine;

namespace MoreHullPlates.HullPlates
{
    public partial class Load
    {
        private static UnityEngine.GameObject AYTBGameObject()
        {
            return Prefab.Get(alexejheroytbtt, "HullAlexejheroYTB", texture);
        }
        private static TechType alexejheroytbtt = TechTypePatcher.AddTechType("HullAlexejheroYTB", "AlexejheroYTB Hull Plate", "Modder. Creator of MoreIngots and MoreHullPlates (Item added by MoreHullPlates)");
        private static Texture2D texture = AssetBundle.LoadFromFile($@"./QMods/MoreHullPlates/Assets/alexejheroytb.assets").LoadAsset<UnityEngine.Sprite>("AlexejheroYTB").texture;
        public static void AlexejheroYTB()
        {
            CraftDataPatcher.customBuildables.Add(alexejheroytbtt);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Miscellaneous, TechCategory.MiscHullplates, alexejheroytbtt);
            CustomPrefabHandler.customPrefabs.Add(new CustomPrefab("HullAlexejheroYTB", "Submarine/Build/HullAlexejheroYTB", alexejheroytbtt, AYTBGameObject));
            CustomSpriteHandler.customSprites.Add(new CustomSprite(alexejheroytbtt, Sprite.Get));
            CraftDataPatcher.customTechData.Add(alexejheroytbtt, TechData.Get);
        }
    }
}
