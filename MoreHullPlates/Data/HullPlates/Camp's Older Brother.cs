using SMLHelper;
using SMLHelper.Patchers;
using UnityEngine;

namespace MoreHullPlates.HullPlates
{
    public partial class Load
    {
        private static UnityEngine.GameObject campobj()
        {
            return Prefab.Get(camptt, "HullCampsOlderBrother", camptexture);
        }

        private static TechType camptt = TechTypePatcher.AddTechType("HullCampsOlderBrother", "Camp's Older Brother Hull Plate", "\"Multiplayer is not out yet.\" A better version of Camp running on a souped up version of Linux with bigger hard drives and more CPU");

        private static Texture2D camptexture = 
            AssetBundle.LoadFromFile($@"./QMods/MoreHullPlates/Assets/campsolderbrother.assets").
            LoadAsset<UnityEngine.Sprite>("Camp's Older Brother").texture;

        public static void CampsOlderBrother()
        {
            CraftDataPatcher.customBuildables.Add(camptt);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Miscellaneous, TechCategory.MiscHullplates, camptt);
            CustomPrefabHandler.customPrefabs.Add(new CustomPrefab("HullCampsOlderBrother", "Submarine/Build/HullCampsOlderBrother", camptt, campobj));
            CustomSpriteHandler.customSprites.Add(new CustomSprite(camptt, Sprite.Get));
            CraftDataPatcher.customTechData.Add(camptt, TechData.Get);
        }
    }
}
