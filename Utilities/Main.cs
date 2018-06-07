using SMLHelper;
using SMLHelper.Patchers;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace AlexejheroYTB.Utilities
{

    public static class Values
    {

        public static void Swap<T>(ref T value1, ref T value2)
        {
            T tempObj = value1;
            value1 = value2;
            value2 = tempObj;
        }

        public static bool NullCheck<T>(T var)
        {
            if (var == null) return true;
            else return false;
        }

        public static class NullCheckMultiple
        {
            public static bool CheckIfOne<T>(params T[] variables)
            {
                foreach (T variable in variables)
                {
                    if (variable == null) return true;
                }
                return false;
            }
            public static bool CheckIfAll<T>(params T[] variables)
            {
                foreach (T variable in variables)
                {
                    if (variable != null) return false;
                }
                return true;
            }
        }

    }

    public static class Logging
    {

        public static void Log(string message, bool onlyLogIfTrue = true)
        {
            Message(message, onlyLogIfTrue);
        }
        
        public static void Message(string message, bool onlyLogIfTrue = true)
        {
            Utils.LogUtils.Log(message, null, onlyLogIfTrue);
        }

        public static void Debug(string message, bool onlyLogIfTrue = true)
        {
            Utils.LogUtils.Log(message, "DEBUG", onlyLogIfTrue);
        }

        public static void Warning(string message, bool onlyLogIfTrue = true)
        {
            Utils.LogUtils.Log(message, "WARNING", onlyLogIfTrue);
        }

        public static void Error(string message, bool onlyLogIfTrue = true)
        {
            Utils.LogUtils.Log(message, "ERROR", onlyLogIfTrue);
        }

    }

    public static class Items
    {

        public class AddItemResult
        {
            public CustomCraftNode CustomCraftNode;
            public CustomSprite CustomSprite;
            public Atlas.Sprite Sprite;
            public TechDataHelper TechDataHelper;
            public TechType TechType;
            public Prefab Prefab;
        }

        public static AddItemResult AddDummy(string name, string languageName, string languageTooltip, TechType spriteItem, string fabricatorNodePath, List<IngredientHelper> ingredientItems, List<TechType> resultingItems, string prefabPath = null)
        {
            TechType techType = TechTypePatcher.AddTechType(name, languageName, languageTooltip);
            Atlas.Sprite sprite = SpriteManager.Get(spriteItem);
            CustomSprite customSprite = new CustomSprite(techType, sprite);
            CustomCraftNode customCraftNode = new CustomCraftNode(techType, CraftScheme.Fabricator, fabricatorNodePath);
            TechDataHelper techData = new TechDataHelper()
            {
                _craftAmount = 0,
                _ingredients = ingredientItems,
                _linkedItems = resultingItems,
                _techType = techType
            };

            CustomSpriteHandler.customSprites.Add(customSprite);
            CraftDataPatcher.customTechData.Add(techType, techData);
            CraftTreePatcher.customNodes.Add(customCraftNode);

            AddItemResult result = new AddItemResult()
            {
                CustomCraftNode = customCraftNode,
                CustomSprite = customSprite,
                Sprite = sprite,
                TechDataHelper = techData,
                TechType = techType,
            };

            if (prefabPath == null)
                return result;

            Prefab prefab = new Prefab(prefabPath, name, techType);
            CustomPrefabHandler.customPrefabs.Add(new CustomPrefab(prefab.InternalName, prefab.NewPrefabPath, prefab.Item, prefab.GameObject));

            result.Prefab = prefab;

            return result;
        }

        public class Prefab
        {
            public string ExistingPrefabPath;
            public string InternalName;
            public TechType Item;
            public string NewPrefabPath;

            public Prefab(string prefabPath, string internalName, TechType item)
            {
                ExistingPrefabPath = prefabPath;
                InternalName = internalName;
                Item = item;
                NewPrefabPath = prefabPath + internalName;
            }

            public GameObject GameObject()
            {
                if (InternalName == null) return null;

                GameObject prefab = Resources.Load<GameObject>(ExistingPrefabPath);
                GameObject obj = UnityEngine.Object.Instantiate(prefab);

                PrefabIdentifier identifier = obj.GetComponent<PrefabIdentifier>();

                identifier.ClassId = InternalName;

                return obj;
            }
        }
    }

    internal static class Utils
    {

        internal static class LogUtils
        {
            internal static void Log(string message, string messagePrefix, bool debug = true)
            {
                if (!debug) return;
                #region string caller = Assembly.GetCallingAssembly().GetName().Name;
                string caller;
                try
                {
                    caller = Assembly.GetCallingAssembly().GetName().Name;
                }
                catch
                {
                    caller = "ERROR GETTING CALLER";
                }
                #endregion
                string prefix = Values.NullCheck(messagePrefix) ? "" : $"[{messagePrefix}]";
                Console.WriteLine($"[{caller}] {prefix} {message}");
            }
        }

    }

}