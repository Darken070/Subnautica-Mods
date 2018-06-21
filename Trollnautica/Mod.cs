using AlexejheroYTB.Utilities;
using System;
using Utilites.Config;
using Harmony;
using SMLHelper.Patchers;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using AlexejheroYTB.Utilities.Extensions;

namespace Trollnautica
{
    public static class Mod
    {
        public static readonly ConfigFile Config = new ConfigFile("config");

        public static bool openDiskTray = true;

        public static bool corruptTooltips = true;
        public static int tooltipCorruptPercentage = 10;

        public static bool baseEnterFEM = true;
        public static bool cyclopsEnterFEM = true;
        public static bool lifepodEnterFEM = true;
        public static bool prawnEnterFEM = true;
        public static bool seamothEnterFEM = true;

        public static float freezeTime = 1.2f;
        public static bool baseEnterFreeze = true;
        public static bool cyclopsEnterFreeze = true;
        public static bool lifepodEnterFreeze = true;
        public static bool prawnEnterFreeze = true;
        public static bool seamothEnterFreeze = true;

        public enum d
        {
            [Obsolete("", true)]
            x = 1
        }

        public static List<string> tooltipList = new List<string>()
        {
            "WHY ME?",
            "BOOP!",
            "?!",
            "WOOF",
            "Kappa",
            "Bazinga!",
            "( ͡° ͜ʖ ͡°)",
            "Never gonna give you up, never gonna let you down, never gonna run around and desert you",
            "Never gonna make you cry, never gonna say goodbye, never gonna tell a lie and hurt you",
            "The answer to life, the universe, and everything",
            "Hey, what happened?",
            "Rest in pepperonis",
            "Hello everybody, my name is Markiplier",
            "QMOD ERR. Something strange happened",
            "NullReferenceException: Object reference not set to an instance of an object.",
            "Brought to you by: AlexejheroYTB",
            "Multiplayer is not out yet. It may never be out",
            "<Insert funny quote here>",
            "5% is too much. I want 0.7%",
            "Mr. Stark, I don't feel so good.",
            "Why did the chicken cross the road?",
            "Windows update needs to restart your computer",
            "whomst'd've'lu'yaint'nt'ed'ies's'y'es'nt't're'ing'able'tic'ive'al'nt'ne'm'll'ble'al'ny",
            "I will build a wall. A great great wall",
            "Omae wa mou, shindeiru. NANI?",
            "That's my spot!",
            "Your Windows license will expire soon",
            "I really like what you've done with the kitchen",
            "WHERE IS THE LAMB SAUCE?",
            "If pi is 3.14, does that mean that pie is 4?",
            "IT'S A TRAP!",
        };

        public static void QPatch()
        {
            Config.Load();
            bool changedConfig =

                Config.TryGet(ref openDiskTray, ".Open and close disk tray when game starts") |

                Config.TryGet(ref corruptTooltips, ".Tooltip-changer", "Enable tooltip-changer") |
                Config.TryGet(ref tooltipCorruptPercentage, ".Tooltip-changer", "Percentage of tooltips to be changed") |

                Config.TryGet(ref baseEnterFEM, "Fake error messages", "Enable f.e.m. when entering base") |
                Config.TryGet(ref cyclopsEnterFEM, "Fake error messages", "Enable f.e.m. when entering cyclops") |
                Config.TryGet(ref lifepodEnterFEM, "Fake error messages", "Enable f.e.m. when entering life pod") |
                Config.TryGet(ref prawnEnterFEM, "Fake error messages", "Enable f.e.m. when entering prawn suit") |
                Config.TryGet(ref seamothEnterFEM, "Fake error messages", "Enable f.e.m. when entering seamoth") |

                Config.TryGet(ref freezeTime, "Freeze", "Freeze time") |
                Config.TryGet(ref baseEnterFreeze, "Freeze", "Freeze when entering base") |
                Config.TryGet(ref cyclopsEnterFreeze, "Freeze", "Freeze when entering cyclops") |
                Config.TryGet(ref lifepodEnterFreeze, "Freeze", "Freeze when entering life pod") |
                Config.TryGet(ref prawnEnterFreeze, "Freeze", "Freeze when entering prawn suit") |
                Config.TryGet(ref seamothEnterFreeze, "Freeze", "Freeze when entering seamoth");

            if (changedConfig)
                Config.Save();

            Values.Clamp(ref tooltipCorruptPercentage, 0, 100);
            Values.Clamp(ref freezeTime, 0, 5);

            foreach (TechType item in Enum.GetValues(typeof(TechType)))
            {
                if (corruptTooltips == true)
                {
                    if (tooltipCorruptPercentage >= Values.Random(1, 100))
                    {
                        LanguagePatcher.customLines.Add("Tooltip_" + item.ToString(), tooltipList.GetRandom());
                    }
                }
            }

            HarmonyUtils.PatchAll();

            if (openDiskTray)
            {
                Misc.DiskTray.Open();
                Misc.Wait(2);
                Misc.DiskTray.Close();
            }
        }
    }

