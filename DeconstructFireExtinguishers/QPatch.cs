using AlexejheroYTB.Utilities;
using SMLHelper;
using SMLHelper.Patchers;
using System;
using System.Collections.Generic;

namespace DeconstructFireExtinguishers
{

    public class QPatch
    {
        public static void Patch()
        {
            /*Items.AddDummy
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
                }
                );*/

            string name = "DeconstructFireExtinguisherDummy";
            string languageName = "Deconstruct Fire Extinguisher";
            string languageTooltip= "Turn a Fire Extinguisher into 2 Titanium";
            TechType spriteItem= TechType.Titanium;
            string fabricatorNodePath= "Resources/AdvancedMaterials/DeconstructFireExtinguisherDummy";
            List<IngredientHelper> ingredientItems= new List<IngredientHelper>()
            {
                new IngredientHelper(TechType.FireExtinguisher, 1)
            };
            List<TechType> resultingItems = new List<TechType>()
            {
                TechType.Titanium,
                TechType.Titanium
            };

            TechType techType = TechTypePatcher.AddTechType(name, languageName, languageTooltip);
            Atlas.Sprite sprite = SpriteManager.Get(spriteItem);
            CustomSprite customSprite = new CustomSprite(techType, sprite);
            CustomCraftNode customCraftNode = new CustomCraftNode(techType, CraftScheme.Fabricator, fabricatorNodePath);
            TechDataHelper techData = new TechDataHelper()
            {
                _craftAmount = 0,
                _ingredients = ingredientItems,
                _linkedItems = resultingItems,
                _techType = techType
            };

            CustomSpriteHandler.customSprites.Add(customSprite);
            CraftDataPatcher.customTechData.Add(techType, techData);
            CraftTreePatcher.customNodes.Add(customCraftNode);

        }
    }

}
