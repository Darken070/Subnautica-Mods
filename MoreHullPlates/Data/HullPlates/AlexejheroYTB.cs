using SMLHelper;
using SMLHelper.Patchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MoreHullPlates.HullPlates
{
    public partial class Load
    {
        public static UnityEngine.GameObject AYTBGameObject()
        {
            return GameObject.Get(alexejheroytbtt, "HullAlexejheroYTB", texture);
        }
        public static TechType alexejheroytbtt = TechTypePatcher.AddTechType("HullAlexejheroYTB", "AlexejheroYTB Hull Plate", "Modder. Creator of MoreIngots and MoreHullPlates (Item added by MoreHullPlates)");
        public static Texture2D texture = AssetBundle.LoadFromFile($@"./QMods/MoreHullPlates/Assets/alexejheroytb.assets").LoadAsset<UnityEngine.Sprite>("alexejheroytb").texture;
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
