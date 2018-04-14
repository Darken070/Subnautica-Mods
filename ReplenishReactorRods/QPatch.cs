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
using ReplenishReactorRods.RRR;

namespace ReplenishReactorRods
{
    public class QPatch
    {
        public static readonly ConfigFile Config = new ConfigFile("config");
        public static bool _debug = false;
        public static void Patch()
        {
            try
            {
                Log.Info("Started loading");
                Config.Load();
                var configChanged = Config.TryGet(ref _debug, "Enable debugging");
                if (configChanged)
                {
                    Log.Debug("Saving config...");
                    Config.Save();
                    Log.Debug("Config saved");
                }
                Log.Debug("Config loaded");
                Log.Debug("Adding dummy techtype...");
                var techType = TechTypePatcher.AddTechType("RRRdummy", "Replenish Reactor Rod", "Allows you to craft a reactor rod from a depleted reactor rod and 3 uraninite crystals");
                Log.Debug("Dummy techtype added");
                Log.Debug("Adding techdata...");
                var techData = new TechDataHelper
                {
                    _craftAmount = 0,
                    _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.DepletedReactorRod, 1),
                    new IngredientHelper(TechType.UraniniteCrystal, 3)
                },
                    _linkedItems = new List<TechType>()
                {
                    TechType.ReactorRod
                },
                    _techType = techType
                };
                Log.Debug("Techdata added");
                Log.Debug("Obtaining sprite...");
                var sprite = SpriteManager.Get(TechType.DepletedReactorRod);
                Log.Debug("Sprite obtained");
                Log.Debug("Applying sprite...");
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techType, sprite));
                Log.Debug("Sprite applied");
                Log.Debug("Linking techdata with techtype...");
                CraftDataPatcher.customTechData.Add(techType, techData);
                Log.Debug("Techdata linked with techtype");
                Log.Debug("Adding fabricator node...");
                CraftTreePatcher.customNodes.Add(new CustomCraftNode(techType, CraftScheme.Fabricator, "Resources/Electronics"));
                Log.Debug("Fabricator node added");
                Log.Info("Finished loading");
            }
            catch (Exception e)
            {
                Log.e(e);
            }
        }
    }
}