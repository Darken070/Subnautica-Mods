using Harmony;
using Oculus.Newtonsoft.Json;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
using WindowsInput;
using WindowsInput.Native;

namespace SolarOxygenTank
{
    public static class Mod
    {
        public static TechType tank;

        public static void Patch()
        {
            // Add the techtype
            tank = TechTypeHandler.AddTechType("SolarOxygenTank", "Solar-powered Oxygen Tank", "An solar-powered oxygen tank which replenishes in the daylight!");
            // Apply prefab
            PrefabHandler.RegisterPrefab(new TankPrefab());
            // Add recipe
            CraftDataHandler.SetTechData(tank, new TechData()
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>()
                {
                    new Ingredient(TechType.AdvancedWiringKit, 1),
                    new Ingredient(TechType.EnameledGlass, 1),
                    new Ingredient(TechType.Copper, 2),
                    new Ingredient(TechType.Quartz, 2),
                    new Ingredient(TechType.Pipe, 3),
                    new Ingredient(TechType.PlasteelTank, 1),
                }
            });
            // Add it to the crafting tree
            CraftTreeHandler.AddCraftingNode(CraftTree.Type.Fabricator, tank, "Personal", "Equipment");
            // Make the background purple
            CraftDataHandler.SetBackgroundType(tank, CraftData.BackgroundType.ExosuitArm);
            // Double it's crafting time
            CraftDataHandler.SetCraftingTime(tank, 6f);
            // Make it equipable in the tank slot
            CraftDataHandler.SetEquipmentType(tank, EquipmentType.Tank);
            // Make it take a lot of inventory space
            CraftDataHandler.SetItemSize(tank, 3, 3);
            // Start patching
            HarmonyInstance.Create("alexejheroytb.subnauticamods.solaroxygentank").PatchAll(Assembly.GetExecutingAssembly());
        }

        public class TankPrefab : ModPrefab
        {
            public override GameObject GetGameObject()
            {
                GameObject prefab = Resources.Load<GameObject>("WorldEntities/Tools/PlasteelTank");
                GameObject obj = GameObject.Instantiate(prefab);

                obj.GetComponent<Oxygen>().oxygenCapacity = Options.OxygenCapacity;

                return obj;
            }

