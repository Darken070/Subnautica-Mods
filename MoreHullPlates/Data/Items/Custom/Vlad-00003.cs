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
            private static GameObject vladgo()
            {
                return Prefab.Get(vladtt, "HullAlexejheroYTB", vladt);
            }
            private static TechType vladtt = TechTypePatcher.AddTechType("HullVlad00003", "Vlad-00003 Hull Plate", "Modder. Creator of Utilities and Drillable Scan (Item added by MoreHullPlates)");
            private static Texture2D vladt = AssetBundle.LoadFromFile($@"./QMods/MoreHullPlates/Assets/vlad00003.assets").LoadAsset<UnityEngine.Sprite>("Vlad-00003").texture;
            public static void Vlad_00003()
            {
                CraftDataPatcher.customBuildables.Add(vladtt);
                CraftDataPatcher.AddToCustomGroup(TechGroup.Miscellaneous, TechCategory.MiscHullplates, vladtt);
                CustomPrefabHandler.customPrefabs.Add(new CustomPrefab("HullVlad00003", "Submarine/Build/HullVlad00003", vladtt, vladgo));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(vladtt, Sprite.Get));
                CraftDataPatcher.customTechData.Add(vladtt, TechData.Get);
            }
        }
    }
}
