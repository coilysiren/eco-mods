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
    public partial class PlasticBiofuel : RecipeFamily
    {
        public PlasticBiofuel()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "PlasticBiofuel",
                displayName: Localizer.DoStr("Plastic Container Biofuel, 50% Ethanol"),
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(EthanolItem), 2, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                    new IngredientElement("Fat", 5, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                    new IngredientElement(typeof(PlasticItem), 5, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                },
                items: new List<CraftingElement>
                {
                    new CraftingElement<BiodieselItem>()
                }
            );
            this.Recipes = new List<Recipe> { recipe };
            // Same as Oil Drilling
            this.ExperienceOnCraft = 0.5f;
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(CuttingEdgeCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(PlasticBiofuel),
                start: 0.8f,
                skillType: typeof(CuttingEdgeCookingSkill),
                typeof(CuttingEdgeCookingFocusedSpeedTalent),
                typeof(CuttingEdgeCookingParallelSpeedTalent)
            );
            this.Initialize(
                displayText: Localizer.DoStr("Plastic Container Biofuel, 50% Ethanol"),
                recipeType: typeof(PlasticBiofuel)
            );
            CraftingComponent.AddRecipe(
                tableType: typeof(LaboratoryObject),
                recipe: this
            );
        }
    }
}
