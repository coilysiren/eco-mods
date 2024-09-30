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

    [RequiresSkill(typeof(CuttingEdgeCookingSkill), 2)]
    public partial class BiofuelRecipe : RecipeFamily
    {
        public BiofuelRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "Biofuel",
                displayName: Localizer.DoStr("Plastic Container Biofuel"),
                ingredients: new List<IngredientElement>
                {
                    // static ingredients, 1 => 1
                    new IngredientElement(typeof(EthanolItem), 1, true),
                    // dynamic ingredients
                    new IngredientElement(typeof(PlasticItem), 10, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                    new IngredientElement("Fat", 6, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                },
                items: new List<CraftingElement>
                {
                    new CraftingElement<BiodieselItem>(1),
                    new CraftingElement<OilItem>(4),
                }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(CuttingEdgeCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(BiofuelRecipe),
                start: 1,
                skillType: typeof(CuttingEdgeCookingSkill),
                typeof(CuttingEdgeCookingFocusedSpeedTalent),
                typeof(CuttingEdgeCookingParallelSpeedTalent)
            );
            this.Initialize(
                displayText: Localizer.DoStr("Plastic Container Biofuel"),
                recipeType: typeof(BiofuelRecipe)
            );
            CraftingComponent.AddRecipe(
                tableType: typeof(LaboratoryObject),
                recipe: this
            );
        }
    }
}
