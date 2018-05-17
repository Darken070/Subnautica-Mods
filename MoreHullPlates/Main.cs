using SMLHelper;
using SMLHelper.Patchers;
using System;
using System.Collections.Generic;
using UnityEngine;
using static MoreHullPlates.Code;

namespace MoreHullPlates
{
    public class EntryPoint
    {
        public void Main()
        {
            try
            {
                ExistingItems.Load();
                CustomItems.Load();
            }
            catch (Exception e)
            {
                e.Log();
            }
        }
    }
    public class Code
    {
        public class AssetBundleLocation
        {
            public string AssetBundle;
            public string Path;

            public AssetBundleLocation(string assetBundle, string path)
            {
                try
                {
                    AssetBundle = assetBundle.ToLower();
                    Path = path;
                }
                catch (Exception e)
                {
                    e.Log();
                }
            }

            public AssetBundleLocation(string assetBundle_And_Path_If_They_Are_The_Same_But_Keep_Capitalization)
            {
                try
                {
                    AssetBundle = assetBundle_And_Path_If_They_Are_The_Same_But_Keep_Capitalization.ToLower();
                    Path = assetBundle_And_Path_If_They_Are_The_Same_But_Keep_Capitalization;

                }
                catch (Exception e)
                {
                    e.Log();
                }
            }
        }
        public class ItemToUnlock
        {
            public TechType TechType;
            public string Name;
            public string Tooltip;
            public bool RemoveFromOtherCustomGroup = false;

            public ItemToUnlock(TechType techType, string name, string tooltip, bool removeFromOtherCustomGroup = false)
            {
                try
                {
                    TechType = techType;
                    Name = name;
                    Tooltip = tooltip;
                    RemoveFromOtherCustomGroup = removeFromOtherCustomGroup;
                }
                catch (Exception e)
                {
                    e.Log();
                }
            }
        }
        public static class ItemsToUnlockList
        {
            public static List<ItemToUnlock> itemsToUnlock = new List<ItemToUnlock>()
        {
            new ItemToUnlock(TechType.DevTestItem, "Charlie Cleveland Hull Plate", "Developer at UnknownWorlds. One of Subnautica's Devs"),
            new ItemToUnlock(TechType.SpecialHullPlate, "Special Edition Hull Plate", "Limited edition numbered hull plate"),
            new ItemToUnlock(TechType.BikemanHullPlate, "BikestMan Hull Plate", "Former Subnautica content creator. https://www.youtube.com/BikestMan"),
            new ItemToUnlock(TechType.EatMyDictionHullPlate, "Diction Hull Plate", "Subnautica content creator. https://www.youtube.com/user/EatMyDiction1"),
            new ItemToUnlock(TechType.DioramaHullPlate, "Diorama Hull Plate", "A special hull plate to commemorate an unique diorama. https://www.youtu.be/oIcIAVqllDA"),
            new ItemToUnlock(TechType.MarkiplierHullPlate, "Markiplier Hull Plate", "Subnautica content creator. https://www.youtube.com/markiplierGAME"),
            new ItemToUnlock(TechType.MuyskermHullPlate, "muyskerm Hull Plate", "Subnautica content creator. https://www.youtube.com/muyskerm"),
            new ItemToUnlock(TechType.LordMinionHullPlate, "LordMinion777 Hull Plate", "Former Subnautica content creator. https://www.youtube.com/LordMinion777"),
            new ItemToUnlock(TechType.JackSepticEyeHullPlate, "jacksepticeye Hull Plate", "Subnautica content creator. https://www.youtube.com/jacksepticeye"),
            new ItemToUnlock(TechType.IGPHullPlate, "IGP Hull Plate", "Subnautica content creator. https://www.youtube.com/TheIndieGamePromoter"),
            new ItemToUnlock(TechType.GilathissHullPlate, "GilathissNew Hull Plate", "Former Subnautica content creator. https://www.youtube.com/GilathissNew"),
            new ItemToUnlock(TechType.Marki1, "Markiplier Straight Arms Bobble-Head", "Subnautica content creator. https://www.youtube.com/markiplierGAME", true),
            new ItemToUnlock(TechType.Marki2, "Markiplier Bobble-Head", "Subnautica content creator. https://www.youtube.com/markiplierGAME", true),
            new ItemToUnlock(TechType.JackSepticEye, "jacksepticeye's Tank", "Subnautica content creator. https://www.youtube.com/jacksepticeye", true),
            new ItemToUnlock(TechType.EatMyDiction, "Diction's Cat", "Subnautica content creator. https://www.youtube.com/user/EatMyDiction1")
        };
        }
        public class ItemToAdd
        {
            public string InternalName;
            public string Name;
            public string Tooltip;
            public AssetBundleLocation TextureLocation;
            public AssetBundleLocation SpriteLocation;

