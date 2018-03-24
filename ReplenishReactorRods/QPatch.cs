using SMLHelper.Patchers;
using System.Collections.Generic;

namespace ReplenishReactorRods
{
    public class QPatch
    {
        public static void Patch()
        {
            var techData = new TechDataHelper
            {
                _craftAmount = 1,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.DepletedReactorRod, 1),
                    new IngredientHelper(TechType.UraniniteCrystal, 3)
                },
                _techType = TechType.ReactorRod
            };
            CraftDataPatcher.customTechData.Add(TechType.ReactorRod, techData);
            CraftTreePatcher.customCraftNodes.Add("Resources/Electronics/ReactorRod", TechType.ReactorRod);
            KnownTechPatcher.unlockedAtStart.Add(TechType.ReactorRod);
        }
    }
}