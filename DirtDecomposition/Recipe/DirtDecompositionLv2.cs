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

    [RequiresSkill(typeof(MiningSkill), 5)]
    public partial class DirtProcessingV2Recipe : RecipeFamily
    {
        public DirtProcessingV2Recipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "DirtProcessingV2",
                displayName: Localizer.DoStr("Dirt Processing V2"),
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(DirtItem), 15, true),
                },
                items: new List<CraftingElement>
                {
                    new CraftingElement<ClayItem>(2),
                    new CraftingElement<SandItem>(7),
                    new CraftingElement<CompostItem>(1),
                }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(600, typeof(MiningSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(DirtProcessingV2Recipe),
                start: 0.1f,
                skillType: typeof(MiningSkill),
                typeof(MiningFocusedSpeedTalent),
                typeof(MiningParallelSpeedTalent)
            );
            this.Initialize(
                displayText: Localizer.DoStr("Dirt Processing V2"),
                recipeType: typeof(DirtProcessingV2Recipe)
            );
            CraftingComponent.AddRecipe(
                tableType: typeof(SensorBasedBeltSorterObject),
                recipe: this
            );
            CraftingComponent.AddRecipe(
                tableType: typeof(ScreeningMachineObject),
                recipe: this
            );
        }
    }
}
