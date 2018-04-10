using SMLHelper;
using SMLHelper.Patchers;
using System.Collections.Generic;
using UnityEngine;
using Utilites.Config;
using Logger = Utilites.Logger.Logger;
using LogType = Utilites.Logger.LogType;
using LogLevel = Utilites.Logger.LogLevel;
using System;
using Utilites.Logger;
using UnpackIngots.UI;

namespace UnpackIngots
{
    public class QPatch
    {
        public static readonly ConfigFile Config = new ConfigFile("config");
        public static int _x = 2;
        public static int _y = 2;
        public static bool _debug = false;
        public static void Patch()
        {
            try
            {
                Log.Info("Started loading");
                Log.Debug("Loading asset bundle...");
                var assetBundle = AssetBundle.LoadFromFile(@"./QMods/UnpackIngots/Assets/unpackingotsassets.assets");
                Log.Debug("Asset bundle loaded");
                Log.Debug("Loading config...");
                Config.Load();
                var configChanged = Config.TryGet(ref _x, "Scrap metal", "Size", "x")
                                    | Config.TryGet(ref _y, "Scrap metal", "Size", "y")
                                    | Config.TryGet(ref _debug, "Enable debugging");
                Log.Debug("Config loaded");
                Log.Debug("Checking config for errors... (0/4)");
                if (_x <= 0)
                {
                    _x = 2;
                    Config["Scrap metal", "Size", "x"] = _x;
                    Log.Warning("Scrap metal size can't be less than 1");
                    Log.Info("X was set to 1");
                    configChanged = true;
                }
                Log.Debug("Checking config for errors... (1/4)");
                if (_x > 6)
                {
                    _x = 2;
                    Config["Scrap metal", "Size", "x"] = _x;
                    Log.Warning("Scrap metal size can't be greater than 6");
                    Log.Info("X was set to 1");
                    configChanged = true;
                }
                Log.Debug("Checking config for errors... (2/4)");
                if (_y <= 0)
                {
                    _y = 2;
                    Config["Scrap metal", "Size", "y"] = _y;
                    Log.Warning("Scrap metal size can't be less than 1");
                    Log.Info("Y was set to 1");
                    configChanged = true;
                }
                Log.Debug("Checking config for errors... (3/4)");
                if (_y > 8)
                {
                    _y = 8;
                    Config["Scrap metal", "Size", "y"] = _y;
                    Log.Warning("Scrap metal size can't be greater than 8");
                    Log.Info("Y was set to 1");
                    configChanged = true;
                }
                Log.Debug("Checking config for errors... (4/4)");
                Log.Debug("Error check complete");
                if (configChanged)
                {
                    Log.Debug("Saving config...");
                    Config.Save();
                    Log.Debug("Config saved");
                }
                Log.Debug("Adding TechTypes... (0/2)");
                var dummy = TechTypePatcher.AddTechType("UIdummyP", "Unpack Plasteel Ingots", "Turn one plasteel ingot into 1 titanium ingot and 2 lithium");
                Log.Debug("Adding TechTypes... (1/2)");
                var dummy2 = TechTypePatcher.AddTechType("UIdummyT", "Unpack Titanium Ingots", "Turn one titanium ingot into 10 titanium");
                Log.Debug("Adding TechTypes... (2/2)");
                Log.Debug("TechTypes added");
                Log.Debug("Loading TechDatas... (0/2)");
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
                Log.Debug("Loading TechDatas... (1/2)");
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
                Log.Debug("Loading TechDatas... (2/2)");
                Log.Debug("TechDatas loaded");
                Log.Debug("Loading Atlas sprites... (0/2)");
                var sprite = SpriteManager.Get(TechType.Lithium);
                Log.Debug("Loading Atlas sprites... (1/2)");
                var sprite2 = SpriteManager.Get(TechType.Titanium);
                Log.Debug("Loading Atlas sprites... (2/2)");
                Log.Debug("Atlas sprites loaded");
                Log.Debug("Loading UnityEngine sprite...");
                var tabsprite = assetBundle.LoadAsset<Sprite>("unpackingotsfabricatortab");
                if (tabsprite == null)
                {
                    Log.Error("UnityEngine sprite is null");
                }
                Log.Debug("UnityEngine sprite loaded");
                Log.Debug("Applying Atlas sprites... (0/2)");
                CustomSpriteHandler.customSprites.Add(new CustomSprite(dummy, sprite));
                Log.Debug("Applying Atlas sprites... (1/2)");
                CustomSpriteHandler.customSprites.Add(new CustomSprite(dummy2, sprite2));
                Log.Debug("Applying Atlas sprites... (2/2)");
                Log.Debug("Atlas sprites applied");
                Log.Debug("Linking TechDatas and TechTypes... (0/2)");
                CraftDataPatcher.customTechData.Add(dummy, techData);
                Log.Debug("Linking TechDatas and TechTypes... (1/2)");
                CraftDataPatcher.customTechData.Add(dummy2, techData2);
                Log.Debug("Linking TechDatas and TechTypes... (2/2)");
                Log.Debug("TechDatas and TechTypes linked");
                Log.Debug("Adding Fabricator tab...");
                CraftTreePatcher.customTabs.Add(new CustomCraftTab("Resources/BasicMaterials/UnpackIngots", "Unpack Ingots", CraftScheme.Fabricator, tabsprite));
                Log.Debug("Fabricator tabs added");
                Log.Debug("Adding Fabricator nodes... (0/2)");
                CraftTreePatcher.customNodes.Add(new CustomCraftNode(dummy, CraftScheme.Fabricator, "Resources/BasicMaterials/UnpackIngots/dummy"));
                Log.Debug("Adding Fabricator nodes... (1/2)");
                CraftTreePatcher.customNodes.Add(new CustomCraftNode(dummy2, CraftScheme.Fabricator, "Resources/BasicMaterials/UnpackIngots/dummy2"));
                Log.Debug("Adding Fabricator nodes... (2/2)");
                Log.Debug("Fabricator nodes added");
                Log.Info("Finished loading");
            }
            catch (Exception e)
            {
                e.Log(LogType.Console);;
            }
        }
    }
}
