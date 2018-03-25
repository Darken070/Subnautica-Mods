using SMLHelper;
using SMLHelper.Patchers;
using System.Collections.Generic;

namespace ReplenishReactorRods
{
    public class QPatch
    {
        public static void Patch()
        {
            var RRR = TechTypePatcher.AddTechType("RRR", "Replenished Reactor Rod", "Used to power nuclear reactors. Cannot be replenished. Added by ReplenishReactorRods mod");
            var URR = TechTypePatcher.AddTechType("URR", "Unreplenishable Reactor Rod", "Good for throwing away. Added by ReplenishReactorRods mod");
            var RRRcraft = new TechDataHelper
            {
                _craftAmount = 1,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.DepletedReactorRod, 1),
                    new IngredientHelper(TechType.UraniniteCrystal, 3)
                },
                _techType = RRR
            };
            var RRRsprite = SpriteManager.Get(TechType.ReactorRod);
            var URRsprite = SpriteManager.Get(TechType.DepletedReactorRod);
            CustomSpriteHandler.customSprites.Add(new CustomSprite(RRR, RRRsprite));
            CustomSpriteHandler.customSprites.Add(new CustomSprite(URR, URRsprite));
            CraftDataPatcher.customTechData.Add(RRR, RRRcraft);
            CraftTreePatcher.customCraftNodes.Add("AlexejheroYTB's Mods/ReplenishReactorRods/RRR", RRR);
        }
    }
}