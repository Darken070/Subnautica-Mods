using SMLHelper;
using SMLHelper.Patchers;
using System.Collections.Generic;

namespace ReplenishReactorRods
{
    public class QPatch
    {
        public static void Patch()
        {
            var techType = TechTypePatcher.AddTechType("RRR", "Replenished Reactor Rod", "Used to power nuclear reactors. Cannot be replenished. Added by ReplenishReactorRods mod");
            var techData = new TechDataHelper
            {
                _craftAmount = 1,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.DepletedReactorRod, 1),
                    new IngredientHelper(TechType.UraniniteCrystal, 3)
                },
                _techType = techType
            };
            var sprite = SpriteManager.Get(TechType.ReactorRod);
            CraftDataPatcher.customTechData.Add(techType, techData);
            CraftTreePatcher.customCraftNodes.Add("Resources/Electronics/RRR", techType);
        }
    }
}