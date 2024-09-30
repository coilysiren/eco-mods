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
    public partial class BiopoxyRecipe : RecipeFamily
    {
        public BiopoxyRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "Biopoxy",
                displayName: Localizer.DoStr("Coal Plastic Biopoxy"),
                ingredients: new List<IngredientElement>
                {
                    // dynamic ingredients
                    new IngredientElement(typeof(PlasticItem), 4, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                    new IngredientElement("Coal", 10, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                    new IngredientElement("Fat", 10, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                },
                items: new List<CraftingElement>
                {
                        new CraftingElement<EpoxyItem>(2),
                        new CraftingElement<OilItem>(10),
                }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(CuttingEdgeCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(BiopoxyRecipe),
                start: 1,
                skillType: typeof(CuttingEdgeCookingSkill),
                typeof(CuttingEdgeCookingFocusedSpeedTalent),
                typeof(CuttingEdgeCookingParallelSpeedTalent)
            );
            this.Initialize(
                displayText: Localizer.DoStr("Coal Plastic Biopoxy"),
                recipeType: typeof(BiopoxyRecipe)
            );
            CraftingComponent.AddRecipe(
                tableType: typeof(LaboratoryObject),
                recipe: this
            );
        }
    }
}
