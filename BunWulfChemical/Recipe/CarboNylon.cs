namespace Eco.Mods.TechTree
{

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
    using Eco.Gameplay.Items.Recipes;

    [RequiresSkill(typeof(CuttingEdgeCookingSkill), 1)]
    public partial class CarboNylonRecipe : RecipeFamily
    {
        public CarboNylonRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "CarboNylon",
                displayName: Localizer.DoStr("Coal Based Nylon"),
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement("Coal", 10, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                },
                items: new List<CraftingElement>
                {
                    new CraftingElement<NylonItem>(8),
                }
            );
            this.Recipes = new List<Recipe> { recipe };
            // Same as Oil Drilling
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(180, typeof(CuttingEdgeCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(CarboNylonRecipe),
                start: 1.5f,
                skillType: typeof(CuttingEdgeCookingSkill),
                typeof(CuttingEdgeCookingFocusedSpeedTalent),
                typeof(CuttingEdgeCookingParallelSpeedTalent)
            );
            this.Initialize(
                displayText: Localizer.DoStr("Coal Based Nylon"),
                recipeType: typeof(CarboNylonRecipe)
            );
            CraftingComponent.AddRecipe(
                tableType: typeof(LaboratoryObject),
                recipe: this
            );
        }
    }
}
