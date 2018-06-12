using SMLHelper;
using SMLHelper.Patchers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
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
    }
    /// <summary>
    /// Main class for logging messages to <see cref="Console"/>
    /// </summary>
    public static class Logging
    {
        /// <summary>
        /// Log a message to the console
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="messagePrefix">The prefix to put before the message</param>
        /// <param name="onlyLogIfTrue">Only log the message if this is true</param>
        private static void Log(string message, string messagePrefix, bool onlyLogIfTrue = true)
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
            Log(message, null, onlyLogIfTrue);
        }
        /// <summary>
        /// Logs a message to <see cref="Console"/> with a "DEBUG" prefix
        /// </summary>
        /// <param name="message">The message to log to the console</param>
        /// <param name="onlyLogIfTrue">Only logs the messages if this is true</param>
        public static void Debug(string message, bool onlyLogIfTrue = true)
        {
            Log(message, "DEBUG", onlyLogIfTrue);
        }
        /// <summary>
        /// Logs a message to <see cref="Console"/> with a "WARNING" prefix
        /// </summary>
        /// <param name="message">The message to log to the console</param>
        /// <param name="onlyLogIfTrue">Only logs the messages if this is true</param>
        public static void Warning(string message, bool onlyLogIfTrue = true)
        {
            Log(message, "WARNING", onlyLogIfTrue);
        }
        /// <summary>
        /// Logs a message to <see cref="Console"/> with a "ERROR" prefix
        /// </summary>
        /// <param name="message">The message to log to the console</param>
        /// <param name="onlyLogIfTrue">Only logs the messages if this is true</param>
        public static void Error(string message, bool onlyLogIfTrue = true)
        {
            Log(message, "ERROR", onlyLogIfTrue);
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
        /// Flexible Prefab item for <see cref="CustomPrefabHandler.customPrefabs"/>.Add(<see cref="CustomPrefab"/>)
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
        private static Dictionary<TechType, string> Prefabs = new Dictionary<TechType, string>()
        {
            { TechType.Titanium      ,   "WorldEntities/Natural/Titanium" },
            { TechType.FilteredWater , "WorldEntities/Food/FilteredWater" },
            { TechType.NutrientBlock , "WorldEntities/Food/NutrientBlock" },
            { TechType.ReactorRod    , "WorldEntities/Natural/ReactorRod" },
        };

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
    /// Class for config files
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// Loads the config file with the specified path
        /// </summary>
        /// <param name="path">The path of the config. Can be omitted</param>
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
        /// Creates a config file with the specified path
        /// </summary>
        /// <param name="path">The path of the config. Can be omitted</param>
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
        /// Finds an option in the config
        /// </summary>
        /// <param name="option">Option</param>
        /// <param name="path">Config path</param>
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
        /// <param name="path">The path of the config</param>
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
        /// Writes a string followed by a line terminator to the text stream
        /// </summary>
        /// <param name="file">The file to write the text to</param>
        /// <param name="value">The string to write. If value is null, only the line termination characters are written</param>
        /// <returns>The same <see cref="StreamWriter"/> it was provided</returns>
        /// <exception cref="ObjectDisposedException"/>
        /// <exception cref="IOException"/>
        private static StreamWriter AddLine(this StreamWriter file, string value = "")
        {
            file.WriteLine();
            return file;
        }
        /// <summary>
        /// Turns a value into an array containing that value.
        /// <para/>Extension from <see langword="AlexejheroYTB.Utilities"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        private static T[] Array<T>(this T value)
        {
            return new[] { value };
        }
        /// <summary>
        /// Changes an array by a given lambda function.
        /// <para/> Extension from <see langword="AlexejheroYTB.Utilities"/>
        /// </summary>
        /// <typeparam name="T">The type of the array</typeparam>
        /// <param name="source">The array</param>
        /// <param name="projection">The lambda function to execute on each element of the array</param>
        /// <param name="onlyChangeIf">Only change the element if this function returns true</param>
        private static void Change<T>(this IList<T> source, Func<T, T> projection, Func<T, bool> onlyChangeIf = null)
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
        /// <summary>
        /// Generates the next file path available using the path, the next <see cref="int"/> available, and the suffix
        /// </summary>
        /// <param name="path">The first path of the file</param>
        /// <param name="suffix">The suffix to add to the result</param>
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