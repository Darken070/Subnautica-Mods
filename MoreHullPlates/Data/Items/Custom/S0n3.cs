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
            private static GameObject s0n3go()
            {
                return Prefab.Get(S0n3tt, "HullS0n3", s0n3t);
            }
            private static TechType S0n3tt = TechTypePatcher.AddTechType("HullS0n3", "S0n3 Hull Plate", "A dear friend of mine. Happy Birthday 2018! (Item added by MoreHullPlates)");
            private static Texture2D s0n3t = AssetBundle.LoadFromFile($@"./QMods/MoreHullPlates/Assets/s0n3.assets").LoadAsset<UnityEngine.Sprite>("S0n3").texture;
            public static void S0n3()
            {
                CraftDataPatcher.customBuildables.Add(S0n3tt);
                CraftDataPatcher.AddToCustomGroup(TechGroup.Miscellaneous, TechCategory.MiscHullplates, S0n3tt);
                CustomPrefabHandler.customPrefabs.Add(new CustomPrefab("HullS0n3", "Submarine/Build/HullS0n3", S0n3tt, s0n3go));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(S0n3tt, Sprite.Get));
                CraftDataPatcher.customTechData.Add(S0n3tt, TechData.Get);
            }
        }
    }
}
