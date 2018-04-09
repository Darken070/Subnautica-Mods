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
            Logger.Debug("Started loading");
            Logger.Debug("Loading assets...");
            var assetBundle = AssetBundle.LoadFromFile(@"./QMods/UnpackIngots/Assets/asset.assets");
            Logger.Debug("Assets loaded");
            Logger.Debug("Loading config...");
            Config.Load();
            var configChanged = Config.TryGet(ref _x, "Scrap metal", "Size", "x")
                                | Config.TryGet(ref _y, "Scrap metal", "Size", "y");
            Logger.Debug("Config loaded");
            Logger.Debug("Checking config for errors...");
            if (_x <= 0)
            {
                _x = 2;
                Config["Scrap metal", "Size", "x"] = _x;
                Logger.Error("Size of scrap metal can't be less or equal of 0! X was set to 2", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            Logger.Debug("Checking config for errors... (1/4)");
            if (_x > 6)
            {
                _x = 2;
                Config["Scrap metal", "Size", "x"] = _x;
                Logger.Error("Size of scrap metal can't be bigger than 6! X was set to 2", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            Logger.Debug("Checking config for errors... (2/4)");
            if (_y <= 0)
            {
                _y = 2;
                Config["Scrap metal", "Size", "y"] = _y;
                Logger.Error("Size of the scrap metal can't be less or equal of 0! Y was set to 2", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            Logger.Debug("Checking config for errors... (3/4)");
            if (_y > 8)
            {
                _y = 8;
                Config["Scrap metal", "Size", "y"] = _y;
                Logger.Error("Size of scrap metal can't be bigger than 8! Y was set to 2", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            Logger.Debug("Error check complete (4/4)");
            if (configChanged)
            {
                Logger.Debug("Saving config...");
                Config.Save();
                Logger.Debug("Config saved");
            }
            Logger.Debug("Loading items...");
            var dummy = TechTypePatcher.AddTechType("UIdummyP", "Unpack Plasteel Ingots", "Turn one plasteel ingot into 1 titanium ingot and 2 lithium");
            Logger.Debug("Loading items... (1/2)");
            var dummy2 = TechTypePatcher.AddTechType("UIdummyT", "Unpack Titanium Ingots", "Turn one titanium ingot into 10 titanium");
            Logger.Debug("Items loaded (2/2)");
            Logger.Debug("Loading recipes...");
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
            Logger.Debug("Loading recipes... (1/2)");
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
            Logger.Debug("Recipes loaded (2/2)");
            Logger.Debug("Loading sprites...");
            var sprite = SpriteManager.Get(TechType.Lithium);
            Logger.Debug("Loading sprites... (1/3)");
            var sprite2 = SpriteManager.Get(TechType.Titanium);
            Logger.Debug("Loading sprites... (2/3)");
            var tabsprite = assetBundle.LoadAsset<Sprite>("tab");
            if (tabsprite = null)
            {
                Logger.Error("Tab sprite is null");
            }
            Logger.Debug("Sprites loaded (3/3)");
            Logger.Debug("Applying sprites...");
            CustomSpriteHandler.customSprites.Add(new CustomSprite(dummy, sprite));
            Logger.Debug("Applying sprites... (1/2)");
            CustomSpriteHandler.customSprites.Add(new CustomSprite(dummy2, sprite2));
            Logger.Debug("Sprites applied (2/2)");
            Logger.Debug("Applying recipes...");
            CraftDataPatcher.customTechData.Add(dummy, techData);
            Logger.Debug("Applying recipes... (1/2)");
            CraftDataPatcher.customTechData.Add(dummy2, techData2);
            Logger.Debug("Recipes applied (2/2)");
            Logger.Debug("Adding fabricator tab...");
            CraftTreePatcher.customTabs.Add(new CustomCraftTab("Resources/BasicMaterials/UnpackIngots", "Unpack Ingots", CraftScheme.Fabricator, tabsprite));
            Logger.Debug("Fabricator tab added");
            Logger.Debug("Adding fabricator nodes...");
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(dummy, CraftScheme.Fabricator, "Resources/BasicMaterials/UnpackIngots/dummy"));
            Logger.Debug("Adding fabricator nodes... (1/2)");
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(dummy2, CraftScheme.Fabricator, "Resources/BasicMaterials/UnpackIngots/dummy2"));
            Logger.Debug("Fabricator nodes added (2/2)");
            Logger.Debug("Finished loading");
        }
    }
}
