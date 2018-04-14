using SMLHelper;
using SMLHelper.Patchers;
using System.Collections.Generic;

namespace ReplenishReactorRods
{
    public class QPatch
    {
        public static void Patch()
        {
            var techType = TechTypePatcher.AddTechType("RRRdummy", "Replenish Reactor Rod", "Allows you to craft a reactor rod from a depleted reactor rod and 3 uraninite crystals");
            var techData = new TechDataHelper
            {
                _craftAmount = 0,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.DepletedReactorRod, 1),
                    new IngredientHelper(TechType.UraniniteCrystal, 3)
                },
                _linkedItems = new List<TechType>()
                {
                    TechType.ReactorRod
                },
                _techType = techType
            };
            var sprite = SpriteManager.Get(TechType.DepletedReactorRod);
            CustomSpriteHandler.customSprites.Add(new CustomSprite(techType, sprite));
            CraftDataPatcher.customTechData.Add(techType, techData);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techType, CraftScheme.Fabricator, "Resources/Electronics"));
        }
    }
}