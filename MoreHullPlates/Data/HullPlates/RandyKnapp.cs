using SMLHelper;
using SMLHelper.Patchers;
using UnityEngine;

namespace MoreHullPlates.HullPlates
{
    public partial class Load
    {
        private static UnityEngine.GameObject randyobj()
        {
            return Prefab.Get(randytt, "HullRandyKnapp", randytexture);
        }

        private static TechType randytt = TechTypePatcher.AddTechType("HullRandyKnapp", "RandyKnapp Hull Plate", "Modder. Creator of Autosort Lockers and many many other great mods. Special thanks for helping me with the prefabs (Item added by MoreHullPlates)");

        private static Texture2D randytexture = 
            AssetBundle.LoadFromFile($@"./QMods/MoreHullPlates/Assets/randyknapp.assets").
            LoadAsset<UnityEngine.Sprite>("RandyKnapp").texture;

        public static void RandyKnapp()
        {
            CraftDataPatcher.customBuildables.Add(randytt);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Miscellaneous, TechCategory.MiscHullplates, randytt);
            CustomPrefabHandler.customPrefabs.Add(new CustomPrefab("HullRandyKnapp", "Submarine/Build/HullRandyKnapp", randytt, randyobj));
            CustomSpriteHandler.customSprites.Add(new CustomSprite(randytt, Sprite.Get));
            CraftDataPatcher.customTechData.Add(randytt, TechData.Get);
        }
    }
}
