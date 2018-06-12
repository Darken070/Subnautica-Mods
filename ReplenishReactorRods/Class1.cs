using SMLHelper.Patchers;
using AlexejheroYTB.Utilities;
using System.Collections.Generic;

namespace ReplenishReactorRods
{
    public class QPatch
    {
        public void Patch()
        {
            Items.AddDummy
            (
                name: "RReactorRod",
                languageName: "Replenish Reactor Rod",
                languageTooltip: "Combine a depleted reactor rod with 3 uranium to replenish it!",
                spriteItem: TechType.DepletedReactorRod,
                fabricatorNodePath: "Resources/AdvancedMaterials/RReactorRod",
                ingredientItems: new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.DepletedReactorRod, 1),
                    new IngredientHelper(TechType.Uranium, 3)
                },
                resultingItems: TechType.ReactorRod,
                prefabPath: "WorldEntities/Natural/ReactorRod"
            );
        }
    }
}
