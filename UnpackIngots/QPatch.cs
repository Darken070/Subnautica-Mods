using SMLHelper;
using SMLHelper.Patchers;
using System.Collections.Generic;
using Logger = Utilites.Logger.Logger;
using LogType = Utilites.Logger.LogType;
using Utilites.Config;
using UnityEngine;
using System;

namespace UnpackIngots
{
    public class QPatch
    {
        private static readonly ConfigFile Config = new ConfigFile("config");
        private static int _x = 2;
        private static int _y = 2;
        public static void Patch()
        {
            Logger.Info("Started loading", LogType.Console);
            Logger.Debug("Loading assets... (0/1)", LogType.Console);
            var assetBundle = AssetBundle.LoadFromFile(@"./QMods/UnpackIngots/Assets/asset.assets");
            Logger.Debug("Assets loaded (1/1)", LogType.Console);
            Logger.Debug("Loading config... (0/1)", LogType.Console);
            Config.Load();
            var configChanged = Config.TryGet(ref _x, "Scrap metal", "Size", "x")
                                | Config.TryGet(ref _y, "Scrap metal", "Size", "y");
            Logger.Debug("Config loaded (1/1)", LogType.Console);
            Logger.Debug("Checking config for errors... (0/4)", LogType.Console);
            if (_x <= 0)
            {
                _x = 2;
                Config["Scrap metal", "Size", "x"] = _x;
                Logger.Error("Size of scrap metal can't be less or equal of 0! X was set to 2", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            Logger.Debug("Checking config for errors... (1/4)", LogType.Console);
            if (_x > 6)
            {
                _x = 2;
                Config["Scrap metal", "Size", "x"] = _x;
                Logger.Error("Size of scrap metal can't be bigger than 6! X was set to 2", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            Logger.Debug("Checking config for errors... (2/4)", LogType.Console);
            if (_y <= 0)
            {
                _y = 2;
                Config["Scrap metal", "Size", "y"] = _y;
                Logger.Error("Size of the scrap metal can't be less or equal of 0! Y was set to 2", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            Logger.Debug("Checking config for errors... (3/4)", LogType.Console);
            if (_y > 8)
            {
                _y = 8;
                Config["Scrap metal", "Size", "y"] = _y;
                Logger.Error("Size of scrap metal can't be bigger than 8! Y was set to 2", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            Logger.Debug("Error check complete (4/4)", LogType.Console);
            if (configChanged)
            {
                Logger.Debug("Saving config... (0/1)", LogType.Console);
                Config.Save();
                Logger.Debug("Config saved (1/1)", LogType.Console);
            }
            Logger.Debug("Loading items... (0/2)", LogType.Console);
            var dummy = TechTypePatcher.AddTechType("UIdummyP", "Unpack Plasteel Ingots", "Turn one plasteel ingot into 1 titanium ingot and 2 lithium");
            Logger.Debug("Loading items... (1/2)", LogType.Console);
            var dummy2 = TechTypePatcher.AddTechType("UIdummyT", "Unpack Titanium Ingots", "Turn one titanium ingot into 10 titanium");
            Logger.Debug("Items loaded (2/2)", LogType.Console);
            Logger.Debug("Loading recipes... (0/2)", LogType.Console);
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
            Logger.Debug("Loading recipes... (1/2)", LogType.Console);
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
            Logger.Debug("Recipes loaded (2/2)", LogType.Console);
            Logger.Debug("Loading atlas sprites... (0/2)", LogType.Console);
            var sprite = SpriteManager.Get(TechType.Lithium);
            Logger.Debug("Loading atlas sprites... (1/2)", LogType.Console);
            var sprite2 = SpriteManager.Get(TechType.Titanium);
            Logger.Debug("Atlas sprites loaded (2/2)", LogType.Console);
            Logger.Debug("Loading unity sprites... (0/1)", LogType.Console);
            var tabsprite = assetBundle.LoadAsset<Sprite>("tab");
            if (tabsprite == null)
            {
                Logger.Error("Unity sprite is null", LogType.Console);
            }
            Logger.Debug("Unity sprites loaded (1/1)", LogType.Console);
            Logger.Debug("Applying atlas sprites... (0/2)", LogType.Console);
            CustomSpriteHandler.customSprites.Add(new CustomSprite(dummy, sprite));
            Logger.Debug("Applying atlas sprites... (1/2)", LogType.Console);
            CustomSpriteHandler.customSprites.Add(new CustomSprite(dummy2, sprite2));
            Logger.Debug("Atlas sprites applied (2/2)", LogType.Console);
            Logger.Debug("Assigning recipes... (0/2)", LogType.Console);
            CraftDataPatcher.customTechData.Add(dummy, techData);
            Logger.Debug("Assigning recipes... (1/2)", LogType.Console);
            CraftDataPatcher.customTechData.Add(dummy2, techData2);
            Logger.Debug("Recipes Assigned (2/2)", LogType.Console);
            Logger.Debug("Adding fabricator tabs... (0/1)", LogType.Console);
            CraftTreePatcher.customTabs.Add(new CustomCraftTab("Resources/BasicMaterials/UnpackIngots", "Unpack Ingots", CraftScheme.Fabricator, tabsprite));
            Logger.Debug("Fabricator tabs added (1/1)", LogType.Console);
            Logger.Debug("Adding fabricator nodes... (0/2)", LogType.Console);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(dummy, CraftScheme.Fabricator, "Resources/BasicMaterials/UnpackIngots/dummy"));
            Logger.Debug("Adding fabricator nodes... (1/2)", LogType.Console);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(dummy2, CraftScheme.Fabricator, "Resources/BasicMaterials/UnpackIngots/dummy2"));
            Logger.Debug("Fabricator nodes added (2/2)", LogType.Console);
            Logger.Info("Finished loading", LogType.Console);
        }
    }
}
