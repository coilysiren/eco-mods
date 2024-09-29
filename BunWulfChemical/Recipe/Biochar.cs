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

    [RequiresSkill(typeof(FarmingSkill), 4)]
    public partial class BiocharRecipe : RecipeFamily
    {
        public BiocharRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "Biochar",
                displayName: Localizer.DoStr("Biochar"),
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CharcoalItem), 4, typeof(FarmingSkill)),
                    new IngredientElement("Crop", 10, typeof(FarmingSkill), typeof(FarmingLavishResourcesTalent)),
                },
                items: new List<CraftingElement>
                {
                    new CraftingElement<CharcoalItem>(5),
                    new CraftingElement<OilItem>(2),
                }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(25, typeof(FarmingSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(BiocharRecipe),
                start: 0.2f,
                skillType: typeof(FarmingSkill)
                typeof(FarmingFocusedSpeedTalent)
                typeof(FarmingParallelSpeedTalent)
            );
            this.ModsPreInitialize();
            this.Initialize(
                displayText: Localizer.DoStr("Biochar"),
                recipeType: typeof(BiocharRecipe),
            );
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(
                tableType: typeof(BakeryOvenObject),
                recipe: this,
            );
            CraftingComponent.AddRecipe(
                tableType: typeof(KilnObject),
                recipe: this,
            );
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }
}
