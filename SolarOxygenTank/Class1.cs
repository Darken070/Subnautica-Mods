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

namespace SolarOxygenTank
{
    public static class Mod
    {
        public static TechType tank;

        public static void Patch()
        {
            // Add the techtype
            tank = TechTypeHandler.AddTechType("SolarOxygenTank", "Solar-powered Oxygen Tank", "An solar-powered oxygen tank which replenishes in the daylight!");
            // Add a recipe
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
        [JsonIgnore]
        public static float OxygenCapacity;
        [JsonProperty]
        public float Oxygen_Capacity { get => OxygenCapacity; set => OxygenCapacity = value; }
        [JsonIgnore]
        public static float RechargeMultiplier;
        [JsonProperty]
        public float Recharge_Multiplier { get => RechargeMultiplier; set => RechargeMultiplier = value; }
        [JsonIgnore]
        public static float MaxDepth;
        [JsonProperty]
        public float Max_Depth { get => MaxDepth; set => MaxDepth = value; }
        [JsonIgnore]
        public static bool EasyCraft;
        [JsonProperty]
        public bool Easy_Craft { get => EasyCraft; set => EasyCraft = value; }

        [JsonIgnore]
        private static string FilePath = "./QMods/SolarOxygenTank/cfg.json";

        public override void BuildModOptions()
        {
            AddSliderOption("solaro2cap", "Oxygen Capacity", 0f, 200f, 40f);
            AddSliderOption("solaro2rm", "Recharge Multiplier", 1f, 100f, 30f);
            AddSliderOption("solaro2max", "Max Depth", 10f, 500f, 200f);
            AddToggleOption("solaro2easy", "Easy Craft", false);
        }

        public Options() : base("Solar Oxygen Tank")
        {
            string config;
            string defaultCfg = JsonConvert.SerializeObject(new Options());
            try
            {
                if (!File.Exists(FilePath))
                {
                    File.WriteAllText(FilePath, defaultCfg);
                    config = defaultCfg;
                }
                else
                {
                    config = File.ReadAllText(FilePath);
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
            Options options = JsonConvert.DeserializeObject<Options>(config);
            Oxygen_Capacity = options.Oxygen_Capacity;
            Easy_Craft = options.Easy_Craft;
            Recharge_Multiplier = options.Recharge_Multiplier;
            ToggleChanged += OnToggleChange;
            SliderChanged += OnSliderChange;
        }

        private void OnSliderChange(object sender, SliderChangedEventArgs e)
        {
            if (e.Id == "solaro2cap")
            {
                Oxygen_Capacity = e.Value;
                SerializeThis();
            }
            else if (e.Id == "solaro2rm")
            {
                Recharge_Multiplier = e.Value;
                SerializeThis();
            }
            else if (e.Id == "solaro2max")
            {
                Max_Depth = e.Value;
                SerializeThis();
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
                SerializeThis();
            }
        }

        public void SerializeThis()
        {
            try
            {
                File.WriteAllText(FilePath, JsonConvert.SerializeObject(this));
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
                // If the player is wearing the solar-powered oxygen tank
                // and he's in the ocean
                if (Inventory.main.equipment.GetTechTypeInSlot("tank") == Mod.tank && Ocean.main.GetDepthOf(Player.main.gameObject) != 0)
                {
                    // Calculate recharge amount
                    float o2 = Mathf.Clamp(GetRechargeScalar() * DayNightCycle.main.deltaTime * 1.25f, 0f, MaxRecharge);
                    // Give oxygen to player
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