    [HarmonyPatch(typeof(SubRoot))]
    [HarmonyPatch("OnPlayerEntered")]
    public static class SubRoot_OnPlayerEntered
    {
        [HarmonyPostfix]
        [HarmonyPriority(int.MinValue)]
        public static void Postfix(SubRoot __instance)
        {
            if (__instance == null)
            {
                ErrorMessage.AddDebug("Instance is null");
                return;
            }
            if (__instance.isBase)
            {
                if (Mod.baseEnterFreeze)
                {
                    if (Mod.freezeTime > 0f)
                    {
                        float timeScale = Time.timeScale;
                        Time.timeScale = 0;
                        Misc.Wait(Mod.freezeTime);
                        Time.timeScale = timeScale;
                    }
                }
                if (Mod.baseEnterFEM)
                {
                    ErrorMessage.AddError("System.NotFoundException thrown: Could not load habitat class. Please restart Subnautica");
                    ErrorMessage.AddError("at SubRoot.OnPlayerEntered(Player), " +
                        "at UnityEngine.GameObject, " +
                        "at UnityEngine.MonoBehaviour, " +
                        "at System.NotFoundException, " +
                        "at System.Exception. " +
                        "DEBUG: " + Values.Random());
                }
            }
            else if (__instance.isCyclops)
            {
                if (Mod.cyclopsEnterFreeze)
                {
                    if (Mod.freezeTime > 0f)
                    {
                        float timeScale = Time.timeScale;
                        Time.timeScale = 0;
                        Misc.Wait(Mod.freezeTime);
                        Time.timeScale = timeScale;
                    }
                }
                if (Mod.cyclopsEnterFEM)
                {
                    ErrorMessage.AddError("System.NotFoundException thrown: Could not load habitat class. Please restart Subnautica");
                    ErrorMessage.AddError("at SubRoot.OnPlayerEntered(Player), " +
                        "at UnityEngine.GameObject, " +
                        "at UnityEngine.MonoBehaviour, " +
                        "at System.NotFoundException, " +
                        "at System.Exception. " +
                        "DEBUG: " + Values.Random());
                }
            }
            else
            {
                ErrorMessage.AddDebug("Neither cyclops nor base entered");
            }
        }
    }

    [HarmonyPatch(typeof(Vehicle))]
    [HarmonyPatch("EnterVehicle")]
    public static class Vehicle_EnterVehicle
    {
        [HarmonyPostfix]
        [HarmonyPriority(int.MinValue)]
        public static void Postfix(Vehicle __instance)
        {
            if (__instance == null)
            {
                ErrorMessage.AddDebug("Instance is null");
                return;
            }
            if (__instance.GetType().Equals(typeof(SeaMoth)))
            {
                if (Mod.seamothEnterFreeze)
                {
                    if (Mod.freezeTime > 0f)
                    {
                        float timeScale = Time.timeScale;
                        Time.timeScale = 0;
                        Misc.Wait(Mod.freezeTime);
                        Time.timeScale = timeScale;
                    }
                }
                if (Mod.seamothEnterFEM)
                {
                    ErrorMessage.AddError("System.NotFoundException thrown: Could not load seamoth class. Please restart Subnautica");
                    ErrorMessage.AddError("at Vehicle.EnterVehicle(Player, bool, bool), " +
                        "at UnityEngine.GameObject, " +
                        "at UnityEngine.MonoBehaviour, " +
                        "at System.NotFoundException, " +
                        "at System.Exception. " +
                        "DEBUG: " + Values.Random());
                }
            }
            else if (__instance.GetType().Equals(typeof(Exosuit)))
            {
                if (Mod.prawnEnterFreeze)
                {
                    if (Mod.freezeTime > 0f)
                    {
                        float timeScale = Time.timeScale;
                        Time.timeScale = 0;
                        Misc.Wait(Mod.freezeTime);
                        Time.timeScale = timeScale;
                    }
                }
                if (Mod.prawnEnterFreeze)
                {
                    ErrorMessage.AddError("System.NotFoundException thrown: Could not load prawn suit class. Please restart Subnautica");
                    ErrorMessage.AddError("at Vehicle.EnterVehicle(Player, bool, bool), " +
                        "at UnityEngine.GameObject, " +
                        "at UnityEngine.MonoBehaviour, " +
                        "at System.NotFoundException, " +
                        "at System.Exception. " +
                        "DEBUG: " + Values.Random());
                }
            }
            else
            {
                ErrorMessage.AddDebug("Neither seamoth nor prawnsuit entered");
            }
        }
    }

    [HarmonyPatch(typeof(EnterExitHelper))]
    [HarmonyPatch("Enter")]
    public static class EnterExitHelper_Enter
    {
        [HarmonyPostfix]
        [HarmonyPriority(int.MinValue)]
        public static void Postfix(EnterExitHelper __instance, bool isForEscapePod)
        {
            if (__instance == null)
            {
                ErrorMessage.AddDebug("Instance is null");
                return;
            }
            if (isForEscapePod)
            {
                if (Mod.lifepodEnterFreeze)
                {
                    if (Mod.freezeTime > 0f)
                    {
                        float timeScale = Time.timeScale;
                        Time.timeScale = 0;
                        Misc.Wait(Mod.freezeTime);
                        Time.timeScale = timeScale;
                    }
                }
                if (Mod.lifepodEnterFEM)
                {
                    ErrorMessage.AddError("System.NotFoundException thrown: Could not load lifepod class. Please restart Subnautica");
                    ErrorMessage.AddError("at EscapePod.bottomHatchUsed(Player, bool, bool), " +
                        "at UnityEngine.GameObject, " +
                        "at UnityEngine.MonoBehaviour, " +
                        "at System.NotFoundException, " +
                        "at System.Exception. " +
                        "DEBUG: " + Values.Random());
                }
            }
        }
    }
}
