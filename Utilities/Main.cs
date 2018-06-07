using SMLHelper;
using SMLHelper.Patchers;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace AlexejheroYTB.Utilities
{
    /// <summary>
    /// Play around with values
    /// </summary>
    public static class Values
    {
        /// <summary>
        /// Swap two values
        /// </summary>
        /// <typeparam name="T">The type of the values</typeparam>
        /// <param name="value1">First value</param>
        /// <param name="value2">Second value</param>
        public static void Swap<T>(ref T value1, ref T value2)
        {
            T tempObj = value1;
            value1 = value2;
            value2 = tempObj;
        }
        /// <summary>
        /// Null check a variable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="var">Value to nullcheck</param>
        /// <returns>True if it is null, False if it is not</returns>
        public static bool NullCheck<T>(T var)
        {
            if (var == null) return true;
            else return false;
        }
        /// <summary>
        /// Null check multiple variables
        /// </summary>
        public static class NullCheckMultiple
        {
            /// <summary>
            /// Check if one of the values is null
            /// </summary>
            /// <typeparam name="T">The type of the values</typeparam>
            /// <param name="variables">Values to null check</param>
            /// <returns>True if one or more is null, False if none are null</returns>
            public static bool CheckIfOne<T>(params T[] variables)
            {
                foreach (T variable in variables)
                {
                    if (variable == null) return true;
                }
                return false;
            }
            /// <summary>
            /// Check if all of the values are null
            /// </summary>
            /// <typeparam name="T">The type of the values</typeparam>
            /// <param name="variables">Values to null check</param>
            /// <returns>True if all are null, False if not all are null</returns>
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
    /// <summary>
    /// Main class for logging messages to <see cref="Console"/>
    /// </summary>
    public static class Logging
    {
        /// <summary>
        /// Logs a message to <see cref="Console"/> without a prefix. Alternative to using <see cref="Message(string, bool)"/>
        /// </summary>
        /// <param name="message">The message to log to the console</param>
        /// <param name="onlyLogIfTrue">Only logs the messages if this is true</param>
        public static void Log(string message, bool onlyLogIfTrue = true)
        {
            Message(message, onlyLogIfTrue);
        }
        /// <summary>
        /// Logs a message to <see cref="Console"/> without a prefix.
        /// </summary>
        /// <param name="message">The message to log to the console</param>
        /// <param name="onlyLogIfTrue">Only logs the messages if this is true</param>
        public static void Message(string message, bool onlyLogIfTrue = true)
        {
            Utils.LogUtils.Log(message, null, onlyLogIfTrue);
        }
        /// <summary>
        /// Logs a message to <see cref="Console"/> with a "DEBUG" prefix
        /// </summary>
        /// <param name="message">The message to log to the console</param>
        /// <param name="onlyLogIfTrue">Only logs the messages if this is true</param>
        public static void Debug(string message, bool onlyLogIfTrue = true)
        {
            Utils.LogUtils.Log(message, "DEBUG", onlyLogIfTrue);
        }
        /// <summary>
        /// Logs a message to <see cref="Console"/> with a "WARNING" prefix
        /// </summary>
        /// <param name="message">The message to log to the console</param>
        /// <param name="onlyLogIfTrue">Only logs the messages if this is true</param>
        public static void Warning(string message, bool onlyLogIfTrue = true)
        {
            Utils.LogUtils.Log(message, "WARNING", onlyLogIfTrue);
        }
        /// <summary>
        /// Logs a message to <see cref="Console"/> with a "ERROR" prefix
        /// </summary>
        /// <param name="message">The message to log to the console</param>
        /// <param name="onlyLogIfTrue">Only logs the messages if this is true</param>
        public static void Error(string message, bool onlyLogIfTrue = true)
        {
            Utils.LogUtils.Log(message, "ERROR", onlyLogIfTrue);
        }

    }
    /// <summary>
    /// Class for managing items
    /// </summary>
    public static class Items
    {
        /// <summary>
        /// The result every method in this class will return
        /// </summary>
        public class Result
        {
            /// <summary>
            /// The <see cref="CustomCraftNode"/> this item was added to
            /// </summary>
            public CustomCraftNode CustomCraftNode;
            /// <summary>
            /// The <see cref="SMLHelper.CustomSprite"/> this item was given
            /// </summary>
            public CustomSprite CustomSprite;
            /// <summary>
            /// The <see cref="Atlas.Sprite"/> which was used to make the <see cref="SMLHelper.CustomSprite"/>
            /// </summary>
            public Atlas.Sprite Sprite;
            /// <summary>
            /// The <see cref="TechDataHelper"/> that was associated to this item
            /// </summary>
            public TechDataHelper TechDataHelper;
            /// <summary>
            /// The <see cref="TechType"/> of the item
            /// </summary>
            public TechType TechType;
        }

        /// <summary>
        /// Adds a dummy item
        /// </summary>
        /// <param name="name">The internal name of the item. Can be ommited and it will be automatically generated</param>
        /// <param name="languageName">The name of the item</param>
        /// <param name="languageTooltip">The tooltip of the item</param>
        /// <param name="spriteItem">The <see cref="TechType"/> from which to get the <see cref="Atlas.Sprite"/></param>
        /// <param name="fabricatorNodePath">The path where the item should be added in the fabricator</param>
        /// <param name="ingredientItems">The ingredient items of the recipe</param>
        /// <param name="resultingItems">The resulting items of the recipe</param>
        /// <param name="prefabPath">The path of the prefab. Can be ommited and the item will not have a prefab</param>
        /// <returns>A <see cref="Result"/> item</returns>
        public static Result AddDummy(string name, string languageName, string languageTooltip, TechType spriteItem, string fabricatorNodePath, List<IngredientHelper> ingredientItems, List<TechType> resultingItems, string prefabPath = null)
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

            Result result = new Result()
            {
                CustomCraftNode = customCraftNode,
                CustomSprite = customSprite,
                Sprite = sprite,
                TechDataHelper = techData,
                TechType = techType,
            };

            if (prefabPath == null)
                return result;

            Utils.ItemUtils.Prefab prefab = new Utils.ItemUtils.Prefab(prefabPath, name, techType);
            CustomPrefabHandler.customPrefabs.Add(new CustomPrefab(prefab.InternalName, prefab.NewPrefabPath, prefab.Item, prefab.GameObject));

            return result;
        }
        /// <summary>
        /// Adds a dummy item
        /// </summary>
        /// <param name="languageName">The name of the item</param>
        /// <param name="languageTooltip">The tooltip of the item</param>
        /// <param name="spriteItem">The <see cref="TechType"/> from which to get the <see cref="Atlas.Sprite"/></param>
        /// <param name="fabricatorNodePath">The path where the item should be added in the fabricator</param>
        /// <param name="ingredientItems">The ingredient items of the recipe</param>
        /// <param name="resultingItems">The resulting items of the recipe</param>
        /// <param name="prefabPath">The path of the prefab. Can be ommited and the item will not have a prefab</param>
        /// <returns>A <see cref="Result"/> item</returns>
        public static Result AddDummy(string languageName, string languageTooltip, TechType spriteItem, string fabricatorNodePath, List<IngredientHelper> ingredientItems, List<TechType> resultingItems, string prefabPath = null)
        {
            string parsedName = String.Join("", languageName.Split(' ', '_', '-', '\'', '"'));
            return AddDummy(parsedName, languageName, languageTooltip, spriteItem, fabricatorNodePath, ingredientItems, resultingItems, prefabPath);
        }

    }
    /// <summary>
    /// Internal utilities class
    /// </summary>
    internal static class Utils
    {
        /// <summary>
        /// Utilities for logging
        /// </summary>
        internal static class LogUtils
        {
            /// <summary>
            /// Log a message to the console
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="messagePrefix">The prefix to put before the message</param>
            /// <param name="onlyLogIfTrue">Only log the message if this is true</param>
            internal static void Log(string message, string messagePrefix, bool onlyLogIfTrue = true)
            {
                if (!onlyLogIfTrue) return;
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
        /// <summary>
        /// Utilities for items
        /// </summary>
        internal class ItemUtils
        {
            /// <summary>
            /// Flexible Prefab item for <see cref="CustomPrefabHandler.customPrefabs"/>.Add(<see cref="CustomPrefab"/>)
            /// </summary>
            internal class Prefab
            {
                /// <summary>
                /// The prefab path of the existing item
                /// </summary>
                public string ExistingPrefabPath;
                /// <summary>
                /// The internal name of the new item
                /// </summary>
                public string InternalName;
                /// <summary>
                /// The <see cref="TechType"/> of the new item
                /// </summary>
                public TechType Item;
                /// <summary>
                /// The prefab path of the new item. Is generated automatically from <see cref="ExistingPrefabPath"/> + <see cref="InternalName"/>
                /// </summary>
                public string NewPrefabPath;

                /// <summary>
                /// Make a new <see cref="Prefab"/> item
                /// </summary>
                /// <param name="existingPrefabPath">The prefab path of the existing item</param>
                /// <param name="internalName">The internal name of the new item</param>
                /// <param name="item">The <see cref="TechType"/> of the new item</param>
                public Prefab(string existingPrefabPath, string internalName, TechType item)
                {
                    ExistingPrefabPath = existingPrefabPath;
                    InternalName = internalName;
                    Item = item;
                    NewPrefabPath = existingPrefabPath + internalName;
                }
                /// <summary>
                /// Get the <see cref="UnityEngine.GameObject"/> associated with this <see cref="Prefab"/>
                /// </summary>
                /// <returns>The <see cref="UnityEngine.GameObject"/> associated with this <see cref="Prefab"/></returns>
                public GameObject GameObject()
                {
                    if (InternalName == null)
                    {
                        Logging.Error("Error setting GameObject. InternalName is null");
                        Logging.Debug(OutputDebug());
                    }

                    if (ExistingPrefabPath == null)
                    {
                        Logging.Error("Error setting GameObject. ExistingPrefabPath is null");
                        Logging.Debug(OutputDebug());
                    }

                    GameObject prefab = Resources.Load<GameObject>(ExistingPrefabPath);
                    GameObject obj = UnityEngine.Object.Instantiate(prefab);

                    PrefabIdentifier identifier = obj.GetComponent<PrefabIdentifier>();

                    identifier.ClassId = InternalName;

                    return obj;
                }
                /// <summary>
                /// Outputs all information about this <see cref="Prefab"/> object for debugging
                /// </summary>
                /// <returns>The string to output to the console</returns>
                public string OutputDebug()
                {
                    return
                        $"ExistingPrefabPath: {(ExistingPrefabPath ?? "null")}, " +
                        $"InternalName: {(InternalName ?? "null")}, " +
                        $"Item: {(Item != TechType.None ? Item.ToString() : "null")}" +
                        $"NewPrefabPath: {(NewPrefabPath ?? "null")}";
                }
            }
        }
    }
}