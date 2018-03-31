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
                    TechType.Titanium
                },
                _techType = TechType.Lithium
            };
            CraftDataPatcher.customTechData.Add(TechType.Lithium, techData);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.Lithium, CraftScheme.Fabricator, "Resources/BasicResources"));
            KnownTechPatcher.unlockedAtStart.Add(TechType.Lithium);
        }
    }
}
