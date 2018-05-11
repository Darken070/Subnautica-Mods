using MoreHullPlates.Data;
using SMLHelper;
using SMLHelper.Patchers;
using UnityEngine;
using Sprite = MoreHullPlates.Data.Sprite;

namespace MoreHullPlates.Items
{
    public partial class Load
    {
        public partial class Custom
        {
            private static GameObject AHK1221GameObject()
            {
                return Prefab.Get(ahktt, "HullAHK1221", textureahk);
            }
            private static TechType ahktt = TechTypePatcher.AddTechType("HullAHK1221", "AHK1221 Hull Plate", "Modder. Creator of Modding Helper, Warp Cannon, Exterior Plant Pots and much more (Item added by MoreHullPlates)");
            private static Texture2D textureahk = AssetBundle.LoadFromFile($@"./QMods/MoreHullPlates/Assets/ahk1221.assets").LoadAsset<UnityEngine.Sprite>("AHK1221").texture;
            public static void AHK1221()
            {
                CraftDataPatcher.customBuildables.Add(ahktt);
                CraftDataPatcher.AddToCustomGroup(TechGroup.Miscellaneous, TechCategory.MiscHullplates, ahktt);
                CustomPrefabHandler.customPrefabs.Add(new CustomPrefab("HullAHK1221", "Submarine/Build/HullAHK1221", ahktt, AHK1221GameObject));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(ahktt, Sprite.Get));
                CraftDataPatcher.customTechData.Add(ahktt, TechData.Get);
            }
        }
    }
}