            public ItemToAdd(string internalName, string name, string tooltip, AssetBundleLocation textureLocation, AssetBundleLocation spriteLocation)
            {
                try
                {
                    InternalName = internalName;
                    Name = name;
                    Tooltip = tooltip;
                    TextureLocation = textureLocation;
                    SpriteLocation = spriteLocation;
                }
                catch (Exception e)
                {
                    e.Log();
                }
            }
        }
        public static class ItemsToAddList
        {
            public static List<ItemToAdd> itemsToAdd = new List<ItemToAdd>()
        {
            new ItemToAdd("HullAlexejheroYTB", "AlexejheroYTB Hull Plate", "Modder. Creator of MoreIngots and MoreHullPlates", new AssetBundleLocation("AlexejheroYTB"), null),
            new ItemToAdd("HullAHK1221", "AHK1221 Hull Plate", "Modder. Creator of Modding Helper, Warp Cannon, Exterior Plant Pots and much more", new AssetBundleLocation("AHK1221"), null),
            new ItemToAdd("HullCampsOlderBrother", "Camp's Older Brother Hull Plate", "\"Multiplayer is not out yet.\" A better version of Camp running on a souped up version of Linux with bigger hard drives and more CPU", new AssetBundleLocation("campsolderbrother", "Camp's Older Brother"), null),
            new ItemToAdd("HullCougarific", "Cougarific Hull Plate", "Subnautica content creator. Makes mod reviews and modded playthroughs. https://www.youtube.com/robertlyon", new AssetBundleLocation("Cougarific"), null),
            new ItemToAdd("Hullqwiso", "qwiso Hull Plate", "Modder. Creator of *QMODMANAGER* and QMultiMod", new AssetBundleLocation("qwiso"), null),
            new ItemToAdd("HullRandyKnapp", "RandyKnapp Hull Plate", "Modder. Creator of Autosort Lockers, Docked Vehicle Storage Access and many other great mods. Special thanks for helping me with the prefabs", new AssetBundleLocation("RandyKnapp"), null),
            new ItemToAdd("HullS0n3", "S0n3 Hull Plate", "A dear friend of mine. Happy Birthday 2018!", new AssetBundleLocation("S0n3"), null),
            new ItemToAdd("HullVlad00003", "Vlad-00003 Hull Plate", "Modder. Creator of Utilities and Drillable Scan", new AssetBundleLocation("vlad00003", "Vlad-00003"), null),
            new ItemToAdd("Hullyenzgaming", "yenzgaming Hull Plate", "Modder. Creator of Custom Food and Egg Info", new AssetBundleLocation("yenzgaming"), new AssetBundleLocation("yenzgaming-icon", "yenzgaming Icon"))
        };
        }
        public class TechData
        {
            public static TechDataHelper Get = new TechDataHelper
            {
                _craftAmount = 1,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.Titanium, 1),
                    new IngredientHelper(TechType.Glass, 1)
                }
            };
        }
        public class DefaultSprite
        {
            public static Atlas.Sprite Get = SpriteManager.Get(TechType.SpecialHullPlate);
        }
        public class DefaultPrefab
        {
            public static GameObject Get(TechType techtype, string Classid, Texture2D texture)
            {
                try
                {
                    var prefab = Resources.Load<GameObject>("Submarine/Build/IGPHullPlate");
                    var obj = UnityEngine.Object.Instantiate(prefab);
                    var child = obj.transform.Find("Icon").gameObject;

                    var constructable = obj.GetComponent<Constructable>();
                    var techTag = obj.GetComponent<TechTag>();
                    var prefabIdentifier = obj.GetComponent<PrefabIdentifier>();
                    var mesh = child.GetComponent<MeshRenderer>();

                    constructable.techType = techtype;

                    techTag.type = techtype;

                    prefabIdentifier.ClassId = Classid;

                    mesh.material.mainTexture = texture;

                    return obj;
                }
                catch (Exception e)
                {
                    e.Log();
                    return null;
                }
            }
        }
        public class ExistingItems
        {
            public static void Load()
            {
                try
                {
                    foreach (ItemToUnlock item in ItemsToUnlockList.itemsToUnlock)
                    {
                        var _techType = item.TechType;
                        var _name = item.Name;
                        var _tooltip = item.Tooltip;
                        var _removeFromOtherCustomGroup = item.RemoveFromOtherCustomGroup;

                        KnownTechPatcher.unlockedAtStart.Add(_techType);
                        LanguagePatcher.customLines.Add(_techType.ToString(), _name);
                        LanguagePatcher.customLines.Add($"Tooltip_{_techType.ToString()}", $"{_tooltip} (Item added by Subnautica)");

                        if (_removeFromOtherCustomGroup)
                        {
                            CraftDataPatcher.AddToCustomGroup(TechGroup.Miscellaneous, TechCategory.Misc, _techType);
                            try
                            {
                                CraftDataPatcher.RemoveFromCustomGroup(TechGroup.Miscellaneous, TechCategory.MiscHullplates, _techType);
                            }
                            catch
                            {
                                Console.WriteLine("[MoreHullPlates] [Error] PLEASE UPDATE MODDING HELPER TO VERSION 1.5.2");
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    e.Log();
                }
            }
        }
        public class CustomItems
        {
            public static TechType ItemTechType;
            public static Texture2D ItemTexture;
            public static string ItemInternalName;
            public static void Load()
            {
                try
                {
                    foreach (ItemToAdd item in ItemsToAddList.itemsToAdd)
                    {
                        ItemInternalName = item.InternalName;
                        var _name = item.Name;
                        var _tooltip = item.Tooltip;
                        var _textureLocation = item.TextureLocation;
                        var _spriteLocation = item.SpriteLocation;

                        ItemTechType = TechTypePatcher.AddTechType(ItemInternalName, _name, _tooltip, true);
                        ItemTexture = AssetBundle.LoadFromFile($@"./QMods/MoreHullPlates/Assets/{_textureLocation.AssetBundle}.assets").LoadAsset<Sprite>(_textureLocation.Path).texture;
                        var UnitySprite = default(Sprite);
                        if (_spriteLocation != null)
                        {
                            UnitySprite = AssetBundle.LoadFromFile($@"./QMods/MoreHullPlates/Assets/{_spriteLocation.AssetBundle}.assets").LoadAsset<Sprite>(_spriteLocation.Path);
                        }
                        CraftDataPatcher.customBuildables.Add(ItemTechType);
                        CraftDataPatcher.AddToCustomGroup(TechGroup.Miscellaneous, TechCategory.MiscHullplates, ItemTechType);
                        CustomPrefabHandler.customPrefabs.Add(new CustomPrefab(ItemInternalName, $"Submarine/Build/{ItemInternalName}", ItemTechType, ItemPrefab));
                        if (UnitySprite == null)
                        {
                            CustomSpriteHandler.customSprites.Add(new CustomSprite(ItemTechType, DefaultSprite.Get));
                        }
                        else
                        {
                            CustomSpriteHandler.customSprites.Add(new CustomSprite(ItemTechType, UnitySprite));
                        }
                        CraftDataPatcher.customTechData.Add(ItemTechType, TechData.Get);
                    }
                }
                catch (Exception e)
                {
                    e.Log();
                }
            }
            public static GameObject ItemPrefab()
            {
                return DefaultPrefab.Get(ItemTechType, ItemInternalName, ItemTexture);
            }
        }
    }
    public class Utility
    {
        public class Logging
        {
            public static string FormatException(Exception e)
            {
                if (e == null)
                    return string.Empty;
                return $"\"Exception: {e.GetType()}\"\n\tMessage: {e.Message}\n\tStacktrace: {e.StackTrace}\n" +
                       FormatException(e.InnerException);
            }
            public static void Log(string text)
            {
                Console.WriteLine($"[MoreHullPlates] {text}");
            }
        }
    }
    public static class ExtensionMethods
    {   
        public static void Log(this Exception e)
        {
            Utility.Logging.Log(Utility.Logging.FormatException(e));
        }
    }
}