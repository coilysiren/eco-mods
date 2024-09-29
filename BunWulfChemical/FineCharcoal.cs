using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Core.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.World;
using Eco.World.Blocks;
using Eco.Gameplay.Pipes;

namespace Eco.Mods.TechTree
{
    [RequiresSkill(typeof(LoggingSkill), 4)]
    public partial class FineCharcoalRecipe : RecipeFamily
    {
        public FineCharcoalRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "FineCharcoal",
                    Localizer.DoStr("Fine Charcoal"),
                    new IngredientElement[]
                    {
                        new IngredientElement("HewnLog", 7, typeof(LoggingSkill)),
                    },
                    new CraftingElement[] { new CraftingElement<CharcoalItem>(1) }
                )
            };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(25, typeof(LoggingSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                typeof(FineCharcoalRecipe),
                1,
                typeof(LoggingSkill)
            );
            this.Initialize(Localizer.DoStr("Fine Charcoal"), typeof(FineCharcoalRecipe));
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }
}
