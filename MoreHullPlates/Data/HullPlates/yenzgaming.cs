using SMLHelper;
using SMLHelper.Patchers;
using UnityEngine;

namespace MoreHullPlates.HullPlates
{
    public partial class Load
    {
        private static UnityEngine.GameObject YenzenGObject()
        {
            return GameObject.Get(yenztt, "HullAHK1221", yenztexture);
        }
        private static TechType yenztt = TechTypePatcher.AddTechType("HullAHK1221", "AHK1221 Hull Plate", "Modder. Creator of Modding Helper, Warp Cannon, Exterior Plant Pots and much more (Item added by MoreHullPlates)");
        private static Texture2D yenztexture = AssetBundle.LoadFromFile($@"./QMods/MoreHullPlates/Assets/ahk1221.assets").LoadAsset<UnityEngine.Sprite>("AHK1221").texture;
        public static void yenzgaming()
        {
            CraftDataPatcher.customBuildables.Add(yenztt);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Miscellaneous, TechCategory.MiscHullplates, yenztt);
            CustomPrefabHandler.customPrefabs.Add(new CustomPrefab("Hullyenzgaming", "Submarine/Build/Hullyenzgaming", yenztt, YenzenGObject));
            CustomSpriteHandler.customSprites.Add(new CustomSprite(yenztt, Sprite.Get));
            CraftDataPatcher.customTechData.Add(yenztt, TechData.Get);
        }
    }
}
