﻿using SMLHelper.Patchers;

namespace MoreHullPlates.Items
{
    public partial class Load
    {
        public partial class Existing
        {
            public static void All()
            {
                // Markiplier Straight Arms Bobblehead (Existing)
                KnownTechPatcher.unlockedAtStart.Add(TechType.Marki1);
                LanguagePatcher.customLines.Add("Marki1", "Markiplier Straight Arms Bobblehead");
                LanguagePatcher.customLines.Add("Tooltip_Marki1", "Subnautica content creator. https://www.youtube.com/markiplierGAME (Item added by Subnautica)");
                CraftDataPatcher.AddToCustomGroup(TechGroup.Miscellaneous, TechCategory.Misc, TechType.Marki1);
                CraftDataPatcher.RemoveFromCustomGroup(TechGroup.Miscellaneous, TechCategory.MiscHullplates, TechType.Marki1);

                // Markiplier Bobblehead (Existing)
                KnownTechPatcher.unlockedAtStart.Add(TechType.Marki2);
                LanguagePatcher.customLines.Add("Marki2", "Markiplier Bobblehead");
                LanguagePatcher.customLines.Add("Tooltip_Marki2", "Subnautica content creator. https://www.youtube.com/markiplierGAME (Item added by Subnautica)");
                CraftDataPatcher.AddToCustomGroup(TechGroup.Miscellaneous, TechCategory.Misc, TechType.Marki2);
                CraftDataPatcher.RemoveFromCustomGroup(TechGroup.Miscellaneous, TechCategory.MiscHullplates, TechType.Marki2);

                // Jacksepticeye's Tank (Existing)
                KnownTechPatcher.unlockedAtStart.Add(TechType.JackSepticEye);
                LanguagePatcher.customLines.Add("JackSepticEye", "Jacksepticeye's Tank");
                LanguagePatcher.customLines.Add("Tooltip_JackSepticEye", "Subnautica content creator. https://www.youtube.com/jacksepticeye (Item added by Subnautica)");
                CraftDataPatcher.AddToCustomGroup(TechGroup.Miscellaneous, TechCategory.Misc, TechType.JackSepticEye);
                CraftDataPatcher.RemoveFromCustomGroup(TechGroup.Miscellaneous, TechCategory.MiscHullplates, TechType.JackSepticEye);

                // Diction's Cat (Existing)
                KnownTechPatcher.unlockedAtStart.Add(TechType.EatMyDiction);
                LanguagePatcher.customLines.Add("EatMyDiction", "Diction's Cat");
                LanguagePatcher.customLines.Add("Tooltip_EatMyDiction", "Subnautica content creator. https://www.youtube.com/user/EatMyDiction1 (Item added by Subnautica)");
                CraftDataPatcher.AddToCustomGroup(TechGroup.Miscellaneous, TechCategory.Misc, TechType.EatMyDiction);
                CraftDataPatcher.RemoveFromCustomGroup(TechGroup.Miscellaneous, TechCategory.MiscHullplates, TechType.EatMyDiction);

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

                // Muyskerm (Existing)
                KnownTechPatcher.unlockedAtStart.Add(TechType.MuyskermHullPlate);
                LanguagePatcher.customLines.Add("MuyskermHullPlate", "Muyskerm Hull Plate");
                LanguagePatcher.customLines.Add("Tooltip_MuyskermHullPlate", "Subnautica content creator. https://www.youtube.com/muyskerm (Item added by Subnautica)");

                // LordMinion777 (Existing)
                KnownTechPatcher.unlockedAtStart.Add(TechType.LordMinionHullPlate);
                LanguagePatcher.customLines.Add("LordMinionHullPlate", "LordMinion777 Hull Plate");
                LanguagePatcher.customLines.Add("Tooltip_LordMinionHullPlate", "Former Subnautica content creator. https://www.youtube.com/LordMinion777 (Item added by Subnautica)");

                // Jacksepticeye (Existing)
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
            }
        }
    }
}