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
            private static GameObject campobj()
            {
                return Prefab.Get(camptt, "HullCampsOlderBrother", camptexture);
            }

            private static TechType camptt = TechTypePatcher.AddTechType("HullCampsOlderBrother", "Camp's Older Brother Hull Plate", "\"Multiplayer is not out yet.\" A better version of Camp running on a souped up version of Linux with bigger hard drives and more CPU (Item added by MoreHullPlates)");

            private static Texture2D camptexture =
                AssetBundle.LoadFromFile($@"./QMods/MoreHullPlates/Assets/campsolderbrother.assets").
                LoadAsset<UnityEngine.Sprite>("Camp's Older Brother").texture;

            public static void Camp_s_Older_Brother()
            {
                CraftDataPatcher.customBuildables.Add(camptt);
                CraftDataPatcher.AddToCustomGroup(TechGroup.Miscellaneous, TechCategory.MiscHullplates, camptt);
                CustomPrefabHandler.customPrefabs.Add(new CustomPrefab("HullCampsOlderBrother", "Submarine/Build/HullCampsOlderBrother", camptt, campobj));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(camptt, Sprite.Get));
                CraftDataPatcher.customTechData.Add(camptt, TechData.Get);
            }
        }
    }
}
