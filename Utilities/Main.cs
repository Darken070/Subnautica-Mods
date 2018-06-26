using SMLHelper;
using SMLHelper.Patchers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Text;
using Harmony;
using AlexejheroYTB.Utilities.Extensions;
using System.Threading;

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
            return false;
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
                    if (NullCheck(variable)) return true;
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
                    if (!NullCheck(variable)) return false;
                }
                return true;
            }
        }
        /// <summary>
        /// Clamps a <see langword="float"/> between a min and a max value
        /// </summary>
        /// <param name="value">Value to clamp</param>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns>The clamped value</returns>
        public static float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
        /// <summary>
        /// Clamps a <see langword="int"/> between a min and a max value
        /// </summary>
        /// <param name="value">Value to clamp</param>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns>The clamped value</returns>
        public static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
        /// <summary>
        /// Clamps a <see langword="float"/> between a min and a max value
        /// </summary>
        /// <param name="value">Value to clamp</param>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns>The clamped value</returns>
        public static void Clamp(ref float value, float min, float max)
        {
            if (value < min) value = min;
            if (value > max) value = max;
        }
        /// <summary>
        /// Clamps a <see langword="int"/> between a min and a max value
        /// </summary>
        /// <param name="value">Value to clamp</param>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns>The clamped value</returns>
        public static void Clamp(ref int value, int min, int max)
        {
            if (value < min) value = min;
            if (value > max) value = max;
        }
        /// <summary>
        /// Generates a random number between a minimum and a maximum value. (Can also generate the min or max)
        /// </summary>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <returns>A random number between <paramref name="min"/> and <paramref name="max"/></returns>
        /// <exception cref="OverflowException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public static int Random(int min, int max)
        {
            if (min == int.MinValue && max == int.MaxValue) return Random();
            if (max == int.MaxValue) return new System.Random().Next(min, max);
            return new System.Random().Next(min, max++);
        }
        /// <summary>
        /// Generates a random number between the minimum possible value and the maximum possible value
        /// </summary>
        /// <returns>A random number</returns>
        /// <exception cref="OverflowException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public static int Random()
            => new System.Random().Next(int.MinValue, int.MaxValue);
        /// <summary>
        /// Gets the value of a field from an instance of a class using reflection
        /// <para/> Extension from <see langword="AlexejheroYTB.Utilities.Extensions"/>
        /// </summary>
        /// <typeparam name="classInstance">The class type</typeparam>
        /// <param name="instance">The instance of <typeparamref name="classInstance"/></param>
        /// <param name="field">The name of the field</param>
        /// <param name="bindingFlags">The <see cref="BindingFlags"/> to use with <see cref="Type.GetField(string, BindingFlags)"/></param>
        /// <returns>The value of field from the instance of the class</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="TargetException"/>
        /// <exception cref="NotSupportedException"/>
        /// <exception cref="FieldAccessException"/>
        /// <exception cref="ArgumentException"/>
        public static object GetValue<classInstance>(classInstance instance, string field, BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance) where classInstance : class
            => typeof(classInstance).GetField(field, bindingFlags).GetValue(instance);
        /// <summary>
        /// Sets the value of a field from an instance of a class using reflection
        /// <para/> Extension from <see langword="AlexejheroYTB.Utilities.Extensions"/>
        /// </summary>
        /// <typeparam name="classInstance">The class type</typeparam>
        /// <param name="instance">The instance of <typeparamref name="classInstance"/></param>
        /// <param name="field">The name of the field</param>
        /// <param name="newValue">The new value to set</param>
        /// <param name="bindingFlags">The <see cref="BindingFlags"/> to use with <see cref="Type.GetField(string, BindingFlags)"/></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="FieldAccessException"/>
        /// <exception cref="TargetException"/>
        /// <exception cref="ArgumentException"/>
        public static void SetValue<classInstance>(classInstance instance, string field, object newValue, BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance) where classInstance : class
            => typeof(classInstance).GetField(field, bindingFlags).SetValue(instance, newValue);
        /// <summary>
        /// Gets the value of a field from a static class using reflection
        /// <para/> Extension from <see langword="AlexejheroYTB.Utilities.Extensions"/>
        /// </summary>
        /// <typeparam name="class">The class to get the value from</typeparam>
        /// <param name="field">The name of the field</param>
        /// <param name="bindingFlags">The <see cref="BindingFlags"/> to use with <see cref="Type.GetField(string, BindingFlags)"/></param>
        /// <returns>The value of field from the instance of the class</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="TargetException"/>
        /// <exception cref="NotSupportedException"/>
        /// <exception cref="FieldAccessException"/>
        /// <exception cref="ArgumentException"/>
        public static object GetValue<@class>(string field, BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Static) where @class : class
            => typeof(@class).GetField(field, bindingFlags).GetValue(null);
        /// <summary>
        /// Sets the value of a field from a static class using reflection
        /// <para/> Extension from <see langword="AlexejheroYTB.Utilities.Extensions"/>
        /// </summary>
        /// <typeparam name="class">The class to get the value from</typeparam>
        /// <param name="field">The name of the field</param>
        /// <param name="newValue">The new value to set</param>
        /// <param name="bindingFlags">The <see cref="BindingFlags"/> to use with <see cref="Type.GetField(string, BindingFlags)"/></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="FieldAccessException"/>
        /// <exception cref="TargetException"/>
        /// <exception cref="ArgumentException"/>
        public static void SetValue<@class>(string field, object newValue, BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Static) where @class : class
            => typeof(@class).GetField(field, bindingFlags).SetValue(null, newValue);
    }
    /// <summary>
    /// Main class for logging messages to <see cref="Console"/>
    /// </summary>
    public static class OutputLog
    {
        /// <summary>
        /// Log a message to the console
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="customCaller"><see langword="(Optional)"/> The custom caller to output in the log. If omitted, will use reflection to get caller</param>
        /// <param name="messagePrefix"><see langword="(Optional)"/> The prefix to put before the message</param>
        /// <param name="onlyLogIfTrue"><see langword="(Optional, Default = true)"/> Only log the message if this is true</param>
        private static void Log(string message, string customCaller = null, string messagePrefix = null, bool onlyLogIfTrue = true)
        {
            if (!onlyLogIfTrue) return;
            string caller;
            if (customCaller == null)
            {
                try
                {
                    caller = Assembly.GetCallingAssembly().Name();
                }
                catch
                {
                    caller = "ERROR GETTING CALLER";
                }
            }
            else caller = customCaller;
            string prefix = messagePrefix == null ? "" : $"[{messagePrefix}]";
            Console.WriteLine($"[{caller}] {prefix} {message}");
        }
        /// <summary>
        /// Logs a message to <see cref="Console"/> without a prefix. Alias to <see cref="Message(string, bool)"/>
        /// </summary>
        /// <param name="message">The message to log to the console</param>
        /// <param name="customCaller"><see langword="(Optional)"/> The custom caller to output in the log. If omitted, will use reflection to get caller</param>
        /// <param name="onlyLogIfTrue"><see langword="(Optional, Default = true)"/> Only logs the messages if this is true</param>
        public static void Log(string message, string customCaller = null, bool onlyLogIfTrue = true)
            => Message(message, customCaller, onlyLogIfTrue);
        /// <summary>
        /// Logs a message to <see cref="Console"/> without a prefix.
        /// </summary>
        /// <param name="message">The message to log to the console</param>
        /// <param name="customCaller"><see langword="(Optional)"/> The custom caller to output in the log. If omitted, will use reflection to get caller</param>
        /// <param name="onlyLogIfTrue"><see langword="(Optional, Default = true)"/> Only logs the messages if this is true</param>
        public static void Message(string message, string customCaller = null, bool onlyLogIfTrue = true)
            => Log(message, customCaller, null, onlyLogIfTrue);
        /// <summary>
        /// Logs a message to <see cref="Console"/> with a "DEBUG" prefix
        /// </summary>
        /// <param name="message">The message to log to the console</param>
        /// <param name="customCaller"><see langword="(Optional)"/> The custom caller to output in the log. If omitted, will use reflection to get caller</param>
        /// <param name="onlyLogIfTrue"><see langword="(Optional, Default = true)"/> Only logs the messages if this is true</param>
        public static void Debug(string message, string customCaller = null, bool onlyLogIfTrue = true)
            => Log(message, customCaller, "DEBUG", onlyLogIfTrue);
        /// <summary>
        /// Logs a message to <see cref="Console"/> with a "WARNING" prefix
        /// </summary>
        /// <param name="message">The message to log to the console</param>
        /// <param name="customCaller"><see langword="(Optional)"/> The custom caller to output in the log. If omitted, will use reflection to get caller</param>
        /// <param name="onlyLogIfTrue"><see langword="(Optional, Default = true)"/> Only logs the messages if this is true</param>
        public static void Warning(string message, string customCaller = null, bool onlyLogIfTrue = true)
            => Log(message, customCaller, "WARNING", onlyLogIfTrue);
        /// <summary>
        /// Logs a message to <see cref="Console"/> with a "ERROR" prefix
        /// </summary>
        /// <param name="message">The message to log to the console</param>
        /// <param name="customCaller"><see langword="(Optional)"/> The custom caller to output in the log. If omitted, will use reflection to get caller</param>
        /// <param name="onlyLogIfTrue"><see langword="(Optional, Default = true)"/> Only logs the messages if this is true</param>
        public static void Error(string message, string customCaller = null, bool onlyLogIfTrue = true)
            => Log(message, customCaller, "ERROR", onlyLogIfTrue);
        /// <summary>
        /// Logs a message to the player screen using <see cref="ErrorMessage.AddMessage(string)"/>
        /// </summary>
        /// <param name="message">The message to log to the console</param>
        /// <param name="onlyLogIfTrue"><see langword="(Optional, Default = true)"/> Only logs the messages if this is true</param>
        public static void Screen(string message, bool onlyLogIfTrue = true)
        {
            if (onlyLogIfTrue)
                ErrorMessage.AddMessage(message);
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
            /// The <see cref="SMLHelper.CustomCraftNode"/> this item was added to
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
            /// The <see cref="SMLHelper.Patchers.TechDataHelper"/> that was associated to this item
            /// </summary>
            public TechDataHelper TechDataHelper;
            /// <summary>
            /// The <see cref="global::TechType"/> of the item
            /// </summary>
            public TechType TechType;
        }
        /// <summary>
        /// A flexible Prefab item for <see cref="CustomPrefabHandler.customPrefabs"/>.Add(<see cref="CustomPrefab"/>)
        /// </summary>
        private class PrefabGenerator
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
            public PrefabGenerator(string existingPrefabPath, string internalName, TechType item)
            {
                ExistingPrefabPath = existingPrefabPath;
                InternalName = internalName;
                Item = item;
                NewPrefabPath = existingPrefabPath + internalName;
            }

            /// <summary>
            /// Get the <see cref="UnityEngine.GameObject"/> associated with this <see cref="PrefabGenerator"/>
            /// </summary>
            /// <returns>The <see cref="UnityEngine.GameObject"/> associated with this <see cref="PrefabGenerator"/></returns>
            public GameObject GameObject()
            {
                if (InternalName == null)
                {
                    OutputLog.Error("Error setting GameObject. InternalName is null", Assembly.GetCallingAssembly().Name());
                    OutputLog.Debug(OutputDebug());
                }

                if (ExistingPrefabPath == null)
                {
                    OutputLog.Error("Error setting GameObject. ExistingPrefabPath is null", Assembly.GetCallingAssembly().Name());
                    OutputLog.Debug(OutputDebug());
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
        /// <summary>
        /// Adds a dummy item
        /// </summary>
        /// <param name="name">The internal name of the item. Can be omitted and it will be automatically generated</param>
        /// <param name="languageName">The name of the item</param>
        /// <param name="languageTooltip">The tooltip of the item</param>
        /// <param name="spriteItem">The <see cref="TechType"/> from which to get the <see cref="Atlas.Sprite"/></param>
        /// <param name="fabricatorNodePath">The path where the item should be added in the fabricator</param>
        /// <param name="ingredientItems">The ingredient item(s) of the recipe. Must be either <see cref="IngredientHelper"/> or a <see cref="List{IngredientHelper}"/> of <see cref="IngredientHelper"/></param>
        /// <param name="resultingItems">The resulting items of the recipe. Must be either <see cref="TechType"/> or a <see cref="List{T}"/> of <see cref="TechType"/></param>
        /// <param name="prefabPath">The path of the prefab. Can be omitted and the item will not have a prefab</param>
        /// <returns>A <see cref="Result"/></returns>
        private static Result AddDummy(string name, string languageName, string languageTooltip, TechType spriteItem, string fabricatorNodePath, List<IngredientHelper> ingredientItems, List<TechType> resultingItems, string prefabPath = null)
        {
            TechType techType = TechTypePatcher.AddTechType(name, languageName, languageTooltip);
            Atlas.Sprite sprite = SpriteManager.Get(spriteItem);
            CustomSprite customSprite = new CustomSprite(techType, sprite);
            CustomCraftNode customCraftNode = new CustomCraftNode(techType, CraftTree.Type.Fabricator, fabricatorNodePath);
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

            PrefabGenerator prefab = new PrefabGenerator(prefabPath, name, techType);
            CustomPrefabHandler.customPrefabs.Add(new CustomPrefab(prefab.InternalName, prefab.NewPrefabPath, prefab.Item, prefab.GameObject));

            return result;
        }
        /// <summary>
        /// Adds a dummy item
        /// </summary>
        /// <typeparam name="IngredientHelperOrListOfIngredientHelper"></typeparam>
        /// <typeparam name="TechTypeOrListOfTechType"></typeparam>
        /// <param name="name">The internal name of the item. Can be omitted and it will be automatically generated</param>
        /// <param name="languageName">The name of the item</param>
        /// <param name="languageTooltip">The tooltip of the item</param>
        /// <param name="spriteItem">The <see cref="TechType"/> from which to get the <see cref="Atlas.Sprite"/></param>
        /// <param name="fabricatorNodePath">The path where the item should be added in the fabricator</param>
        /// <param name="ingredientItems">The ingredient item(s) of the recipe. Must be either <see cref="IngredientHelper"/> or a <see cref="List{IngredientHelper}"/> of <see cref="IngredientHelper"/></param>
        /// <param name="resultingItems">The resulting items of the recipe. Must be either <see cref="TechType"/> or a <see cref="List{T}"/> of <see cref="TechType"/></param>
        /// <param name="prefabPath">The path of the prefab. Can be omitted and the item will not have a prefab</param>
        /// <returns>A <see cref="Result"/></returns>
        public static Result AddDummy<IngredientHelperOrListOfIngredientHelper, TechTypeOrListOfTechType>(string name, string languageName, string languageTooltip, TechType spriteItem, string fabricatorNodePath, IngredientHelperOrListOfIngredientHelper ingredientItems, TechTypeOrListOfTechType resultingItems, string prefabPath = null)
        {
            List<IngredientHelper> ingredientList = new List<IngredientHelper>();
            if (ingredientItems is IngredientHelper)
            {
                ingredientList.Add((IngredientHelper)(object)ingredientItems);
            }
            else if (ingredientItems is List<IngredientHelper>)
            {
                ingredientList = (List<IngredientHelper>)(object)ingredientItems;
            }
            else
            {
                throw new ArgumentException("Argument is neither IngredientHelper not List<IngredientHelper>", "ingredientItems");
            }
            List<TechType> resultList = new List<TechType>();
            if (resultingItems is TechType)
            {
                resultList.Add((TechType)(object)resultingItems);
            }
            else if (resultingItems is List<TechType>)
            {
                resultList = (List<TechType>)(object)resultingItems;
            }
            else
            {
                throw new ArgumentException("Argument is neither TechType not List<TechType>", "resultingItems");
            }
            return AddDummy(name, languageName, languageTooltip, spriteItem, fabricatorNodePath, ingredientList, resultList, prefabPath);
        }
        /// <summary>
        /// Adds a dummy item
        /// </summary>
        /// <typeparam name="IngredientHelperOrListOfIngredientHelper"></typeparam>
        /// <typeparam name="TechTypeOrListOfTechType"></typeparam>
        /// <param name="languageName">The name of the item</param>
        /// <param name="languageTooltip">The tooltip of the item</param>
        /// <param name="spriteItem">The <see cref="TechType"/> from which to get the <see cref="Atlas.Sprite"/></param>
        /// <param name="fabricatorNodePath">The path where the item should be added in the fabricator</param>
        /// <param name="ingredientItems">The ingredient item(s) of the recipe. Must be either <see cref="IngredientHelper"/> or a <see cref="List{IngredientHelper}"/> of <see cref="IngredientHelper"/></param>
        /// <param name="resultingItems">The resulting items of the recipe. Must be either <see cref="TechType"/> or a <see cref="List{T}"/> of <see cref="TechType"/></param>
        /// <param name="prefabPath">The path of the prefab. Can be omitted and the item will not have a prefab</param>
        /// <returns>A <see cref="Result"/></returns>
        public static Result AddDummy<IngredientHelperOrListOfIngredientHelper, TechTypeOrListOfTechType>(string languageName, string languageTooltip, TechType spriteItem, string fabricatorNodePath, IngredientHelperOrListOfIngredientHelper ingredientItems, TechTypeOrListOfTechType resultingItems, string prefabPath = null)
        {
            string parsedName = String.Join("", languageName.Split(' ', '_', '-', '\'', '"'));
            List<IngredientHelper> ingredientList = new List<IngredientHelper>();
            if (ingredientItems is IngredientHelper)
            {
                ingredientList.Add((IngredientHelper)(object)ingredientItems);
            }
            else if (ingredientItems is List<IngredientHelper>)
            {
                ingredientList = (List<IngredientHelper>)(object)ingredientItems;
            }
            else
            {
                throw new ArgumentException("Argument is neither IngredientHelper not List<IngredientHelper>", "ingredientItems");
            }
            List<TechType> resultList = new List<TechType>();
            if (resultingItems is TechType)
            {
                resultList.Add((TechType)(object)resultingItems);
            }
            else if (resultingItems is List<TechType>)
            {
                resultList = (List<TechType>)(object)resultingItems;
            }
            else
            {
                throw new ArgumentException("Argument is neither TechType not List<TechType>", "resultingItems");
            }
            return AddDummy(parsedName, languageName, languageTooltip, spriteItem, fabricatorNodePath, ingredientList, resultList, prefabPath);
        }
    }
    /// <summary>
    /// Miscellaneous methods
    /// </summary>
    public static class Misc
    {
        /// <summary>
        /// Closes and openes the disk tray
        /// </summary>
        public static class DiskTray
        {
            /// <summary>
            /// Sends a command
            /// </summary>
            /// <param name="lpstrCommand">Command to send</param>
            /// <param name="lpstrReturnString">Taken care of by <see cref="SendCommand(string)"/></param>
            /// <param name="uReturnLength">Taken care of by <see cref="SendCommand(string)"/></param>
            /// <param name="hwndCallback">Taken care of by <see cref="SendCommand(string)"/></param>
            /// <returns>Taken care of by <see cref="SendCommand(string)"/></returns>
            [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi)]
            private static extern int SendCommand(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, IntPtr hwndCallback);
            /// <summary>
            /// Sends a command using <see cref="SendCommand(string, StringBuilder, int, IntPtr)"/> with simplified parameters
            /// </summary>
            /// <param name="command">The command to send</param>
            private static void SendCommand(string command)
                => SendCommand(command, null, 0, IntPtr.Zero);
            /// <summary>
            /// Stores possible disk tray actions
            /// </summary>
            private enum DiskTrayAction
            {
                /// <summary>
                /// Opens the disk tray
                /// </summary>
                Open,
                /// <summary>
                /// Closes the disk tray, if supported
                /// </summary>
                Close,
            }
            /// <summary>
            /// Opens and closes the disk tray
            /// </summary>
            /// <param name="state">The <see cref="DiskTrayAction"/> that should be taken</param>
            private static void ManageDiskTray(DiskTrayAction state)
            {
                switch (state)
                {
                    case DiskTrayAction.Open:
                        SendCommand("set cdaudio door open");
                        break;
                    case DiskTrayAction.Close:
                        SendCommand("set cdaudio door closed");
                        break;
                }

            }
            /// <summary>
            /// Openes the disk tray
            /// </summary>
            public static void Open()
                => ManageDiskTray(DiskTrayAction.Open);
            /// <summary>
            /// Closes the disk tray, if supported
            /// </summary>
            public static void Close()
                => ManageDiskTray(DiskTrayAction.Close);
        }
        /// <summary>
        /// Wait for seconds
        /// </summary>
        /// <param name="time">Time to wait for</param>
        public static void Wait(float time)
            => Thread.Sleep((int)Math.Round(time * 1000));
    }

    namespace Extensions
    {
        /// <summary>
        /// Extensions for <see cref="Array"/>, which inherits from <see cref="IList{T}"/>
        /// </summary>
        public static class ArrayExtensions
        {
            /// <summary>
            /// Changes an array by a given lambda function.
            /// <para/> Extension from <see langword="AlexejheroYTB.Utilities.Extensions"/>
            /// </summary>
            /// <typeparam name="T">The type of the array</typeparam>
            /// <param name="source">The array to change</param>
            /// <param name="projection">The lambda function to execute on each element of the array</param>
            /// <param name="onlyChangeIf"><see langword="(Optional)"/> Only change the element if this function returns true</param>
            public static void Change<T>(this IList<T> source, Func<T, T> projection, Func<T, bool> onlyChangeIf = null)
            {
                for (int i = 0; i < source.Count; i++)
                {
                    if (onlyChangeIf == null)
                    {
                        source[i] = projection(source[i]);
                        continue;
                    }
                    if (onlyChangeIf(source[i]))
                    {
                        source[i] = projection(source[i]);
                    }
                }
            }
        }
        /// <summary>
        /// Extensions for <see cref="Assembly"/>
        /// </summary>
        public static class AssemblyExtensions
        {
            /// <summary>
            /// Gets the name of an assembly. Shorthand to writing <see cref="Assembly.GetName()"/>.Name
            /// <para/> Extension from <see langword="AlexejheroYTB.Utilities.Extensions"/>
            /// </summary>
            /// <param name="assembly"></param>
            /// <returns></returns>
            public static string Name(this Assembly assembly)
                => assembly.GetName().Name;
        }
        /// <summary>
        /// Generic extensions for instances of classes
        /// </summary>
        public static class ClassInstanceExtensions
        {
            /// <summary>
            /// Gets the value of a field from an instance of a class using reflection
            /// <para/> Extension from <see langword="AlexejheroYTB.Utilities.Extensions"/>
            /// </summary>
            /// <typeparam name="classInstance">The class type</typeparam>
            /// <param name="instance">The instance of <typeparamref name="classInstance"/></param>
            /// <param name="field">The name of the field</param>
            /// <param name="bindingFlags">The <see cref="BindingFlags"/> to use with <see cref="Type.GetField(string, BindingFlags)"/></param>
            /// <returns>The value of field from the instance of the class</returns>
            /// <exception cref="ArgumentNullException"/>
            /// <exception cref="TargetException"/>
            /// <exception cref="NotSupportedException"/>
            /// <exception cref="FieldAccessException"/>
            /// <exception cref="ArgumentException"/>
            public static object GetValue<classInstance>(this classInstance instance, string field, BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance) where classInstance : class
                => Values.GetValue(instance, field, bindingFlags);
            /// <summary>
            /// Sets the value of a field from an instance of a class using reflection
            /// <para/> Extension from <see langword="AlexejheroYTB.Utilities.Extensions"/>
            /// </summary>
            /// <typeparam name="classInstance">The class type</typeparam>
            /// <param name="instance">The instance of <typeparamref name="classInstance"/></param>
            /// <param name="field">The name of the field</param>
            /// <param name="newValue">The new value to set</param>
            /// <param name="bindingFlags">The <see cref="BindingFlags"/> to use with <see cref="Type.GetField(string, BindingFlags)"/></param>
            /// <exception cref="ArgumentNullException"/>
            /// <exception cref="FieldAccessException"/>
            /// <exception cref="TargetException"/>
            /// <exception cref="ArgumentException"/>
            public static void SetValue<classInstance>(this classInstance instance, string field, object newValue, BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance) where classInstance : class
                => Values.SetValue(instance, field, newValue, bindingFlags);
        }
        /// <summary>
        /// Generic extensions
        /// </summary>
        public static class GenericExtensions
        {
            /// <summary>
            /// Turns a value into an array containing that value.
            /// <para/>Extension from <see langword="AlexejheroYTB.Utilities.Extensions"/>
            /// </summary>
            /// <typeparam name="T">The type of the value</typeparam>
            /// <param name="value">The value to turn into an array</param>
            /// <returns>The array</returns>
            /// <exception cref="ArrayTypeMismatchException"/>
            public static T[] Array<T>(this T value)
            {
                if (value.GetType().IsArray)
                    throw new ArrayTypeMismatchException("The value is already an array!");
                return new[] { value };
            }
            /// <summary>
            /// Changes the type of an object
            /// </summary>
            /// <typeparam name="ResultingObject">The type of the resulting object</typeparam>
            /// <param name="obj">The object to convert</param>
            /// <returns>The resulting object</returns>
            /// <exception cref="InvalidCastException"/>
            public static ResultingObject As<ResultingObject>(this object obj)
                => obj.As<object, ResultingObject>();
            /// <summary>
            /// Changes the type of an object
            /// </summary>
            /// <typeparam name="InitialObject">The type of the initial object</typeparam>
            /// <typeparam name="ResultingObject">The type of the resulting object</typeparam>
            /// <param name="obj">The object to convert</param>
            /// <returns>The resulting object</returns>
            /// <exception cref="InvalidCastException"/>
            public static ResultingObject As<InitialObject, ResultingObject>(this InitialObject obj)
                => (ResultingObject)(object)obj;
        }
        /// <summary>
        /// Extensions for <see cref="HarmonyInstance"/>
        /// </summary>
        public static class HarmonyInstanceExtensions
        {
            /// <summary>
            /// Patches harmony using <see cref="Assembly.GetExecutingAssembly"/>. Alternative to using <see cref="HarmonyInstance.PatchAll(Assembly)"/>
            /// <para/> Extension from <see langword="AlexejheroYTB.Utilities.Extensions"/>
            /// </summary>
            /// <param name="Harmony"></param>
            public static void PatchAll(this HarmonyInstance Harmony)
                => Harmony.PatchAll(Assembly.GetCallingAssembly());
        }
        /// <summary>
        /// Extensions for <see cref="StreamWriter"/>
        /// </summary>
        public static class StreamWriterExtensions
        {
            /// <summary>
            /// Writes a string followed by a line terminator to the text stream
            /// <para/> Extension from <see langword="AlexejheroYTB.Utilities.Extensions"/>
            /// </summary>
            /// <param name="file">The file to write the text to</param>
            /// <param name="value"><see langword="(Optional)"/> The string to write. If value is null, only the line termination characters are written</param>
            /// <returns>The same <see cref="StreamWriter"/> it was provided</returns>
            /// <exception cref="ObjectDisposedException"/>
            /// <exception cref="IOException"/>
            public static StreamWriter AddLine(this StreamWriter file, string value = null)
            {
                file.WriteLine(value);
                return file;
            }
        }
        /// <summary>
        /// Extensions for <see cref="String"/>
        /// </summary>
        public static class StringExtensions
        {
            /// <summary>
            /// Removes certain characters from a string
            /// </summary>
            /// <param name="str">The string from which to remove the characters</param>
            /// <param name="chars">The characters to remove from the string</param>
            /// <returns>The parsed string</returns>
            /// <exception cref="ArgumentNullException"/>
            /// <exception cref="InvalidCastException"/>
            public static string RemoveChars(this string str, params char[] chars)
            {
                char[] array = str.ToCharArray();
                array = (char[])array.Where(x => Array.IndexOf(array, x) == -1);
                return new string(array);
            }
        }
    }

    namespace WIP
    {
        /// <summary>
        /// Class for managing config files
        /// </summary>
        [Obsolete("WIP. Not ready to be used yet", true)]
        public static class Config
        {
            /// <summary>
            /// Creates a config file with the specified path
            /// </summary>
            /// <param name="path"><see langword="(Default = config)"/> The path of the configuration file</param>
            /// <exception cref="EncoderFallbackException"/>
            /// <exception cref="ObjectDisposedException"/>
            /// <exception cref="IOException"/>
            public static void Create(string path = "config")
            {
                if (File.Exists($@".\{path}.txt"))
                {
                    File.Move($@".\{path}.txt", GenerateNext($"{path}-OLD-"));
                    File.CreateText($@".\{path}.txt")
                        .AddLine("ALEXEJHEROYTB.UTILITIES CONFIG FILE")
                        .AddLine()
                        .AddLine("# GENERATED AUTOMATICALLY")
                        .Close();
                }
            }
            /// <summary>
            /// Loads the config file with the specified path
            /// </summary>
            /// <param name="path"><see langword="(Default = config)"/> The path of the configuration file</param>
            /// <returns>An array of <see cref="string"/>s representing the lines found in the file</returns>
            public static Dictionary<string, string> Load(string path = "config")
            {
                string[] config = File.ReadAllLines($@".\{path}.txt");
                if (config[0] != "ALEXEJHEROYTB.UTILITIES CONFIG FILE")
                {
                    File.Move($@".\{path}.txt", GenerateNext($"{path}-WRONG-FORMAT-"));
                    Create(path);
                    return null;
                }
                else return Read(path);
            }
            /// <summary>
            /// Finds an option in the config
            /// </summary>
            /// <param name="option">Option</param>
            /// <param name="path"><see langword="(Default = config)"/> Configuration file path</param>
            /// <returns>The result</returns>
            public static string Find(string option, string path = "config")
            {
                string[] lines = File.ReadAllLines($@"{path}.txt");
                foreach (string line in lines)
                {
                    if (line.StartsWith($"{option}:"))
                        return line.Substring($"{option}:".Length).Trim();
                }
                return null;
            }
            /// <summary>
            /// Reads all valid lines of the config and saves it as a <see cref="Dictionary{TKey, TValue}"/> of <see cref="string"/> and <see cref="string"/>
            /// </summary>
            /// <param name="path"><see langword="(Default = config)"/> The path of the configuration file</param>
            /// <returns>A dictionary of all valid lines in the config</returns>
            /// <exception cref="ArgumentException"/>
            /// <exception cref="ArgumentNullException"/>
            /// <exception cref="PathTooLongException"/>
            /// <exception cref="DirectoryNotFoundException"/>
            /// <exception cref="IOException"/>
            /// <exception cref="UnauthorizedAccessException"/>
            /// <exception cref="FileNotFoundException"/>
            /// <exception cref="NotSupportedException"/>
            /// <exception cref="SecurityException"/>
            /// <exception cref="ArgumentOutOfRangeException"/>
            private static Dictionary<string, string> Read(string path = "config")
            {
                string[] config = File.ReadAllLines($@".\{path}.txt");
                foreach (string line in config)
                {
                    if (String.IsNullOrEmpty(line))
                    {
                        config = config.Where(val => val != line).ToArray();
                    }
                    if (line.StartsWith("#"))
                    {
                        config = config.Where(val => val != line).ToArray();
                    }
                    if (line.Contains("#"))
                    {
                        int i = line.IndexOf('#');
                        config.Change(val => val.Substring(0, i++).Trim());
                    }
                    if (!line.Contains(":"))
                    {
                        config = config.Where(val => val != line).ToArray();
                    }
                }
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                foreach (string line in config)
                {
                    string[] splitted = line.Split(':'.Array(), 2);
                    dictionary.Add(splitted[0], splitted[1]);
                }
                return dictionary;
            }
            /// <summary>
            /// Generates the next file path available using the path, the next <see cref="int"/> available, and the suffix
            /// </summary>
            /// <param name="path">The first path of the file</param>
            /// <param name="suffix"><see langword="(Default = .txt)"/> The suffix to add to the result</param>
            /// <returns>Generated path</returns>
            /// <exception cref="IOException"/>
            /// <exception cref="UnauthorizedAccessException"/>
            /// <exception cref="ArgumentException"/>
            /// <exception cref="ArgumentNullException"/>
            /// <exception cref="PathTooLongException"/>
            /// <exception cref="DirectoryNotFoundException"/>
            /// <exception cref="OverflowException"/>
            /// <exception cref="ArgumentOutOfRangeException"/>
            private static string GenerateNext(string path, string suffix = ".txt")
            {
                for (int i = 1; i <= Directory.GetFiles(@".\").Length; i++)
                {
                    if (!File.Exists($@".\{path}{i}{suffix}"))
                    {
                        return $@".\{path}{i}{suffix}";
                    }
                }
                return $@"{path}R{new System.Random().Next(1, 100000)}{suffix}";
            }
        }
    }
}