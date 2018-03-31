using SMLHelper.Patchers;
using System.Collections.Generic;

namespace UnpackPlasteelIngots
{
    public class QPatch
    {
        public static void Patch()
        {
            var techData = new TechDataHelper
            {
                _craftAmount = 2,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.PlasteelIngot, 1)
                },
                _linkedItems = new List<TechType>()
                {
                    TechType.TitaniumIngot
                },
                _techType = TechType.TitaniumIngot
            };

            CraftDataPatcher.customTechData.Add(TechType.Lithium, techData);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.Lithium, CraftScheme.Fabricator, "Resources/AdvancedMaterials/Replenish"));
            CraftTreePatcher.customTabs.Add(new CustomCraftTab("Resources/AdvancedMaterials/Replenish", "ReplenishReactorRods", CraftScheme.Fabricator, sprite));
            KnownTechPatcher.unlockedAtStart.Add(TechType.Lithium);
        }
    }
}