            public TankPrefab() : base("SolarOxygenTank", "SolarOxygenTankPrefab", tank) { }
        }
    }

    public class Options : ModOptions
    {
        public static float OxygenCapacity;
        public float Oxygen_Capacity { get => OxygenCapacity; set => OxygenCapacity = value; }
        public static float RechargeMultiplier;
        public float Recharge_Multiplier { get => RechargeMultiplier; set => RechargeMultiplier = value; }
        public static float MaxDepth;
        public float Max_Depth { get => MaxDepth; set => MaxDepth = value; }
        public static bool EasyCraft;
        public bool Easy_Craft { get => EasyCraft; set => EasyCraft = value; }
        public static bool Reset;

        private static string FilePath = "./QMods/SolarOxygenTank/cfg.json";

        public override void BuildModOptions()
        {
            AddSliderOption("solaro2cap", "Oxygen Capacity", 0f, 200f, 40f);
            AddSliderOption("solaro2rm", "Recharge Multiplier", 1f, 100f, 30f);
            AddSliderOption("solaro2max", "Max Depth", 10f, 500f, 200f);
            AddToggleOption("solaro2easy", "Easy Craft", false);
            AddToggleOption("solaro2reset", "Reset to default", false);
        }

        public Options() : base("Solar Oxygen Tank")
        {
            Options options = ReadFile();
            ChangeOptions(options);

            ToggleChanged += OnToggleChange;
            SliderChanged += OnSliderChange;
        }

        private void OnSliderChange(object sender, SliderChangedEventArgs e)
        {
            if (e.Id == "solaro2cap")
            {
                Oxygen_Capacity = e.Value;
                WriteToFile();
            }
            else if (e.Id == "solaro2rm")
            {
                Recharge_Multiplier = e.Value;
                WriteToFile();
            }
            else if (e.Id == "solaro2max")
            {
                Max_Depth = e.Value;
                WriteToFile();
            }
        }
        private void OnToggleChange(object sender, ToggleChangedEventArgs e)
        {
            if (e.Id == "solaro2easy")
            {
                if (e.Value == false)
                {
                    CraftDataHandler.SetTechData(Mod.tank, new TechData()
                    {
                        craftAmount = 1,
                        Ingredients = new List<Ingredient>()
                        {
                            new Ingredient(TechType.AdvancedWiringKit, 1),
                            new Ingredient(TechType.EnameledGlass, 1),
                            new Ingredient(TechType.Copper, 2),
                            new Ingredient(TechType.Quartz, 2),
                            new Ingredient(TechType.Pipe, 3),
                            new Ingredient(TechType.PlasteelTank, 1),
                        }
                    });
                }
                else
                {
                    CraftDataHandler.SetTechData(Mod.tank, new TechData()
                    {
                        craftAmount = 1,
                        Ingredients = new List<Ingredient>()
                        {
                            new Ingredient(TechType.WiringKit, 1),
                            new Ingredient(TechType.Copper, 2),
                            new Ingredient(TechType.Quartz, 2),
                            new Ingredient(TechType.HighCapacityTank, 1),
                        }
                    });
                }
                Easy_Craft = e.Value;
                WriteToFile();
            }
            else if (e.Id == "solaro2reset")
            {
                if (e.Value == true)
                {
                    ResetOptions();
                }
            }
        }

        public void ChangeOptions(Options options = null)
        {
            if (options == null)
                options = new Options();

            Oxygen_Capacity = options.Oxygen_Capacity;
            Max_Depth = options.Max_Depth;
            Recharge_Multiplier = options.Recharge_Multiplier;
            Easy_Craft = options.Easy_Craft;
            Reset = false;
        }
        
        public void WriteToFile(Options options = null)
        {
            if (options == null)
                options = this;
            try
            {
                File.WriteAllText(FilePath, JsonConvert.SerializeObject(options));
            }
            catch (IOException)
            {
                Console.WriteLine("[SolarOxygenTank] Could not write to config file!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[SolarOxygenTank] " + ex.Message);
                Console.WriteLine("[SolarOxygenTank] " + ex.StackTrace);
            }

        }
        public Options ReadFile(string filePath = null)
        {
            if (filePath == null)
                filePath = FilePath;
            string config;
            string defaultCfg = JsonConvert.SerializeObject(new Options());
            try
            {
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, defaultCfg);
                    config = defaultCfg;
                }
                else
                {
                    config = File.ReadAllText(filePath);
                }
            }
            catch (IOException)
            {
                Console.WriteLine("[SolarOxygenTank] Could not load config file! Resetting to default values...");
                config = defaultCfg;
            }
            catch (Exception e)
            {
                Console.WriteLine("[SolarOxygenTank] " + e.Message);
                Console.WriteLine("[SolarOxygenTank] " + e.StackTrace);
                config = defaultCfg;
            }
            return JsonConvert.DeserializeObject<Options>(config);
        }
        public void ResetOptions(Options options = null)
        {
            if (options == null)
                options = new Options();
            WriteToFile(options);
            ChangeOptions(options);
            new InputSimulator().Keyboard.KeyPress(VirtualKeyCode.ESCAPE);
        }
    }

    public static class Patches
    {
        [HarmonyPatch(typeof(Player))]
        [HarmonyPatch("Update")]
        public static class Player_Update
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                if (Inventory.main.equipment.GetTechTypeInSlot("tank") == Mod.tank && Ocean.main.GetDepthOf(Player.main.gameObject) != 0)
                {
                    float o2 = Mathf.Clamp(GetRechargeScalar() * DayNightCycle.main.deltaTime * 1.25f, 0f, MaxRecharge);
                    Player.main.oxygenMgr.AddOxygen(o2);
                }
            }

            public static float MaxDepth = 200f;
            public static float RechargeFactor = 0.001f * Options.RechargeMultiplier;
            public static float MaxRecharge = Player.main.GetOxygenCapacity() - Player.main.GetOxygenAvailable();

            public static float GetRechargeScalar()
            {
                float proximityToSurface = Mathf.Clamp01((MaxDepth + Ocean.main.GetDepthOf(Player.main.gameObject)) / MaxDepth);
                float localLightScalar = DayNightCycle.main.GetLocalLightScalar();
                
                return RechargeFactor * localLightScalar * proximityToSurface;
            }
        }
    }
}
