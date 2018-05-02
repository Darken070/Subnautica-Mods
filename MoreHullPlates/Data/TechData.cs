using SMLHelper.Patchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoreHullPlates
{
    public class TechData
    {
        public static TechDataHelper Get = new TechDataHelper
        {
            _craftAmount = 1,
            _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.Titanium, 1),
                    new IngredientHelper(TechType.Glass, 1)
                }
        };
    }
}
