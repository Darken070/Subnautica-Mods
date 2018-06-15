using AlexejheroYTB.Utilities;
using System;
using Utilites.Config;
using SMLHelper;
using SMLHelper.Patchers;
using System.Collections.Generic;

namespace Trollnautica
{
    public static class Mod
    {
        public static readonly ConfigFile Config = new ConfigFile("config");
        public static bool openDiskTray;

        public static bool corruptIcons;
        public static int iconCorruptPercentage;

        public static bool corruptNames;
        public static bool removeNames;
        public static int nameCorruptPercentage;

        public static bool corruptTooltips;
        public static bool removeTooltips;
        public static int tooltipCorruptPercentage;

        public static List<string> nameList = new List<string>()
        {
            "WHY ME?",
            "BOOP!",
            "?!",
        };

        public static List<string> tooltipList = new List<string>()
        {
            "Never gonna give you up, never gonna let you down, never gonna run around and desert you",
            "Never gonna make you cry, never gonna say goodbye, never gonna tell a lie and hurt you",
            "The answer to life, the universe, and everything = 42",
            "Hey, what happened?",
            "Rest in pepperonis",
            "Hello everybody, my name is Markiplier",
            "nexusmods.com/subnautica/mods/666",
            "QMOD ERR. Something strange happened",
            "NullReferenceException: Object reference not set to an instance of an object.",
            "WOOF",
            "Brought to you by: AlexejheroYTB",
            "Multiplayer is not out yet. It may never be out",
            "<Insert funny quote here>",
            "5% is too much. I want 0.7%",
            "Bazinga!",
            "Mr. Stark, I don't feel so good.",
            "Why did the chicken cross the road?",
            "Kappa",
            "Windows update you may need to restart your computer",
            "whomst'd've'lu'yaint'nt'ed'ies's'y'es'nt't're'ing'able'tic'ive'al'nt'ne'm'll'ble'al'ny",
            "I will build a great great wall",
            "Omae wa mou, shindeiru. NANI?",
            "That's my spot!",
            "Your Windows license will expire soon",
            "I really like what you've done with the kitchen",
            "WHERE IS THE LAMB SAUCE?",
            "If pi is 3.14, does that mean that pie is 4?",
        };

        public static void QPatch()
        {
            Config.Load();
            bool changedConfig =
                Config.TryGet(ref openDiskTray, "Open and close disk tray when game starts") |

                Config.TryGet(ref corruptIcons, "Icon-remover", "Enable icon-remover") |
                Config.TryGet(ref iconCorruptPercentage, "Icon-remover", "Percentage of icons to be removed") |

                Config.TryGet(ref corruptNames, "Name-changer", "Enable name-changer") |
                Config.TryGet(ref removeNames, "Name-changer", "Set to true to remove names instead of changing them") |
                Config.TryGet(ref nameCorruptPercentage, "Icon-remover", "Percentage of names to be changed") |

                Config.TryGet(ref corruptTooltips, "Tooltip-changer", "Enable tooltip-changer") |
                Config.TryGet(ref removeTooltips, "Tooltip-changer", "Set to true to remove tooltips instead of changing them") |
                Config.TryGet(ref tooltipCorruptPercentage, "Tooltip-changer", "Percentage of tooltips to be changed");

            Values.Clamp(ref iconCorruptPercentage, 0, 100);
            Values.Clamp(ref nameCorruptPercentage, 0, 100);
            Values.Clamp(ref tooltipCorruptPercentage, 0, 100);

            foreach (TechType item in Enum.GetValues(typeof(TechType)))
            {
                if (corruptIcons == true)
                {
                    if (iconCorruptPercentage >= Values.Random(1, 100))
                    {
                        CustomSpriteHandler.customSprites.Add(new CustomSprite(item, SpriteManager.Get(TechType.SomethingPlaceholder)));
                    }
                }
                if (corruptNames == true)
                {
                    if (nameCorruptPercentage >= Values.Random(1, 100))
                    {
                        if (removeNames == true)
                            LanguagePatcher.customLines.Add(item.ToString(), "None");
                        else
                            LanguagePatcher.customLines.Add(item.ToString(), nameList.GetRandom());
                    }
                }
                if (corruptTooltips == true)
                {
                    if (tooltipCorruptPercentage >= Values.Random(1, 100))
                    {
                        if (removeTooltips == true)
                            LanguagePatcher.customLines.Add(item.ToString() + "_Tooltip", "None");
                        else
                            LanguagePatcher.customLines.Add(item.ToString() + "_Tooltip", tooltipList.GetRandom());
                    }
                }
            }

            Misc.DiskTray.Open();
        }
    }
}
