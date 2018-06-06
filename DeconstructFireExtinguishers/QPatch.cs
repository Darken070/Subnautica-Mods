using AlexejheroYTB.Utilities;
using SMLHelper.Patchers;
using System.Collections.Generic;

namespace DeconstructFireExtinguishers
{

    public class QPatch
    {
        public void Patch()
        {
            Items.AddDummy
                (
                name: "DeconstructFireExtinguisherDummy",
                languageName: "Deconstruct Fire Extinguisher",
                languageTooltip: "Turn a Fire Extinguisher into 2 Titanium",
                spriteItem: TechType.Titanium,
                fabricatorNodePath: "",
                ingredientItems: new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.FireExtinguisher, 1)
                },
                resultingItems: new List<TechType>()
                {
                    TechType.Titanium,
                    TechType.Titanium
                }
                );
        }
    }

}
