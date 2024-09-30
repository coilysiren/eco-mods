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

    [RequiresSkill(typeof(MiningSkill), 3)]
    public partial class DirtProcessingV1Recipe : RecipeFamily
    {
        public DirtProcessingV1Recipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "DirtProcessingV1",
                displayName: Localizer.DoStr("Dirt Processing V1"),
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(DirtItem), 20, true),
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
            this.LaborInCalories = CreateLaborInCaloriesValue(400, typeof(MiningSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(DirtProcessingV1Recipe),
                start: 0.1f,
                skillType: typeof(MiningSkill)
            );
            this.Initialize(
                displayText: Localizer.DoStr("Dirt Processing V1"),
                recipeType: typeof(DirtProcessingV1Recipe)
            );
            CraftingComponent.AddRecipe(
                tableType: typeof(ScreeningMachineObject),
                recipe: this
            );
            CraftingComponent.AddRecipe(
                tableType: typeof(RockerBoxObject),
                recipe: this
            );
        }
    }
}
