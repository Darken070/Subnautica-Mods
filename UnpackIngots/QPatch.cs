using SMLHelper;
using SMLHelper.Patchers;
using System.Collections.Generic;
using Logger = Utilites.Logger.Logger;
using LogType = Utilites.Logger.LogType;
using Utilites.Config;
using UnityEngine;

namespace UnpackIngots
{
    public class QPatch
    {
        private static readonly ConfigFile Config = new ConfigFile("config");
        private static int _x = 2;
        private static int _y = 2;
        public static void Patch()
        {
            var assetBundle = AssetBundle.LoadFromFile(@"./QMods/UnpackIngots/Assets/asset.assets");
            Config.Load();
            var configChanged = Config.TryGet(ref _x, "Scrap metal", "Size", "x")
                                | Config.TryGet(ref _y, "Scrap metal", "Size", "y");
            if (_x <= 0)
            {
                _x = 2;
                Config["Scrap metal", "Size", "x"] = _x;
                Logger.Error("Size of scrap metal can't be less or equal of 0! X was set to 2", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_y <= 0)
            {
                _y = 2;
                Config["Scrap metal", "Size", "y"] = _y;
                Logger.Error("Size of the scrap metal can't be less or equal of 0! Y was set to 2", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (configChanged)
                Config.Save();
                Config.Save();
            var dummy = TechTypePatcher.AddTechType("UIdummyP", "Unpack Plasteel Ingots", "Turn one plasteel ingot into 1 titanium ingot and 2 lithium");
            var dummy2 = TechTypePatcher.AddTechType("UIdummyT", "Unpack Titanium Ingots", "Turn one titanium ingot into 10 titanium");
            var techData = new TechDataHelper
            {
                _craftAmount = 0,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.PlasteelIngot, 1)
                },
                _linkedItems = new List<TechType>()
                {
                    TechType.TitaniumIngot,
                    TechType.Lithium,
                    TechType.Lithium
                },
                _techType = dummy
            };
            var techData2 = new TechDataHelper
            {
                _craftAmount = 0,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.TitaniumIngot, 1)
                },
                _linkedItems = new List<TechType>()
                {
                    TechType.Titanium,
                    TechType.Titanium,
                    TechType.Titanium,
                    TechType.Titanium,
                    TechType.Titanium,
                    TechType.Titanium,
                    TechType.Titanium,
                    TechType.Titanium,
                    TechType.Titanium,
                    TechType.Titanium
                },
                _techType = dummy2
            };
            var sprite = SpriteManager.Get(TechType.Lithium);
            var sprite2 = SpriteManager.Get(TechType.Titanium);
            var tabsprite = assetBundle.LoadAsset<Sprite>("IPMagnetite");
            CustomSpriteHandler.customSprites.Add(new CustomSprite(dummy, sprite));
            CustomSpriteHandler.customSprites.Add(new CustomSprite(dummy2, sprite2));
            CraftDataPatcher.customTechData.Add(dummy, techData);
            CraftDataPatcher.customTechData.Add(dummy2, techData2);
            CraftTreePatcher.customTabs.Add(new CustomCraftTab("Resources/BasicMaterials/UnpackIngots", "Unpack Ingots", CraftScheme.Fabricator, tabsprite));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(dummy, CraftScheme.Fabricator, "Resources/BasicMaterials/UnpackIngots/dummy"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(dummy2, CraftScheme.Fabricator, "Resources/BasicMaterials/UnpackIngots/dummy2"));
        }
    }
}
