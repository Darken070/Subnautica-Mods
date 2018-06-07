using AlexejheroYTB.Utilities;
using SMLHelper;
using SMLHelper.Patchers;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DeconstructFireExtinguishers
{

    public class QPatch
    {
        public static void Patch()
        {
            Items.Result result = Items.AddDummy
            (
                name: "DeconstructFireExtinguisherDummy",
                languageName: "Deconstruct Fire Extinguisher",
                languageTooltip: "Turn a Fire Extinguisher into 2 Titanium",
                spriteItem: TechType.Titanium,
                fabricatorNodePath: "Resources/AdvancedMaterials/DeconstructFireExtinguisherDummy",
                ingredientItems: new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.FireExtinguisher, 1)
                },
                resultingItems: new List<TechType>()
                {
                    TechType.Titanium,
                    TechType.Titanium
                }, 
                prefabPath: "WorldEntities/Natural/Titanium"
            );
        }
    }

}
