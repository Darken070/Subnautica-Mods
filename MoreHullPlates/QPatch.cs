using Harmony;
using SMLHelper;
using SMLHelper.Patchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using Utilites.Logger;
using Logger = Utilites.Logger.Logger;
using LogType = Utilites.Logger.LogType;

namespace MoreHullPlates
{
    public class QPatch
    {
        public static Atlas.Sprite sprite = SpriteManager.Get(TechType.SpecialHullPlate);
        public static TechDataHelper techData = new TechDataHelper
            {
                _craftAmount = 1,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.Titanium, 1),
                    new IngredientHelper(TechType.Glass, 1)
                }
            };
        public static GameObject Main(TechType techType, string classId, string spritePath)
        {
            try
            {
                var assetbundle = AssetBundle.LoadFromFile($@"./QMods/MoreHullPlates/Assets/{spritePath}.assets");
                var sprite = assetbundle.LoadAsset<Sprite>(spritePath);
                //var texture = sprite.texture;

                var prefab = Resources.Load<GameObject>("Submarine/Build/IGPHullPlate");
                var obj = UnityEngine.Object.Instantiate(prefab);
                //var child = obj.transform.Find("Icon").gameObject;

                var constructable = obj.GetComponent<Constructable>();
                var techTag = obj.GetComponent<TechTag>();
                var prefabIdentifier = obj.GetComponent<PrefabIdentifier>();
                //var mesh = child.GetComponent<MeshRenderer>();
                var skyapplier = obj.GetComponent<SkyApplier>();
                
                constructable.techType = techType;
                constructable.allowedInBase = true;
                constructable.allowedInSub = true;
                constructable.allowedOutside = false;
                constructable.allowedOnCeiling = false;
                constructable.allowedOnConstructables = false;
                constructable.allowedOnGround = false;
                constructable.allowedOnWall = true;
                constructable.controlModelState = true;
                constructable.forceUpright = false;
                constructable.rotationEnabled = false;
                constructable.deconstructionAllowed = true;
                constructable.placeMaxDistance = 5;
                constructable.placeMinDistance = 1.2f;
                constructable.placeDefaultDistance = 2;
                constructable.surfaceType = VFXSurfaceTypes.metal;

                techTag.type = techType;

                prefabIdentifier.ClassId = classId;

                //mesh.material.mainTexture = texture;

                return obj;
            }
            catch (Exception e)
            {
                e.Log();
                return null;
            }
        }
        public static TechType alexejheroytbtt;
        public static GameObject AlexejheroYTB()
        {
            try
            {
                return Main(alexejheroytbtt, "HullAlexejheroYTB", "alexejheroytb");
            }
            catch (Exception e)
            {
                e.Log();
                return null;
            }
        }
        /*public static TechType randy;
        public static GameObject RandyKnapp()
        {
            return Main(randy, "HullRandyKnapp", "randyknapp");
        }*/
        public static void Patch()
        {
            try
            {
                Logger.ClearCustomLog();

                // Markiplier Straight Arms Bobblehead (Existing)
                KnownTechPatcher.unlockedAtStart.Add(TechType.Marki1);
                LanguagePatcher.customLines.Add("Marki1", "Markiplier Straight Arms Bobblehead");
                LanguagePatcher.customLines.Add("Tooltip_Marki1", "Subnautica content creator. https://www.youtube.com/markiplierGAME (Item added by Subnautica)");

                // Markiplier Bobblehead (Existing)
                KnownTechPatcher.unlockedAtStart.Add(TechType.Marki2);
                LanguagePatcher.customLines.Add("Marki2", "Markiplier Bobblehead");
                LanguagePatcher.customLines.Add("Tooltip_Marki2", "Subnautica content creator. https://www.youtube.com/markiplierGAME (Item added by Subnautica)");

                // Charlie Cleveland (Existing)
                KnownTechPatcher.unlockedAtStart.Add(TechType.DevTestItem);
                LanguagePatcher.customLines.Add("DevTestItem", "Charlie Cleveland Hull Plate");
                LanguagePatcher.customLines.Add("Tooltip_DevTestItem", "Developer at UnknownWorlds. One of Subnautica's Devs (Item added by Subnautica)");

                // Special Edition (Existing)
                KnownTechPatcher.unlockedAtStart.Add(TechType.SpecialHullPlate);
                LanguagePatcher.customLines.Add("SpecialHullPlate", "Special Edition Hull Plate");
                LanguagePatcher.customLines.Add("Tooltip_SpecialHullPlate", "Limited edition numbered hull plate (Item added by Subnautica)");

                // Bikestman (Existing)
                KnownTechPatcher.unlockedAtStart.Add(TechType.BikemanHullPlate);
                LanguagePatcher.customLines.Add("BikemanHullPlate", "BikestMan Hull Plate");
                LanguagePatcher.customLines.Add("Tooltip_BikemanHullPlate", "Former Subnautica content creator. https://www.youtube.com/BikestMan (Item added by Subnautica)");

                // Diction (Existing)
                KnownTechPatcher.unlockedAtStart.Add(TechType.EatMyDictionHullPlate);
                LanguagePatcher.customLines.Add("EatMyDictionHullPlate", "Diction Hull Plate");
                LanguagePatcher.customLines.Add("Tooltip_EatMyDictionHullPlate", "Subnautica content creator. https://www.youtube.com/user/EatMyDiction1 (Item added by Subnautica)");

                // Diorama (Existing)
                KnownTechPatcher.unlockedAtStart.Add(TechType.DioramaHullPlate);
                LanguagePatcher.customLines.Add("DioramaHullPlate", "Diorama Hull Plate");
                LanguagePatcher.customLines.Add("Tooltip_DioramaHullPlate", "A special hull plate to commemorate an unique diorama. https://www.youtu.be/oIcIAVqllDA (Item added by Subnautica)");

                // Markiplier (Existing)
                KnownTechPatcher.unlockedAtStart.Add(TechType.MarkiplierHullPlate);
                LanguagePatcher.customLines.Add("MarkiplierHullPlate", "Markiplier Hull Plate");
                LanguagePatcher.customLines.Add("Tooltip_MarkiplierHullPlate", "Subnautica content creator. https://www.youtube.com/markiplierGAME (Item added by Subnautica)");

                // muyskerm (Existing)
                KnownTechPatcher.unlockedAtStart.Add(TechType.MuyskermHullPlate);
                LanguagePatcher.customLines.Add("MuyskermHullPlate", "Muyskerm Hull Plate");
                LanguagePatcher.customLines.Add("Tooltip_MuyskermHullPlate", "Subnautica content creator. https://www.youtube.com/muyskerm (Item added by Subnautica)");

                // LordMinion777 (Existing)
                KnownTechPatcher.unlockedAtStart.Add(TechType.LordMinionHullPlate);
                LanguagePatcher.customLines.Add("LordMinionHullPlate", "LordMinion777 Hull Plate");
                LanguagePatcher.customLines.Add("Tooltip_LordMinionHullPlate", "Former Subnautica content creator. https://www.youtube.com/LordMinion777 (Item added by Subnautica)");

                // jacksepticeye (Existing)
                KnownTechPatcher.unlockedAtStart.Add(TechType.JackSepticEyeHullPlate);
                LanguagePatcher.customLines.Add("JackSepticEyeHullPlate", "Jacksepticeye Hull Plate");
                LanguagePatcher.customLines.Add("Tooltip_JackSepticEyeHullPlate", "Subnautica content creator. https://www.youtube.com/jacksepticeye (Item added by Subnautica)");

                // IGP (Existing)
                KnownTechPatcher.unlockedAtStart.Add(TechType.IGPHullPlate);
                LanguagePatcher.customLines.Add("IGPHullPlate", "IGP Hull Plate");
                LanguagePatcher.customLines.Add("Tooltip_IGPHullPlate", "Subnautica content creator. https://www.youtube.com/TheIndieGamePromoter (Item added by Subnautica)");

                // GilathissNew (Existing)
                KnownTechPatcher.unlockedAtStart.Add(TechType.GilathissHullPlate);
                LanguagePatcher.customLines.Add("GilathissHullPlate", "GilathissNew Hull Plate");
                LanguagePatcher.customLines.Add("Tooltip_GilathissHullPlate", "Former Subnautica content creator. https://www.youtube.com/GilathissNew (Item added by Subnautica)");

                // AlexejheroYTB
                alexejheroytbtt = TechTypePatcher.AddTechType("HullAlexejheroYTB", "AlexejheroYTB Hull Plate", "Modder. Creator of MoreIngots and MoreHullPlates (Item added by MoreHullPlates)");
                CraftDataPatcher.customBuildables.Add(alexejheroytbtt);
                CraftDataPatcher.AddToCustomGroup(TechGroup.Miscellaneous, TechCategory.MiscHullplates, alexejheroytbtt);
                CustomPrefabHandler.customPrefabs.Add(new CustomPrefab("HullAlexejheroYTB", "Submarine/Build/HullAlexejheroYTB", alexejheroytbtt, AlexejheroYTB));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(alexejheroytbtt, sprite));
                CraftDataPatcher.customTechData.Add(alexejheroytbtt, techData);

                /*/ RandyKnapp
                randy = TechTypePatcher.AddTechType("HullRandyKnapp", "RandyKnapp Hull Plate", "Modder. Creator of AutosortLockers, DockedVehicleStorageAccess, WhiteLightes and ALOT more (Item added by MoreHullPlates)");
                CraftDataPatcher.customBuildables.Add(randy);
                CraftDataPatcher.AddToCustomGroup(TechGroup.Miscellaneous, TechCategory.MiscHullplates, randy);
                CustomPrefabHandler.customPrefabs.Add(new CustomPrefab("HullRandyKnapp", "Submarine/Build/HullRandyKnapp", randy, RandyKnapp));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(randy, sprite));
                CraftDataPatcher.customTechData.Add(randy, techData); */
            }
            catch (Exception e)
            {
                e.Log();
            }
        }
    }
}
