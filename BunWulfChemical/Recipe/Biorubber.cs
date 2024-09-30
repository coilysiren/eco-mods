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

    [RequiresSkill(typeof(CuttingEdgeCookingSkill), 3)]
    public partial class BiorubberRecipe : RecipeFamily
    {
        public BiorubberRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "Biorubber",
                displayName: Localizer.DoStr("Valuable Tree Rubbe"),
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CeibaLogItem), 2, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                    new IngredientElement("Fat", 10, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                },
                items: new List<CraftingElement>
                {
                    new CraftingElement<SyntheticRubberItem>(10),
                }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 5;
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(CuttingEdgeCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(BiorubberRecipe),
                start: 4,
                skillType: typeof(CuttingEdgeCookingSkill),
                typeof(CuttingEdgeCookingFocusedSpeedTalent),
                typeof(CuttingEdgeCookingParallelSpeedTalent)
            );
            this.Initialize(
                displayText: Localizer.DoStr("Valuable Tree Rubber"),
                recipeType: typeof(BiorubberRecipe)
            );
            CraftingComponent.AddRecipe(
                tableType: typeof(LaboratoryObject),
                recipe: this
            );
        }
    }
}
