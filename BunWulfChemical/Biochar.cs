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
    [RequiresSkill(typeof(FarmingSkill), 4)]
    public partial class BiocharRecipe : RecipeFamily
    {
        public BiocharRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Biochar",
                    Localizer.DoStr("Biochar"),
                    new IngredientElement[]
                    {
                        new IngredientElement("Coal", 4, true),
                        new IngredientElement("Crop", 10, typeof(FarmingSkill), typeof(FarmingLavishResourcesTalent)),
                    },
                    new CraftingElement[] {
                        new CraftingElement<CharcoalItem>(5),
                        new CraftingElement<OilItem>(typeof(FarmingSkill), 2, typeof(FarmingLavishResourcesTalent)),
                    }
                )
            };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(10, typeof(FarmingSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                typeof(BiocharRecipe),
                0.2f,
                typeof(FarmingSkill),
                typeof(FarmingFocusedSpeedTalent)
            );
            this.Initialize(Localizer.DoStr("Biochar"), typeof(BiocharRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }
}
