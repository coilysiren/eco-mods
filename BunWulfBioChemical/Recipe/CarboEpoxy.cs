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
    using Eco.Gameplay.DynamicValues;

    [RequiresSkill(typeof(CuttingEdgeCookingSkill), 1)]
    public partial class CarboEpoxyRecipe : RecipeFamily
    {
        public CarboEpoxyRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "CarboEpoxy",
                displayName: Localizer.DoStr("Coal Fat Epoxy"),
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement("Coal", 4, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                    new IngredientElement("Fat", 10, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                },
                items: new List<CraftingElement>
                {
                    new CraftingElement<EpoxyItem>(2),
                }
            );
            var baseRecipe = new EpoxyRecipe();
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = baseRecipe.ExperienceOnCraft;
            this.LaborInCalories = CreateLaborInCaloriesValue(baseRecipe.LaborInCalories.GetBaseValue / 4, typeof(CuttingEdgeCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(CarboEpoxyRecipe),
                start: baseRecipe.CraftMinutes.GetBaseValue * 2,
                skillType: typeof(CuttingEdgeCookingSkill),
                typeof(CuttingEdgeCookingFocusedSpeedTalent),
                typeof(CuttingEdgeCookingParallelSpeedTalent)
            );
            this.Initialize(
                displayText: Localizer.DoStr("Coal Fat Epoxy"),
                recipeType: typeof(CarboEpoxyRecipe)
            );
            CraftingComponent.AddRecipe(
                tableType: typeof(LaboratoryObject),
                recipe: this
            );
        }
    }
}
