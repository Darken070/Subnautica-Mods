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
            private static GameObject qwisogo()
            {
                return Prefab.Get(qwisott, "Hullqwiso", qwisot);
            }
            private static TechType qwisott = TechTypePatcher.AddTechType("Hullqwiso", "qwiso Hull Plate", "Modder. Creator of *QMODMANAGER* and QMultiMod (Item added by MoreHullPlates)");
            private static Texture2D qwisot = AssetBundle.LoadFromFile($@"./QMods/MoreHullPlates/Assets/qwiso.assets").LoadAsset<UnityEngine.Sprite>("qwiso").texture;
            public static void qwiso()
            {
                CraftDataPatcher.customBuildables.Add(qwisott);
                CraftDataPatcher.AddToCustomGroup(TechGroup.Miscellaneous, TechCategory.MiscHullplates, qwisott);
                CustomPrefabHandler.customPrefabs.Add(new CustomPrefab("Hullqwiso", "Submarine/Build/Hullqwiso", qwisott, qwisogo));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(qwisott, Sprite.Get));
                CraftDataPatcher.customTechData.Add(qwisott, TechData.Get);
            }
        }
    }
}
